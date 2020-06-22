using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public int item { get; set; }
        public int storeId { get; set; }
        public int LastInvoiceID { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal Invoicenet { get; set; }
        public decimal InvoiceTaxes { get; set; }
    }
}
