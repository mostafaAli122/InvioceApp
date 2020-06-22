using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.ViewModels
{
    public class ItemViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(10)]
        public string name { get; set; }
        [Range(10, 500)]
        public decimal price { get; set; }
        public int storeId { get; set; }
    }
}
