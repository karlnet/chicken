namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFUserInfo")]
    public partial class YFUserInfo
    {
        [Key]
        public int UserID_int { get; set; }

        [StringLength(32)]
        public string Name_nvarchar { get; set; }

        [StringLength(32)]
        public string Nickname_nvarchar { get; set; }

        [StringLength(256)]
        public string Password_nvarchar { get; set; }

        [StringLength(128)]
        public string Email_nvarchar { get; set; }

        [StringLength(32)]
        public string Phone_nvarchar { get; set; }

        public byte? Status_tinyint { get; set; }

        public int? RoleID_int { get; set; }

        public byte? SuperAdmin_tinyint { get; set; }

        [StringLength(128)]
        public string Remark_nvarchar { get; set; }

        [StringLength(50)]
        public string We_nvarchar { get; set; }

        public bool DisablePush_bit { get; set; }
    }
}
