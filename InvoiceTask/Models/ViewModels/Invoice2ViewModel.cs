using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.ViewModels
{
    public class Invoice2ViewModel
    {
        public DateTime InvoiceDate { get; set; }

        public int Storeid { get; set; }
        public decimal Total { get; set; }
        public decimal Taxes { get; set; }
        public decimal Net { get; set; }
    }
}
