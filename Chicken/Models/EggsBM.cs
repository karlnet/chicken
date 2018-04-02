using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chicken.Models
{
    public class EggsBM
    {
        [Required]
        public int batchid { get; set; }

        [Required]
        public int projectid { get; set; }

        public int EggsType { set; get; }
         
        public int Eggs { get; set; }
      
        public int EggsBox { get; set; }
        public double EggsWeight { get; set; }
    }
}