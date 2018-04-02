using Chicken.DTOs;
using Chicken.Infrastructure;
using Chicken.Models;
using Chicken.Tools;
using Chicken.YFModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Chicken.Controllers
{
    //[Authorize]
    /// <summary>
    /// 账户管理
    /// </summary>
    [RoutePrefix("Account")]
    public class AccountController : BaseApiController
    {


        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(SMSBM createUserModel)
        {
            ApiModel model = new ApiModel();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IDatabase redisCache = AppData.RedisConnection.GetDatabase();
            RedisValue msg = redisCache.HashGet("UserSMS", createUserModel.phone);
            if (msg.IsNullOrEmpty || !msg.ToString().Equals(createUserModel.smsMsg))
            {
                model.status = 0;
                model.message = "验证码不符。";
                model.body = null;
                return Ok(model);
            }
            var user = new ApplicationUser()
            {
                UserName = createUserModel.phone,
                PhoneNumber=createUserModel.phone,
                PhoneNumberConfirmed=true,
                Email = "orinoco@vip.163.com",
                EmailConfirmed=true,
                joindate = DateTime.Now,
                platformId = AppData.PlatformId
            };

            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.password);

            if (!addUserResult.Succeeded)
            {
                model.status = 0;
                model.message = "创建用户失败。";
                model.body = null;
                return Ok(model);
            }

            //string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

            //var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

            //await this.AppUserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            //return Created(locationHeader, TheModelFactory.Create(user));

            return Ok(user);

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login">登录信息</param>
        /// <returns>用户信息</returns>
        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Login(LoginBM login)
        {
            ApiModel model = new ApiModel();
            UserInfo userInfo = null;
            bool flag = false;
            string strResult;

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>{
                     { "grant_type", "password"},
                     { "username",login.username },
                     { "password", login.password }
                };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(AppData.ChickenOauth2URL, content);
                if (response.IsSuccessStatusCode)
                {
                    strResult = (string)JObject.Parse(await response.Content.ReadAsStringAsync())["access_token"];
                    var tokenS = new JwtSecurityTokenHandler().ReadToken(strResult) as JwtSecurityToken;
                    var userid = tokenS.Claims.First(claim => claim.Type == "userid").Value;
                    userInfo = AppData.UserList[int.Parse(userid)];
                    userInfo.chickenToken = strResult;
                    flag = true;
                }

                values = new Dictionary<string, string>{
                     { "appKey", AppData.EZAPPKEY},
                     { "appSecret",AppData.EZSECRET}
                };
                content = new FormUrlEncodedContent(values);
                response = await client.PostAsync(AppData.EZOPENURL, content);
                if (response.IsSuccessStatusCode)
                {
                    strResult = (string)JObject.Parse(await response.Content.ReadAsStringAsync())["data"]["accessToken"];
                    userInfo.hkToken = strResult;
                    flag = true;
                }

                if (flag)
                {
                    model.status = 1;
                    model.message = "登录成功";
                    model.body = userInfo;
                }
                else
                {
                    model.status = 0;
                    model.message = "用户名或密码错误";
                    model.body = null;
                }

            }

            return Ok(model);
        }

        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await this.AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/assignclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignClaimsToUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToAssign)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            foreach (ClaimBindingModel claimModel in claimsToAssign)
            {
                if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
                {

                    await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                }

                await this.AppUserManager.AddClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
            }

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/removeclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> RemoveClaimsFromUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToRemove)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            foreach (ClaimBindingModel claimModel in claimsToRemove)
            {
                if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
                {
                    await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                }
            }

            return Ok();
        }
        private static string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
        private CCPRestSDK.CCPRestSDK InitSMSAPI()
        {
            CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
            //bool isInit = api.init("app.cloopen.com", "8883");
            bool isInit = api.init(AppData.SMSServer, AppData.SMSServerPort);
            if (!isInit)
                return null;

            api.setAccount(AppData.SMSAccountId, AppData.SMSToken);
            api.setAppId(AppData.SMSAppId);
            return api;
        }
        public class SMSBM
        {
            [Required][Phone]
            public string phone { get; set; }
            public string password { get; set; }
            public string smsMsg { set; get; }
        }

        [Route("SendSMS")]
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult SendSMS(SMSBM sms)
        {
            ApiModel model = new ApiModel();

            try
            {
                CCPRestSDK.CCPRestSDK api = InitSMSAPI();
                if (api != null)
                {
                    Random random = new Random();
                    int smsMsg = random.Next(1000, 9999);

                    Dictionary<string, object> retData = api.SendTemplateSMS(sms.phone, AppData.SMSChickenTemplateId, new string[] { smsMsg.ToString(), "10" });
                    model.status = 1;
                    model.message = "发送成功";
                    model.body = getDictionaryData(retData);

                    IDatabase redisCache = AppData.RedisConnection.GetDatabase();
                    redisCache.HashSet("UserSMS", sms.phone, smsMsg.ToString());


                }
                else
                {
                    model.status = 0;
                    model.message = "初始化失败";
                    model.body = null;
                }
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = ex.Message;
            }

            return Ok(model);
        }

        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }



    }
}