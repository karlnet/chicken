using Chicken.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.DTOs
{
    public class BatchRM
    {
        public BatchRM(YFBatchRecord batch)
        {
            projectId = batch.ProjectID_int;
            chickenTypeID = batch.ChickenTypeID_int;
            batchID = batch.BatchID_int;
            lairageDate = batch.Lairage_datatime.Value.ToString("yyyy-MM-dd");
            lairageAmount = batch.LairageAmount_int;
            remarks = batch.Remarks_nvarchar;
            lairageFodderId = batch.LariageFodderID_int;
            lairageFodderPrice = batch.LairageFodderPrice_float;
            lairageChickenId = batch.LariageChickenID_int;
            lairageChickenPrice = batch.LairageChickenPrice_float;
            lairageWeight = batch.LairageWeight_float;


        }
        public int projectId { get; set; }
        public int batchID { get; set; }        
        public string lairageDate { get; set; }
        public int? lairageAmount { get; set; }
        public int chickenTypeID { get; set; }
        public string remarks { get; set; }

        public int? lairageFodderId { get; set; }
        public int? lairageChickenId { get; set; }
        public double? lairageFodderPrice { get; set; }
        public double? lairageChickenPrice { get; set; }
        public double? lairageWeight { get; set; }


    }
}