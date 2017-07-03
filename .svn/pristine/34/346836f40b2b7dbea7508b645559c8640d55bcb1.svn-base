namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFBatchRecordAddChicken")]
    public partial class YFBatchRecordAddChicken
    {
        [Key]
        public int ID_int { get; set; }

        public DateTime DTCreate_datetime { get; set; }

        public DateTime? DTModify_datetime { get; set; }

        public int BatchID_int { get; set; }

        public int ProjectID_int { get; set; }

        public int? ChickenAmount_int { get; set; }

        public int? TotalChickenAmount_int { get; set; }

        public virtual YFBatchRecord YFBatchRecord { get; set; }
    }
}
