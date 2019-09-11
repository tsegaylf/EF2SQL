﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF2SQLLibrary
{
    public partial class Products
    {
        public Products()
        {
            RequestLines = new HashSet<RequestLines>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string PartNbr { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(30)]
        public string Unit { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }
        [Column("VendorID")]
        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        [InverseProperty("Products")]
        public virtual Vendors Vendor { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<RequestLines> RequestLines { get; set; }
    }
}
