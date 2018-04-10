using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtIOT.Tools
{
    public class ExtJS
    {

        public static JObject WriterJObject(bool success, JObject errors = null, string total = null, string msg = null, object data = null)
        {

            JObject jo = new JObject(new JProperty("status", 1),new JProperty("tiem",DateTime.Now));
            if (errors != null)
            {
                jo.Add(new JProperty("errors", errors));
            }
            if (total != null)
            {
                jo.Add(new JProperty("total", total));
            }
            if (msg != null)
            {
                jo.Add(new JProperty("message", msg));
            }
            if (data != null)
            {
                jo.Add(new JProperty("data", data));
            }

            return jo;

        }

    }
}