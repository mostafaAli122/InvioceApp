using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTask.Migrations
{
    public partial class updatemodelclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_InvoiceItems_invoiceItemsId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_InvoiceItems_invoiceItemsId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_invoiceItemsId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_invoiceItemsId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "invoiceItemsId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "invoiceItemsId",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ItemId",
                table: "InvoiceItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_invoiceId",
                table: "InvoiceItems",
                column: "invoiceId");

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Item_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoice_invoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_invoiceId",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<int>(
                name: "invoiceItemsId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "invoiceItemsId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_invoiceItemsId",
                table: "Item",
                column: "invoiceItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_invoiceItemsId",
                table: "Invoice",
                column: "invoiceItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_InvoiceItems_invoiceItemsId",
                table: "Invoice",
                column: "invoiceItemsId",
                principalTable: "InvoiceItems",
                principalColumn: "invoiceItemsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_InvoiceItems_invoiceItemsId",
                table: "Item",
                column: "invoiceItemsId",
                principalTable: "InvoiceItems",
                principalColumn: "invoiceItemsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
