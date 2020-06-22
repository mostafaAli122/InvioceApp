using InvoiceTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTask.Models.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvoiceItems>()
                .HasOne<Invoice>(s => s.Invoice);


            //modelBuilder.Entity<Invoice>().HasKey(x => x.InvoiceNO).HasName("InvoiceNO"); 
            //modelBuilder.Entity<InvoiceItems>().HasKey(x => x.invoiceItemsId).HasName("invoiceItemsId");

            //Data Seeding
            #region Data Seeding

            modelBuilder.Entity<Store>().HasData(
                   new Store { id=1,name = "Store_1" },
                   new Store { id=2,name = "Store_2" },
                   new Store { id=3,name = "Store_3" });

            modelBuilder.Entity<Item>().HasData(
                new Item { id=1,name = "item_1", price = 10, storeId = 1 },
                new Item { id=2,name = "item_2", price = 10, storeId = 1 },
                new Item { id=3,name = "item_3", price = 10, storeId = 1 },
                new Item { id=4,name = "item_4", price = 10, storeId = 2 },
                new Item { id=5,name = "item_5", price = 10, storeId = 2 },
                new Item { id=6,name = "item_6", price = 10, storeId = 2 },
                new Item { id=7,name = "item_7", price = 10, storeId = 3 },
                new Item { id=8,name = "item_8", price = 10, storeId = 3 },
                new Item { id=9,name = "item_9", price = 10, storeId = 3 },
                new Item { id=10,name = "item_10", price = 10, storeId = 3 },
                new Item { id=11,name = "item_11", price = 10, storeId = 3 }
                );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceNO = 1, InvoiceDate = new DateTime(2020, 6, 22), Storeid = 1, Total = 400, Taxes = 7, Net = 428 },
                new Invoice { InvoiceNO = 2, InvoiceDate = new DateTime(2020, 6, 22), Storeid = 2, Total = 600, Taxes = 7, Net = 642 },
                new Invoice { InvoiceNO = 3, InvoiceDate = new DateTime(2020, 6, 22), Storeid = 3, Total = 1000, Taxes = 7, Net = 1070 }
                ) ;
            modelBuilder.Entity<InvoiceItems>().HasData(
                new InvoiceItems { invoiceItemsId=1, invoiceId = 1, ItemId = 1, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=2,invoiceId = 1, ItemId = 2, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=3,invoiceId = 2, ItemId = 4, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=4,invoiceId = 2, ItemId = 5, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=5,invoiceId = 2, ItemId = 6, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=6,invoiceId = 3, ItemId = 7, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=7,invoiceId = 3, ItemId = 8, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=8,invoiceId = 3, ItemId = 9, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId=9,invoiceId = 3, ItemId = 10, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package },
                new InvoiceItems { invoiceItemsId = 10, invoiceId = 3, ItemId = 11, price = 10, quantity = 20, Total = 200, Discount = 0, Net = 200, unit = Unit.Package }
                );
            #endregion
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }

    }
}
