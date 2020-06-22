using InvoiceTask.Models.Context;
using InvoiceTask.Models.Entities;
using InvoiceTask.Models.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Repository_Implementation
{
    public class StoreRepo : IStoreRepo
    {
        private readonly ApplicationDbContext context;

        public StoreRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void addStore(Store store)
        {
            context.Add(store);
            context.SaveChanges();
        }

        public bool deleteStore(int id)
        {
            var store = context.Stores.FirstOrDefault(x => x.id == id);
            if(store!=null)
            {
                context.Stores.Remove(store);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Store> getAllStores()
        {
            return context.Stores.ToList();
        }

        public Store getStoreByID(int id)
        {
            var store = context.Stores.FirstOrDefault(x => x.id == id);
            if (store != null)
                return store;
            return
                null;
        }

        public bool updateStore(Store _store)
        {
            var store = context.Stores.FirstOrDefault(x => x.id == _store.id);
            if(store!=null)
            {
                store.name = _store.name;
                context.Entry(store).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
