namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFChickenDailyReport")]
    public partial class YFChickenDailyReport
    {
        [Key]
        public int ID_int { get; set; }

        public int? ProjectID_int { get; set; }

        public int? BatchID_int { get; set; }

        public int? Day_int { get; set; }

        public DateTime DTCreate_datetime { get; set; }

        public DateTime? DTModify_datetime { get; set; }

        public double? FodderCumulant_float { get; set; }

        public double? TotalFodderCumulant_float { get; set; }

        public double? WaterCumulant_float { get; set; }

        public double? TotalWaterCumulant_float { get; set; }

        public double? ElectricCumulant_float { get; set; }

        public double? TotalElectricCumulant_float { get; set; }

        public double? CoalCumulant_float { get; set; }

        public double? TotalCoalCumulant_float { get; set; }

        public int? DieAmount_int { get; set; }

        public int? TotalDieAmount_int { get; set; }
        public int? TotalChickenAmount_int { get; set; }     

        public double? Medicine_float { get; set; }

        public double? TotalMedicine_float { get; set; }

        public double? OtherItem_float { get; set; }

        public double? TotalOtherItem_float { get; set; }

        public double? Weight_float { get; set; }

        public double? Evenness_float { get; set; }

        [StringLength(256)]
        public string Remarks_nvarchar { get; set; }

        public T ShallowCopy<T>() where T : YFChickenDailyReport
        {
            return (T)(MemberwiseClone());
        }

    }
}
