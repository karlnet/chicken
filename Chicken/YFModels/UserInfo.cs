﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.YFModels
{
    public class UserInfo
    {
        public UserInfo()
        {
            userProjectids = new List<int>();
        }
        public string token { get; set; }
        public string chickenToken { get; set; }
        public string hkToken { get; set; }
        public string appid { get; set; }
        public string phone { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public bool isAdmin { get; set; }
        public string roleName { get; set; }
        public int roleId { get; set; }
        public string nickName { get; set; }
        public string loginTime { get; set; }
        public string expiresTime { get; set; }
        [JsonIgnore]
        public List<int> userProjectids { set; get; }

    }


}