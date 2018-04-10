using HtIOT.Data;
using HtIOT.Infrastructure;
using HtIOT.Models;
using HtIOT.Tools;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HtIOT.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        //private async Task<UserInfo> canLogin(AppDbContext appDbContext, string username,string password)
        //{
        //    string URI = "http://api.yfiot.com/service/getToken";
        //    var values = new Dictionary<string, string>{
        //             { "appid", AppData.ChickenAppId },
        //             { "userName",username },
        //             { "password", password },
        //             { "ttl", "1" }
        //    };

            //var result = await HttpHelper.GetValuesFromAPI(URI, values);

            //if (result.info.status == 0)
            //{               
            //    return null;
            //}

            //JObject bodyAsJson = JObject.Parse(result.body.ToString());
            //UserInfo userInfo = bodyAsJson.ToObject<UserInfo>();

            //var userProject = appDbContext.YFUserProjects.Where(m => m.UserID_int == userInfo.userId).ToList();
            //userProject.ForEach(m => {
            //    userInfo.userProjectids.Add(m.ProjectID_int);
            //});

            //AppData.UserList.AddOrUpdate(userInfo.userId, userInfo, (key, exitVal) => { return userInfo; });

        //    return userInfo;
        //}

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var appDbContext = context.OwinContext.Get<AppDbContext>();

            UserInfo userInfo = null;  // await canLogin(appDbContext,context.UserName, context.Password);
            if (null == userInfo)
                return;

            var identity = new ClaimsIdentity("JWT");

            //oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));
            //oAuthIdentity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(oAuthIdentity));

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            //identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("userid", userInfo.userId.ToString()));
            //identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            //identity.AddClaim(new Claim(ClaimTypes.Role, "Supervisor"));

            //var props = new AuthenticationProperties(new Dictionary<string, string>
            //    {
            //        {
            //             "audience", (context.ClientId == null) ? string.Empty : context.ClientId
            //        }
            //    });

            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);
            //return Task.FromResult<object>(null);

        }
    }
}