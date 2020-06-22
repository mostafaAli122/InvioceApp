using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTask.Migrations
{
    public partial class updatemodelclasses3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_stores_Storeid",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Item_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoice_invoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_stores_storeId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stores",
                table: "stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "stores",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Item_storeId",
                table: "Items",
                newName: "IX_Items_storeId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_Storeid",
                table: "Invoices",
                newName: "IX_Invoices_Storeid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceNO");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_invoiceId",
                table: "InvoiceItems",
                column: "invoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Stores_Storeid",
                table: "Invoices",
                column: "Storeid",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_storeId",
                table: "Items",
                column: "storeId",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_invoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Stores_Storeid",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_storeId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "stores");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_Items_storeId",
                table: "Item",
                newName: "IX_Item_storeId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_Storeid",
                table: "Invoice",
                newName: "IX_Invoice_Storeid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stores",
                table: "stores",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "InvoiceNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_stores_Storeid",
                table: "Invoice",
                column: "Storeid",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Item_ItemId",
                table: "InvoiceItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoice_invoiceId",
                table: "InvoiceItems",
                column: "invoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_stores_storeId",
                table: "Item",
                column: "storeId",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
