using Chicken.Data;
using Chicken.Data.Entities;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Chicken.Controllers
{
    public class BaseApiController : ApiController
    {
        private IRepository _repo;
        //private ModelFactory _modelFactory;

        private AppDbContext _AppDbContext = null;
        public BaseApiController()
        {
        }

        public BaseApiController(IRepository repo)
        {
            this._repo = repo;

        }
        protected AppDbContext AppDbContext
        {
            get
            {
                return _AppDbContext ?? Request.GetOwinContext().Get<AppDbContext>();
            }
        }
        protected IRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }
    }
}