using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtIOT.DTOs
{
    public class ApiModel
    {

        public int status { get; set; }

        public string message { get; set; }

        public string total { get; set; }

        public string time { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public object body { get; set; }
    }
 

}