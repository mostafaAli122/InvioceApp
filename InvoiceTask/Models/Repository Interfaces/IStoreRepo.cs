using InvoiceTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Repository_Interfaces
{
    public interface IStoreRepo
    {
        public IEnumerable<Store> getAllStores();
        public void addStore(Store store);
        public bool updateStore(Store store);
        public bool deleteStore(int id);
        public Store getStoreByID(int id);


    }
}
