namespace Chicken.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            device = new HashSet<Device>();
            point = new HashSet<Point>();
            project_role = new HashSet<Project_Role>();
            user_project = new HashSet<User_Project>();
        }

        public string projectId { get; set; }

        [Required]
        [StringLength(128)]
        public string platformId { get; set; }

        [Required]
        [StringLength(256)]
        public string name { get; set; }

        [StringLength(256)]
        public string alias { get; set; }

        [StringLength(256)]
        public string project_key { get; set; }

        [StringLength(512)]
        public string project_token { get; set; }

        [StringLength(256)]
        public string province { get; set; }

        [StringLength(256)]
        public string location { get; set; }

        [StringLength(256)]
        public string city { get; set; }

        [StringLength(32)]
        public string postcode { get; set; }

        [StringLength(1024)]
        public string comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> device { get; set; }

        public virtual Platform platform { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Point> point { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_Role> project_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Project> user_project { get; set; }
    }
}
