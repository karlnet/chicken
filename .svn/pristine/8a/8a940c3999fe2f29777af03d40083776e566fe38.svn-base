namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFProject")]
    public partial class YFProject
    {
        [Key]
        public int ProjectID_int { get; set; }

        [StringLength(64)]
        public string Name_nvarchar { get; set; }

        [StringLength(16)]
        public string RegionID_nvarchar { get; set; }

        [StringLength(256)]
        public string RegionName_nvarchar { get; set; }

        public int? TemplateID_int { get; set; }

        [StringLength(128)]
        public string Remark_nvarchar { get; set; }

        public bool? Enabled_bit { get; set; }

        public bool? DebugMode_bit { get; set; }

        public bool? ServerEnabled_bit { get; set; }

        public bool? WebSocketEnabled_bit { get; set; }

        public int? CameraNumber_int { get; set; }

        public bool? DisableUpdateConfig_bit { get; set; }

        [StringLength(128)]
        public string GcCoordinate_nvarchar { get; set; }

        [StringLength(256)]
        public string ExConfig_nvarchar { get; set; }

        public bool DisableSystemUpdate_bit { get; set; }

        public bool? SmsNotify_bit { get; set; }

        public bool? WeNotify_bit { get; set; }

        public bool? EmailNotiy_bit { get; set; }

        [StringLength(256)]
        public string CameraConfig1_nvarchar { get; set; }

        [StringLength(256)]
        public string CameraConfig2_nvarchar { get; set; }

        [StringLength(256)]
        public string CameraConfig3_nvarchar { get; set; }

        [StringLength(256)]
        public string CameraConfig4_nvarchar { get; set; }
    }
}
