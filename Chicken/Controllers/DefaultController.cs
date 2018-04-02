using Chicken.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Chicken.Tools;

namespace Chicken.Controllers
{
    [RoutePrefix("test")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("")]
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        [HttpGet]
        [Route("{Id}")]
        public JObject Get(string Id)
        {
            return ExtJS.WriterJObject(true, data: new JArray(
                new JObject(
                    new JProperty("id", 1),
                    new JProperty("text", "test")
                )
            ));

        }

        [HttpPost]
        [Route("")]
        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
