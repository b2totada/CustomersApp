﻿// <auto-generated />
using CustomersApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomersApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221128020808_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CustomersApp.Shared.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Address = "Budapest",
                            CategoryId = 1,
                            FirstName = "Elso",
                            LastName = "Ember",
                            Tel = "0123456"
                        },
                        new
                        {
                            Id = "2",
                            Address = "Szeged",
                            CategoryId = 2,
                            FirstName = "Masodik",
                            LastName = "Emberke",
                            Tel = "987654"
                        });
                });

            modelBuilder.Entity("CustomersApp.Shared.CustomerCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lakossagi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ceges"
                        });
                });

            modelBuilder.Entity("CustomersApp.Shared.Customer", b =>
                {
                    b.HasOne("CustomersApp.Shared.CustomerCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
