using Chicken.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chicken.Models
{
    public class BatchBM
    {
        public int batchid { get; set; }
        [Required]
        public int projectid { get; set; }
        [Required]
        public string lairageDate { get; set; }
        [Required]
        public int lairageAmount { get; set; }
        [Required]
        public int chickenTypeID { get; set; }
        public string remarks { get; set; }
        [Required]
        public double lairageWeight { set; get; }
        [Required]
        public int lairageChickenCode { set; get; }
        [Required]
        public double lairageChickenPrice { set; get; }
        [Required]
        public int lairageFodderCode { set; get; }
        [Required]
        public double lairageFodderPrice { set; get; }




        public YFBatchRecord Create()
        {
            return new YFBatchRecord()
            {
                ProjectID_int = projectid,
                BatchID_int = batchid,
                Lairage_datatime = DateTime.Parse(lairageDate),
                LairageAmount_int = lairageAmount,
                ChickenTypeID_int = chickenTypeID,
                SlaughterFlag_bit = false,
                Remarks_nvarchar = remarks,
                LairageChickenPrice_float=lairageChickenPrice,
                LairageFodderPrice_float=lairageFodderPrice,
                LairageWeight_float=lairageWeight,
                LariageChickenID_int=lairageChickenCode,
                LariageFodderID_int=lairageFodderCode

            };
        }

    }
}