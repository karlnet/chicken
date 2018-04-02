using Chicken.Data;
using Chicken.DTOs;
using Chicken.Infrastructure;
using Chicken.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Chicken.Controllers
{
    [RoutePrefix("scripts/project")]
    public class ProjectController : BaseApiController
    {

        public ProjectController(IRepository repo)
            : base(repo)
        {
        }

        [HttpGet]
        [Route("menu/root")]
        public ApiModel Get()
        {
            ApiModel model = new ApiModel();

            model.status = 1;
            model.total = "4";
            model.message = "查询成功";

            MenuItem menu = new MenuItem(10, "河南1#", false, true, "","");
            menu.setChildren(AppData.GetDefaultMenuItem().Values.ToList());

            model.body = menu;


            return model;
        }

    }
}