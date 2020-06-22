using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Entities
{
    public enum Unit
    {
        Package,Packet
    }
    public class InvoiceItems
    {
        [Key]
        public int invoiceItemsId { get; set; }
        public int invoiceId { get; set; }
        public int ItemId { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public Unit unit { get; set; }
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
        [Column(TypeName = "money")] 
        public decimal Discount { get; set; }
        [Column(TypeName = "money")] 
        public decimal Net { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Item Items { get; set; }
    }
}
