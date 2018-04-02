using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chicken.Models
{
    public class FodderBM
    {
      
        [Required]
        public int projectid { get; set; }
         [Required]
        public int batchid { get; set; }
        [Required]
        public int code { get; set; }
        [Required]
        public double price { set; get; }
      

    }
}