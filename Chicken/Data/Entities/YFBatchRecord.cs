namespace Chicken.Data.Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFBatchRecord")]
    public partial class YFBatchRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YFBatchRecord()
        {
            YFBatchRecordAddChickens = new HashSet<YFBatchRecordAddChicken>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BatchID_int { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID_int { get; set; }

        public int ChickenTypeID_int { get; set; }

        public DateTime? Lairage_datatime { get; set; }

        public DateTime? Slaughter_datetime { get; set; }

        public int? LairageAmount_int { get; set; }

        public int? TotalDieAmount_int { get; set; }

        public double? AverageWeight_float { get; set; }

        public double? Evenness_float { get; set; }

        public double? TotalFodderCumulant_float { get; set; }

        public double? TotalWaterCumulant_float { get; set; }

        public double? TotalElectricCumulant_float { get; set; }

        public double? TotalMedicine_float { get; set; }

        public double? TotalOtherItem_float { get; set; }

        public double? TotalCoalCumulant_float { get; set; }

        public bool SlaughterFlag_bit { get; set; }

        [StringLength(256)]
        public string Remarks_nvarchar { get; set; }

        public int? LariageFodderID_int { get; set; }
        public int? LariageChickenID_int { get; set; }
        public double? LairageFodderPrice_float { get; set; }
        public double? LairageChickenPrice_float { get; set; }
        public double? LairageWeight_float { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<YFBatchRecordAddChicken> YFBatchRecordAddChickens { get; set; }
    }
}
