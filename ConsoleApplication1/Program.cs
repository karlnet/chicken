using CCPRestSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
        class Program
        {
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
            static void Main(string[] args)
            {
                string ret = null;

                CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
                //ip格式如下，不带https://
                bool isInit = api.init("app.cloopen.com", "8883");
                api.setAccount("aaf98f8952a572be0152a64ce78c01ec", "c008b9fd349744d08f94cec4d3966884");
                api.setAppId("aaf98f8952a572be0152a6505b7e0201");

                try
                {
                    if (isInit)
                    {
                        Dictionary<string, object> retData = api.SendTemplateSMS("13701308059", "66950", new string[] { "325435", "3" });
                        ret = getDictionaryData(retData);
                    }
                    else
                    {
                        ret = "初始化失败";
                    }
                }
                catch (Exception exc)
                {
                    ret = exc.Message;
                }
                finally
                {
                    //Response.Write(ret);
                }

            }
        }
   
}
