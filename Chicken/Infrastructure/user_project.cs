using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Chicken.Infrastructure
{


    public partial class User_Project
    {
        [Key]
        [Column(Order = 0)]
        public string userId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string projectId { get; set; }

        public virtual Project project { get; set; }
    }
}
