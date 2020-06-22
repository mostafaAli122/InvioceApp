using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceTask.Models.Entities;
using InvoiceTask.Models.Repository_Interfaces;
using InvoiceTask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvoiceTask.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IStoreRepo store;
        private readonly IItemRepo item;
        private readonly IInvoiceRepo invoice;

        public InvoiceController(IStoreRepo store,IItemRepo item,IInvoiceRepo invoice)
        {
            this.store = store;
            this.item = item;
            this.invoice = invoice;
        }
        public IActionResult Index()
        {
            ViewBag.storeID = new SelectList(store.getAllStores(), "id", "name");
            var model = new InvoiceViewModel { LastInvoiceID = invoice.getLastInvoice() };
            return View(model);
        }
        public IActionResult GetItems(int id)
        {
            var items=item.getItemByStoreID(id);
            if(items!=null)
            {
                var model = new List<ItemViewModel>();
                foreach (var item in items)
                {
                    model.Add(new ItemViewModel {
                        id = item.id,
                        name = item.name,
                        price =item.price,
                        storeId=item.storeId
                        });
                }
                return Json(model);
            }
            return Json("error");
        }
       public IActionResult CreateInvoice(Invoice2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                Invoice newnvoice = new Invoice
                {
                    InvoiceDate=model.InvoiceDate,
                    Storeid=model.Storeid,
                    Total=model.Total,
                    Taxes=model.Taxes,
                    Net=model.Net
                };
                invoice.addInvoice(newnvoice);
                return Json("Success");
            }
            return Json("error");
        }
    }
}