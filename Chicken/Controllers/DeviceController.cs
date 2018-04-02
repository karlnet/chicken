using Chicken.Data;
using Chicken.DTOs;
using Chicken.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Chicken.Controllers
{
    [RoutePrefix("Device")]
    public class DeviceController : BaseApiController
    {
        
        public DeviceController(IRepository repo)
            : base(repo)
        {
        }

        [HttpGet]
        [Route("")]
        public ApiModel Get()
        {
            ApiModel model = new ApiModel();
            try
            {
                var devices = AppDbContext.devices;
                if (devices == null)
                {
                    model.status = 0;
                    model.message = "查询失败，没有设备信息";
                }
                else
                {
                    model.status = 1;
                    model.total = devices.Count().ToString();
                    model.message = "查询成功";
                    model.body = devices;
                }

            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = ex.Message;
            }

            return model;
        }

    }
}