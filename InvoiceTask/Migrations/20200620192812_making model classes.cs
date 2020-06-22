using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTask.Migrations
{
    public partial class makingmodelclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "stores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    invoiceItemsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    unit = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: false),
                    Net = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.invoiceItemsId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceNO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    Storeid = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Net = table.Column<decimal>(type: "money", nullable: false),
                    invoiceItemsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceNO);
                    table.ForeignKey(
                        name: "FK_Invoice_stores_Storeid",
                        column: x => x.Storeid,
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceItems_invoiceItemsId",
                        column: x => x.invoiceItemsId,
                        principalTable: "InvoiceItems",
                        principalColumn: "invoiceItemsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 10, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    storeId = table.Column<int>(nullable: false),
                    invoiceItemsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_InvoiceItems_invoiceItemsId",
                        column: x => x.invoiceItemsId,
                        principalTable: "InvoiceItems",
                        principalColumn: "invoiceItemsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_stores_storeId",
                        column: x => x.storeId,
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Storeid",
                table: "Invoice",
                column: "Storeid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_invoiceItemsId",
                table: "Invoice",
                column: "invoiceItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_invoiceItemsId",
                table: "Item",
                column: "invoiceItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_storeId",
                table: "Item",
                column: "storeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "stores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
