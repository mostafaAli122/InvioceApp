using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceTask.Models.Repository_Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTask.Controllers
{
    public class AllInvoicesController : Controller
    {
        private readonly IAllInvoices allInvoices;

        public AllInvoicesController(IAllInvoices allInvoices)
        {
            this.allInvoices = allInvoices;
        }
        public IActionResult Index()
        {
            
            return View(allInvoices.getAllInvoices());
        }
    }
}