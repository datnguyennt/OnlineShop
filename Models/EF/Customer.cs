namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public int? Age { get; set; }

        [StringLength(200)]
        public string CustomerAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }
    }
}
