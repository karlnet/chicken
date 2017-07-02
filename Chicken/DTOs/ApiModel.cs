using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.DTOs
{
    public class ApiModel
    {

        public ApiModel()
        {
            this.info = new ApiInfo
            {
                status = 0,
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        public ApiInfo info { get; set; }

        public object body { get; set; }
    }

    public class ApiInfo
    {
        public int status { get; set; }

        public string message { get; set; }

        public string time { get; set; }
    }
}