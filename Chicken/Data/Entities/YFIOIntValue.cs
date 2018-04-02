namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YFIOIntValue
    {
        [Key]
        public int Id_int { get; set; }

        public DateTime? DT_datetime { get; set; }

        public int? ProjectId_int { get; set; }

        [StringLength(128)]
        public string IOName_nvarchar { get; set; }

        public int? IOValue_int { get; set; }

        [StringLength(128)]
        public string Remark_nvarchar { get; set; }
    }
}
