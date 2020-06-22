using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using InvoiceTask.Models.Entities;
using InvoiceTask.Models.Repository_Interfaces;
using InvoiceTask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTask.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepo store;
        private readonly IItemRepo item;

        public StoreController(IStoreRepo store,IItemRepo item)
        {
            this.store = store;
            this.item = item;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListStores()
        {
            return Json(store.getAllStores());
        }
        [HttpPost]

        public IActionResult CreateStore(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                Store newStore = new Store
                {
                    name = model.Name
                };
                store.addStore(newStore);
                return Json("Success");
            }
            return Json("error");
        }
        public IActionResult getbyID(int id)
        {
            var mystore = store.getStoreByID(id);
            if(mystore!=null)
            {
                var model = new StoreViewModel
                {
                    Id = mystore.id,
                    Name = mystore.name
                };
                return Json(model);
            }
            return Json("error");
        }
        [HttpPost]
        public IActionResult EditStore(StoreViewModel model)
        {
            var mystore = new Store
            {
                id = model.Id,
                name = model.Name

            };
            if (store.updateStore(mystore))
                return Json("Success");
            return Json("error");
        }
        [HttpPost]
        public IActionResult DeleteStore(int id)
        {
            //using (TransactionScope tran = new TransactionScope())
            //{
            //    CallAMethodThatDoesSomeWork();
            //    CallAMethodThatDoesSomeMoreWork();
            //    tran.Complete();
            //}
            if (store.deleteStore(id))
                return Json("Success");
            return Json("error");
        }
    }
}