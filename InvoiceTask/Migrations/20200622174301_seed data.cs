using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTask.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Invoices",
            //    table: "Invoices");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_InvoiceItems",
            //    table: "InvoiceItems");

            //migrationBuilder.AddPrimaryKey(
            //    name: "InvoiceNO",
            //    table: "Invoices",
            //    column: "InvoiceNO");

            //migrationBuilder.AddPrimaryKey(
            //    name: "invoiceItemsId",
            //    table: "InvoiceItems",
            //    column: "invoiceItemsId");

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Store_1" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Store_2" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "id", "name" },
                values: new object[] { 3, "Store_3" });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceNO", "InvoiceDate", "Net", "Storeid", "Taxes", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 428m, 1, 7m, 400m },
                    { 2, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 642m, 2, 7m, 600m },
                    { 3, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1070m, 3, 7m, 1000m }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "name", "price", "storeId" },
                values: new object[,]
                {
                    { 1, "item_1", 10m, 1 },
                    { 2, "item_2", 10m, 1 },
                    { 3, "item_3", 10m, 1 },
                    { 4, "item_4", 10m, 2 },
                    { 5, "item_5", 10m, 2 },
                    { 6, "item_6", 10m, 2 },
                    { 7, "item_7", 10m, 3 },
                    { 8, "item_8", 10m, 3 },
                    { 9, "item_9", 10m, 3 },
                    { 10, "item_10", 10m, 3 },
                    { 11, "item_11", 10m, 3 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "invoiceItemsId", "Discount", "ItemId", "Net", "Total", "invoiceId", "price", "quantity", "unit" },
                values: new object[,]
                {
                    { 1, 0m, 1, 200m, 200m, 1, 10, 20, 0 },
                    { 2, 0m, 2, 200m, 200m, 1, 10, 20, 0 },
                    { 3, 0m, 4, 200m, 200m, 2, 10, 20, 0 },
                    { 4, 0m, 5, 200m, 200m, 2, 10, 20, 0 },
                    { 5, 0m, 6, 200m, 200m, 2, 10, 20, 0 },
                    { 6, 0m, 7, 200m, 200m, 3, 10, 20, 0 },
                    { 7, 0m, 8, 200m, 200m, 3, 10, 20, 0 },
                    { 8, 0m, 9, 200m, 200m, 3, 10, 20, 0 },
                    { 9, 0m, 10, 200m, 200m, 3, 10, 20, 0 },
                    { 10, 0m, 11, 200m, 200m, 3, 10, 20, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "InvoiceNO",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "invoiceItemsId",
                table: "InvoiceItems");

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "invoiceItemsId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceNO",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceNO",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceNO",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceNO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems",
                column: "invoiceItemsId");
        }
    }
}
