using InvoiceTask.Models.Context;
using InvoiceTask.Models.Entities;
using InvoiceTask.Models.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Repository_Implementation
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly ApplicationDbContext context;

        public InvoiceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void addInvoice(Invoice invoice)
        {
            context.Add(invoice);
            context.SaveChanges();
        }

        public int getLastInvoice()
        {
            if (context.Invoices.Count() > 0)
            {
                var lastID = (from d in context.Invoices
                              orderby d.InvoiceNO descending
                              select d.InvoiceNO).First();

                return lastID + 1;
            }
            return 1;
        }
    }
}
