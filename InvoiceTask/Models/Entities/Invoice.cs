using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceNO{ get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }

        public int Storeid { get; set; }
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
        [Column(TypeName = "money")]
        public decimal Taxes { get; set; }
        [Column(TypeName = "money")]
        public decimal Net { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<InvoiceItems> InvoiceItems { get; set; }
    }
}
