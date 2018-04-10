namespace HtIOT.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role_Point
    {
        [Key]
        [Column(Order = 0)]
        public string roleId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string pointId { get; set; }

        public virtual Point point { get; set; }
    }
}
