using Chicken.DTOs;
using Chicken.Models;
using Chicken.Tools;
using Chicken.YFModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
                    model.info.status = 1;
                    model.info.message = "登录成功";
                    model.body = userInfo;
                }
                else
                {
                    model.info.status = 0;
                    model.info.message = "用户名或密码错误";
                    model.body = null;
                }

            }

            return Ok(model);
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
            public string phone { get; set; }
            public string house { set; get; }
            public string device { get; set; }
            public string msg { set; get; }
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
                    Dictionary<string, object> retData = api.SendTemplateSMS(sms.phone, AppData.SMSChickenTemplateId, new string[] { sms.house, sms.device, sms.msg });
                    model.info.status = 1;
                    model.info.message = "发送成功";
                    model.body = getDictionaryData(retData);
                }
                else
                {
                    model.info.status = 0;
                    model.info.message = "初始化失败";
                    model.body = null;
                }
            }
            catch (Exception ex)
            {
                model.info.status = 0;
                model.info.message = ex.Message;
            }

            return Ok(model);
        }

    }
}