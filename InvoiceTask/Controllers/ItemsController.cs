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
    public class ItemsController : Controller
    {
        private readonly IItemRepo item;
        private readonly IStoreRepo store;

        public ItemsController(IItemRepo item,IStoreRepo store)
        {
            this.item = item;
            this.store = store;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.StoreID = new SelectList(store.getAllStores(), "id", "name");
            return View();
        }
        [HttpGet]
        public IActionResult ListItems()
        {
            return Json(item.getAllItemes());
        }
        [HttpPost]
        public IActionResult CreateItem(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                Item newitem = new Item
                {
                    name = model.name,
                    price = model.price,
                    storeId = model.storeId
                };
                item.addItem(newitem);
                return Json("Success");
            }
            return Json("error");
        }
        public IActionResult getbyID(int id)
        {
            var myitem = item.getItemByID(id);
            if (myitem != null)
            {
                var model = new ItemViewModel
                {
                    id = myitem.id,
                    name = myitem.name,
                    price=myitem.price,
                    storeId=myitem.storeId
                };
                return Json(model);
            }
            return Json("error");
        }
        [HttpPost]
        public IActionResult EditItem(ItemViewModel model)
        {
            var myitem = new Item
            {
                id = model.id,
                name = model.name,
                price=model.price,
                storeId=model.storeId

            };
            if (item.updateItem(myitem))
                return Json("Success");
            return Json("error");
        }
        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            if (item.deleteItem(id))
                return Json("Success");
            return Json("error");
        }
    }
}