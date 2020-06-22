using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Entities
{
    public class Store
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        //public virtual ICollection<Item> Items { get; set; }
       // public virtual ICollection<Invoice> Invoice { get; set; } 

    }
}
