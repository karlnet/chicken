using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtIOT.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
      
        [MaxLength(256)]
        public string alias { get; set; }
        [MaxLength(256)]
        public string type { get; set; }
        [MaxLength(256)]
        public string token { get; set; }
        [MaxLength(256)]
        public string key { get; set; }
        [MaxLength(512)]
        public string comment { get; set; }
        [Required]
        [MaxLength(128)]
        public string platformId { get; set; }
        public DateTime joindate { get; set; }
    }
}