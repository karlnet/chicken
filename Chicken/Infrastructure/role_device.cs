namespace Chicken.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role_Device
    {
        [Key]
        [Column(Order = 0)]
        public string roleId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string deviceId { get; set; }

        public virtual Device device { get; set; }
    }
}
