﻿// <auto-generated />
using System;
using InvoiceTask.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceTask.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200621130531_update model classes3")]
    partial class updatemodelclasses3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceTask.Models.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceNO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Net")
                        .HasColumnType("money");

                    b.Property<int>("Storeid")
                        .HasColumnType("int");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("money");

                    b.Property<decimal>("Total")
                        .HasColumnType("money");

                    b.HasKey("InvoiceNO");

                    b.HasIndex("Storeid");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceTask.Models.Entities.InvoiceItems", b =>
                {
                    b.Property<int>("invoiceItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("money");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Net")
                        .HasColumnType("money");

                    b.Property<decimal>("Total")
                        .HasColumnType("money");

                    b.Property<int>("invoiceId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("unit")
                        .HasColumnType("int");

                    b.HasKey("invoiceItemsId");

                    b.HasIndex("ItemId");

                    b.HasIndex("invoiceId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("InvoiceTask.Models.Entities.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<decimal>("price")
                        .HasColumnType("money");

                    b.Property<int>("storeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("storeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("InvoiceTask.Models.Entities.Store", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("InvoiceTask.Models.Entities.Invoice", b =>
                {
                    b.HasOne("InvoiceTask.Models.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("Storeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvoiceTask.Models.Entities.InvoiceItems", b =>
                {
                    b.HasOne("InvoiceTask.Models.Entities.Item", "Items")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceTask.Models.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("invoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvoiceTask.Models.Entities.Item", b =>
                {
                    b.HasOne("InvoiceTask.Models.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("storeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
