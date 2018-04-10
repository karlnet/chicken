using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtIOT.Infrastructure
{
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }
        [MaxLength(512)]
        public string comment { get; set; }
        [MaxLength(256)]
        public string alias { get; set; }
        [Required]
        [MaxLength(128)]
        public string platformId { get; set; }
    }
}