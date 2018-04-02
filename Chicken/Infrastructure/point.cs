namespace Chicken.Infrastructure
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("point")]
    public partial class Point
    {

        public Point()
        {
            role_point = new HashSet<Role_Point>();
        }

        public string pointId { get; set; }

        [Required]
        [StringLength(128)]
        public string deviceId { get; set; }

        [Required]
        [StringLength(128)]
        public string projectId { get; set; }

        [Required]
        [StringLength(128)]
        public string pointNo { get; set; }

        [Required]
        [StringLength(256)]
        public string name { get; set; }

        [StringLength(256)]
        public string alias { get; set; }

        [StringLength(256)]
        public string projectNo { get; set; }

        [StringLength(256)]
        public string data_type { get; set; }

        public bool? enable { get; set; }

        public double? uplimit { get; set; }

        public double? lowlimit { get; set; }

        public double? max_value { get; set; }

        public double? min_value { get; set; }

        public double? default_value { get; set; }

        [StringLength(256)]
        public string express { get; set; }

        [StringLength(1024)]
        public string comment { get; set; }

        [JsonIgnore]
        public virtual Device device { get; set; }

        [JsonIgnore]
        public virtual Project project { get; set; }

        [JsonIgnore]
        public virtual ICollection<Role_Point> role_point { get; set; }
    }
}
