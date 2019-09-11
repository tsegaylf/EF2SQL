using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF2SQLLibrary
{
    public partial class RequestLines
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("RequestLines")]
        public virtual Products Product { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("RequestLines")]
        public virtual Requests Request { get; set; }
    }
}
