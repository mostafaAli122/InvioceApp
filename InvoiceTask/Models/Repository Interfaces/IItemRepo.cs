
using InvoiceTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Repository_Interfaces
{
    public interface IItemRepo
    {
         IEnumerable<Item> getAllItemes();
         void addItem(Item Item);
         bool updateItem(Item Item);
         bool deleteItem(int id);
         Item getItemByID(int id);
        IEnumerable<Item> getItemByStoreID(int id);
    }
}
