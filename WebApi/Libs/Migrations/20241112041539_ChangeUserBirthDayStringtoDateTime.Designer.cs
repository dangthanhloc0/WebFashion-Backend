﻿// <auto-generated />
using System;
using Libs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Libs.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241112041539_ChangeUserBirthDayStringtoDateTime")]
    partial class ChangeUserBirthDayStringtoDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Libs.Entity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("birthDay")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Libs.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Libs.Entity.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetailDiscount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<float>("numberofpercentdiscount")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Libs.Entity.DiscountDetail", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppUserId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("discountDetails");
                });

            modelBuilder.Entity("Libs.Entity.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("operationEvent")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("events");
                });

            modelBuilder.Entity("Libs.Entity.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageProducts");
                });

            modelBuilder.Entity("Libs.Entity.MessageDetail", b =>
                {
                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("messageOfCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("productId", "messageOfCustomerId");

                    b.HasIndex("messageOfCustomerId");

                    b.ToTable("messageDetails");
                });

            modelBuilder.Entity("Libs.Entity.MessageOfCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MessageOfCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("appUserId");

                    b.ToTable("messageOfCustomers");
                });

            modelBuilder.Entity("Libs.Entity.MethodOfPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("methodOfPayments");
                });

            modelBuilder.Entity("Libs.Entity.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("Libs.Entity.NotificationDetail", b =>
                {
                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("notificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("productId", "notificationId");

                    b.HasIndex("notificationId");

                    b.ToTable("notificationDetails");
                });

            modelBuilder.Entity("Libs.Entity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("methodOfPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("stateOrderId")
                        .HasColumnType("int");

                    b.Property<int>("stateTransportId")
                        .HasColumnType("int");

                    b.Property<float>("totalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("appUserId");

                    b.HasIndex("methodOfPaymentId");

                    b.HasIndex("stateOrderId");

                    b.HasIndex("stateTransportId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Libs.Entity.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id", "OrderId", "productId");

                    b.HasIndex("OrderId");

                    b.HasIndex("productId");

                    b.ToTable("orderDetails");
                });

            modelBuilder.Entity("Libs.Entity.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("quantityMaterial")
                        .HasColumnType("int");

                    b.Property<int>("quantitySellSucesss")
                        .HasColumnType("int");

                    b.Property<long>("quantityStock")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Libs.Entity.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("sizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("Libs.Entity.SizeDetail", b =>
                {
                    b.Property<int>("sizeId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("sizeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("sizeDetails");
                });

            modelBuilder.Entity("Libs.Entity.StateOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("stateOrders");
                });

            modelBuilder.Entity("Libs.Entity.StateTransport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("stateTransports");
                });

            modelBuilder.Entity("Libs.Entity.listImage", b =>
                {
                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("imageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("productId", "imageId");

                    b.HasIndex("imageId");

                    b.ToTable("listImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "91cf7211-0cc3-4943-9fe0-9c7d9eed35c6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "6cb9eb01-e72e-43c7-a39c-c1d4b8aeaf21",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Libs.Entity.DiscountDetail", b =>
                {
                    b.HasOne("Libs.Entity.AppUser", "appUser")
                        .WithMany("DiscountDetails")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.Discount", "discount")
                        .WithMany("DiscountDetails")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("appUser");

                    b.Navigation("discount");
                });

            modelBuilder.Entity("Libs.Entity.Event", b =>
                {
                    b.HasOne("Libs.Entity.Discount", "discounts")
                        .WithMany("events")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("discounts");
                });

            modelBuilder.Entity("Libs.Entity.MessageDetail", b =>
                {
                    b.HasOne("Libs.Entity.MessageOfCustomer", "messageOfCustomer")
                        .WithMany("messageDetails")
                        .HasForeignKey("messageOfCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.Product", "product")
                        .WithMany("messageDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("messageOfCustomer");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Libs.Entity.MessageOfCustomer", b =>
                {
                    b.HasOne("Libs.Entity.AppUser", "appUser")
                        .WithMany("messageOfCustomers")
                        .HasForeignKey("appUserId");

                    b.Navigation("appUser");
                });

            modelBuilder.Entity("Libs.Entity.NotificationDetail", b =>
                {
                    b.HasOne("Libs.Entity.Notification", "notification")
                        .WithMany("notificationDetails")
                        .HasForeignKey("notificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.Product", "product")
                        .WithMany("notificationDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("notification");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Libs.Entity.Order", b =>
                {
                    b.HasOne("Libs.Entity.AppUser", "appUser")
                        .WithMany("orders")
                        .HasForeignKey("appUserId");

                    b.HasOne("Libs.Entity.MethodOfPayment", "methodOfPayment")
                        .WithMany("order")
                        .HasForeignKey("methodOfPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.StateOrder", "stateOrder")
                        .WithMany("orders")
                        .HasForeignKey("stateOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.StateTransport", "stateTransport")
                        .WithMany("orders")
                        .HasForeignKey("stateTransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("appUser");

                    b.Navigation("methodOfPayment");

                    b.Navigation("stateOrder");

                    b.Navigation("stateTransport");
                });

            modelBuilder.Entity("Libs.Entity.OrderDetail", b =>
                {
                    b.HasOne("Libs.Entity.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.Product", "product")
                        .WithMany("orderDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Libs.Entity.Product", b =>
                {
                    b.HasOne("Libs.Entity.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Libs.Entity.SizeDetail", b =>
                {
                    b.HasOne("Libs.Entity.Product", "product")
                        .WithMany("sizeDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.Size", "size")
                        .WithMany("sizeDetails")
                        .HasForeignKey("sizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("size");
                });

            modelBuilder.Entity("Libs.Entity.listImage", b =>
                {
                    b.HasOne("Libs.Entity.Image", "ImageProducts")
                        .WithMany("ListImages")
                        .HasForeignKey("imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.Product", "products")
                        .WithMany("ListImages")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageProducts");

                    b.Navigation("products");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Libs.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Libs.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libs.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Libs.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Libs.Entity.AppUser", b =>
                {
                    b.Navigation("DiscountDetails");

                    b.Navigation("messageOfCustomers");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("Libs.Entity.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Libs.Entity.Discount", b =>
                {
                    b.Navigation("DiscountDetails");

                    b.Navigation("events");
                });

            modelBuilder.Entity("Libs.Entity.Image", b =>
                {
                    b.Navigation("ListImages");
                });

            modelBuilder.Entity("Libs.Entity.MessageOfCustomer", b =>
                {
                    b.Navigation("messageDetails");
                });

            modelBuilder.Entity("Libs.Entity.MethodOfPayment", b =>
                {
                    b.Navigation("order");
                });

            modelBuilder.Entity("Libs.Entity.Notification", b =>
                {
                    b.Navigation("notificationDetails");
                });

            modelBuilder.Entity("Libs.Entity.Order", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("Libs.Entity.Product", b =>
                {
                    b.Navigation("ListImages");

                    b.Navigation("messageDetails");

                    b.Navigation("notificationDetails");

                    b.Navigation("orderDetails");

                    b.Navigation("sizeDetails");
                });

            modelBuilder.Entity("Libs.Entity.Size", b =>
                {
                    b.Navigation("sizeDetails");
                });

            modelBuilder.Entity("Libs.Entity.StateOrder", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Libs.Entity.StateTransport", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
