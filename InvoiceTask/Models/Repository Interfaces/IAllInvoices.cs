using InvoiceTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Repository_Interfaces
{
    public interface IAllInvoices
    {
        IEnumerable<Invoice> getAllInvoices();
    }
}
