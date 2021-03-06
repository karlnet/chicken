﻿using Chicken.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Chicken.Tools
{
    public class HttpHelper
    {
        public static async Task<YFApiModel> GetValuesFromAPI(string URI, Dictionary<string, string> values)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(URI, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<YFApiModel>();
                }
                return null;
            }
        }

    }
}