namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFProjectIO")]
    public partial class YFProjectIO
    {
        [Key]
        public int IOID_int { get; set; }

        public int TemplateID_int { get; set; }

        [Required]
        [StringLength(32)]
        public string Name_nvarchar { get; set; }

        [Required]
        [StringLength(2)]
        public string Type_nvarchar { get; set; }

        [StringLength(32)]
        public string DefaultValue_nvarchar { get; set; }

        [StringLength(128)]
        public string Comment_nvarchar { get; set; }

        public bool? UploadFlag_bit { get; set; }

        public bool? PublishFlag_bit { get; set; }

        public int? Sort_int { get; set; }

        [StringLength(32)]
        public string NickName_nvarchar { get; set; }

        [StringLength(32)]
        public string CronExpression_nvarchar { get; set; }

        public bool DownFlag_bit { get; set; }

        public double MaxValue_float { get; set; }

        public double MinValue_float { get; set; }

        [StringLength(128)]
        public string ExtendConfig_nvarchar { get; set; }
    }
}
