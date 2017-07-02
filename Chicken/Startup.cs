using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Linq;
using Microsoft.Practices.Unity;
using Chicken.Resolvers;
using Chicken.Data;
using Chicken.Data.Entities;
using System.Configuration;
using Microsoft.Owin.Security.OAuth;
using Chicken.Providers;
using Chicken.Formats;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Swashbuckle.Application;
using System.Reflection;
using System.IO;
using System.Xml.XPath;
using Chicken.Tools;

[assembly: OwinStartup(typeof(Chicken.Startup))]

namespace Chicken
{
    public class Startup
    {
        private const string issuer = AppData.ChickenURL;

        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            app.MapSignalR();

            HttpConfiguration httpConfig = new HttpConfiguration();
            httpConfig
                .EnableSwagger(c =>
                {
                    //c.OAuth2("OAuth2")
                    // .Description("OAuth2 Implicit Grant")
                    // .Flow("implicit")
                    // .AuthorizationUrl("http://192.168.1.6:11111/Account/Login")
                    // .Scopes(scopes =>
                    // {
                    //     scopes.Add("read", "Read access to protected resources");
                    //     scopes.Add("write", "Write access to protected resources");
                    // });

                    //c.OperationFilter<AssignOAuth2SecurityRequirements>();
                    c.RootUrl(req => AppData.ChickenURL);
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.SingleApiVersion("v1", "Chicken");
                })
                .EnableSwaggerUi();
            ConfigureOAuthTokenGeneration(app);
            ConfigureOAuthTokenConsumption(app);

            ConfigureWebApi(httpConfig);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);

        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\chicken.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppDbContext.Create);
            //app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

        }
        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            //Web API  services
            var container = new UnityContainer();
            container.RegisterType<IRepository, Repository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }

    }
}
