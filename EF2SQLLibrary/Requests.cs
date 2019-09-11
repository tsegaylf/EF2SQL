﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF2SQLLibrary
{
    public partial class Requests
    {
        public Requests()
        {
            RequestLines = new HashSet<RequestLines>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [Required]
        [StringLength(80)]
        public string Justification { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [Required]
        [StringLength(20)]
        public string DiliveryMode { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Total { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Requests")]
        public virtual Users User { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestLines> RequestLines { get; set; }
    }
}
