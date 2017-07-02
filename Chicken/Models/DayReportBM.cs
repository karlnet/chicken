﻿using Chicken.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chicken.Models
{
    public class DayReportBM
    {
        [Required]
        public int batchid { get; set; }
       
        [Required]
        public int projectid { get; set; }
        [Required]
        public double coalCumulant { get; set; }
        [Required]
        public int dieAmount { get; set; }
        [Required]
        public double medicine { get; set; }
        [Required]
        public double otherItem { get; set; }
        
        public string remarks { get; set; }

        public YFChickenDailyReport Create()
        {
            return new YFChickenDailyReport()
            {
                ProjectID_int = projectid,
                BatchID_int = batchid,
                CoalCumulant_float = coalCumulant,
                DieAmount_int = dieAmount,
                Medicine_float = medicine,
                OtherItem_float = otherItem,
                Remarks_nvarchar = remarks
            };
        }

    }
}