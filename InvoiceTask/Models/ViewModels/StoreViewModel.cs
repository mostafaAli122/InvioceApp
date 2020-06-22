using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Store Name")]
        public string Name { get; set; }
    }
}
