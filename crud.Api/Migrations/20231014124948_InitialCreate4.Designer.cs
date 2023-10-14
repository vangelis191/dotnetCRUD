﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using crud.Data;

#nullable disable

namespace crud.Api.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20231014124948_InitialCreate4")]
    partial class InitialCreate4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("crud.Domain.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AddressID");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("crud.Domain.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailableForRent")
                        .HasColumnType("boolean");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookID");

                    b.HasIndex("OrderId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("crud.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("crud.Domain.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("integer");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("crud.Domain.OrderHistory", b =>
                {
                    b.Property<int>("OrderHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderHistoryID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("OrderHistoryID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("crud.Domain.Address", b =>
                {
                    b.HasOne("crud.Domain.Customer", "Customer")
                        .WithOne("Address")
                        .HasForeignKey("crud.Domain.Address", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("crud.Domain.Book", b =>
                {
                    b.HasOne("crud.Domain.Order", "order")
                        .WithMany("Books")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("crud.Domain.Order", b =>
                {
                    b.HasOne("crud.Domain.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("crud.Domain.OrderHistory", b =>
                {
                    b.HasOne("crud.Domain.Order", "order")
                        .WithOne("OrderHistory")
                        .HasForeignKey("crud.Domain.OrderHistory", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("crud.Domain.Customer", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("crud.Domain.Order", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("OrderHistory")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
