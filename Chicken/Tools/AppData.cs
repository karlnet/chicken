using Chicken.YFModels;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Chicken.Tools
{
    public class AppData
    {

        public const string ChickenURL = "http://api.yfiot.com/chicken2/";
        //public const string ChickenURL = "http://192.168.1.6:11111/";


        public const string PlatformId = "F0F03BF1-D71D-4481-A4F7-8886E76DCD01";
       
        public const string YFIOURI = "http://api.yfiot.com/io/getIoValues";
        public const string YFIOwURI = "http://api.yfiot.com/io/writeIoValues";

        public const string ChickenOauth2URL = ChickenURL + "oauth2/token";
        public const string ChickenAppId = "B2A40576-03FE-408B-9C05-9E2A8CEA1381";
        public const string EZOPENURL = "https://open.ys7.com/api/lapp/token/get";
        public const string EZAPPKEY = "d2560ed3d4ec4ff5824608e9852b2dea";
        public const string EZSECRET = "09d2dc9e7a5c0d6e9194223495777936";

        public const string SMSServer = "app.cloopen.com";
        public const string SMSServerPort = "8883";
        public const string SMSAccountId = "aaf98f8952a572be0152a64ce78c01ec";
        public const string SMSToken = "c008b9fd349744d08f94cec4d3966884";
        public const string SMSAppId = "aaf98f8952a572be0152a6505b7e0201";
        public const string SMSChickenTemplateId = "66950";
        //public const string SMSChickenTemplateId = "66950";
        
        public static ConcurrentDictionary<int, UserInfo> UserList = new ConcurrentDictionary<int, UserInfo>();

        private static Lazy<ConnectionMultiplexer> lazyRedisConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisCacheConnection"].ToString());
            //return ConnectionMultiplexer.Connect("hhnext.redis.cache.windows.net" + ",abortConnect=false,ssl=true,password=" + "2a8N8qu0H86t4UmXhWTwCjdmGq0EUZHYBqsCgB23j5Q=");

        });
        public static ConnectionMultiplexer RedisConnection
        {
            get
            {
                return lazyRedisConnection.Value;
            }
        }



    }
}