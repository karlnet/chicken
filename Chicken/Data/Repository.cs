using HtIOT.Data.Entities;
using HtIOT.DTOs;
using HtIOT.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtIOT.Data
{
    public class Repository : IRepository
    {
        private AppDbContext db;  
        public Repository(AppDbContext ctx)
        {
            db = ctx;    
        }
 
    
    }
}