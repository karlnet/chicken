﻿using HtIOT.Data;
using HtIOT.DTOs;
using HtIOT.Infrastructure;
using HtIOT.Tools;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace HtIOT.Controllers
{
    public class BaseApiController : ApiController
    {
        private IRepository _repo;
        private ModelFactory _modelFactory;
        private AppDbContext _AppDbContext = null;
        private ConnectionMultiplexer _redisConnection = null;
        private ApplicationUserManager _AppUserManager = null;
        private ApplicationRoleManager _AppRoleManager = null;

        protected int UserId
        {
            get
            {
                var identity = User.Identity as ClaimsIdentity;
                return int.Parse(identity.Claims.Where(m => m.Type == "userid").FirstOrDefault().Value);
            }

        }
        protected string Token
        {
            get
            {
                return AppData.UserList[UserId].token;
            }

        }

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
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        protected ConnectionMultiplexer RedisConnection
        {
            get
            {
                return _redisConnection ?? Request.GetOwinContext().Get<ConnectionMultiplexer>();
            }
        }
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }
        protected IRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}