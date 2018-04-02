using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Chicken.Infrastructure
{
    [Table("device")]
    public partial class Device
    {
 
        public Device()
        {
            point = new HashSet<Point>();
            role_device = new HashSet<Role_Device>();
        }

        public string deviceId { get; set; }

        [Required]
        [StringLength(128)]
        public string projectId { get; set; }

        [Required]
        [StringLength(128)]
        public string deviceNo { get; set; }

        [Required]
        [StringLength(256)]
        public string name { get; set; }

        [StringLength(256)]
        public string alias { get; set; }

        [StringLength(128)]
        public string parentId { get; set; }

        [StringLength(128)]
        public string gatewayId { get; set; }

        public bool? is_gateway { get; set; }

        [StringLength(256)]
        public string token { get; set; }

        [StringLength(256)]
        public string status { get; set; }

        public DateTime? offtime { get; set; }

        public DateTime? onlinetime { get; set; }

        public DateTime? createtime { get; set; }

        [StringLength(256)]
        public string device_type { get; set; }

        [StringLength(256)]
        public string vendor { get; set; }

        [StringLength(256)]
        public string brand { get; set; }

        [StringLength(256)]
        public string model { get; set; }

        [StringLength(256)]
        public string rom_version { get; set; }

        [StringLength(256)]
        public string network_type { get; set; }

        [StringLength(256)]
        public string mac { get; set; }

        [StringLength(256)]
        public string private_ip { get; set; }

        [StringLength(256)]
        public string public_ip { get; set; }

        [StringLength(256)]
        public string ssid { get; set; }

        [StringLength(256)]
        public string bssid { get; set; }

        [StringLength(256)]
        public string wifi_password { get; set; }

        [StringLength(256)]
        public string address { get; set; }

        [StringLength(256)]
        public string config { get; set; }

        [StringLength(1024)]
        public string comment { get; set; }
        [JsonIgnore]
        public virtual Project project { get; set; }

        public virtual ICollection<Point> point { get; set; }
        [JsonIgnore]
        public virtual ICollection<Role_Device> role_device { get; set; }
    }
}
