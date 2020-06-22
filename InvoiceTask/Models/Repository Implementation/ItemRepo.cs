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
    public class ItemRepo : IItemRepo
    {
        private readonly ApplicationDbContext context;

        public ItemRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void addItem(Item Item)
        {
            context.Add(Item);
            context.SaveChanges();
        }

        public bool deleteItem(int id)
        {
            var item = context.Items.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                context.Items.Remove(item);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Item> getAllItemes()
        {
            return context.Items.Include(x=>x.Store).ToList();

        }

        public Item getItemByID(int id)
        {
            var item = context.Items.FirstOrDefault(x => x.id == id);
            if (item != null)
                return item;
            return
                null;
        }
        public IEnumerable<Item> getItemByStoreID(int id)
        {
            var item = context.Items.Where(x => x.storeId == id).Select(x => x).ToList();
            if (item != null)
                return item;
            return
                null;
        }
        public bool updateItem(Item Item)
        {
            var item = context.Items.FirstOrDefault(x => x.id == Item.id);
            if (item != null)
            {
                item.name = Item.name;
                item.price = Item.price;
                item.storeId = Item.storeId;
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
