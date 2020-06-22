using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceTask.Models.Context;
using InvoiceTask.Models.Entities;
using InvoiceTask.Models.Repository_Interfaces;
namespace InvoiceTask.Models.Repository_Implementation
{
    public class AllInvoicesRepo : IAllInvoices
    {
        private readonly ApplicationDbContext context;

        public AllInvoicesRepo(ApplicationDbContext context )
        {
            this.context = context;
        }
        public IEnumerable<Invoice> getAllInvoices()
        {
            return context.Invoices.ToList();
        }
    }
}
