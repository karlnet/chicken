namespace Chicken.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YFBabyChickenSupplier")]
    public partial class YFBabyChickenSupplier
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        public string baby_no { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string supplier { get; set; }

        [StringLength(255)]
        public string principal { get; set; }

        [StringLength(255)]
        public string tel { get; set; }

        [StringLength(255)]
        public string comment { get; set; }
    }
}