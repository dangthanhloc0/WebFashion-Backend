using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;
using BACKENDEMO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.Data
{
    public class AppplicationDBContext :  IdentityDbContext<AppUser>
    {
        public AppplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }


       public DbSet<Stocks> stock {get; set;}

       public DbSet<Comments> comments {get; set;}

       public DbSet<UserStock> userStocks {get; set;}

        public DbSet<Product> products { get; set; }

        public DbSet<listImage> listImages { get; set; }

        public DbSet<Discount> discounts { get; set; }

        public DbSet<DiscountDetail> discountDetails { get; set; }
        
        public DbSet<ImageProduct> imageProducts { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        public DbSet<StateOrder> stateOrders { get; set; }

        public DbSet<StateTransport> stateTransports { get; set; }

        public DbSet<Notification> notifications { get; set; } 

        public DbSet<MessageOfCustomer>  messageOfCustomers { get; set; }

        public DbSet<MethodOfPayment> methodOfPayments { get; set; }

        public DbSet<Event> events { get; set; }

        public DbSet<MessageDetails> messageDetails { get; set; }
        public DbSet<NotificationDetails> notificationDetails { get; set; }

        public DbSet<Category> categories { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserStock>(x => x.HasKey(p => new {p.AppUserId, p.StockId}));
            builder.Entity<listImage>(x => x.HasKey(p => new {p.productId, p.imageId}));
            builder.Entity<DiscountDetail>(x => x.HasKey(p => new {p.AppUserId, p.DiscountId}));
            builder.Entity<OrderDetail>(x => x.HasKey(p => new {p.productId, p.OrderId}));
            builder.Entity<MessageDetails>(x => x.HasKey(p => new {p.productId, p.messageOfCustomerId}));
            builder.Entity<NotificationDetails>(x => x.HasKey(p => new {p.productId, p.notificationId}));


            builder.Entity<UserStock>()
                .HasOne(x => x.appUser)
                .WithMany(u => u.userStocks)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<UserStock>()
                .HasOne(x => x.Stocks)
                .WithMany(u => u.userStocks)
                .HasForeignKey(p => p.StockId);

            builder.Entity<listImage>()
                .HasOne(x => x.ImageProducts)
                .WithMany(u => u.ListImages)
                .HasForeignKey(p => p.imageId);

            builder.Entity<listImage>()
                .HasOne(x => x.products)
                .WithMany(u => u.ListImages)
                .HasForeignKey(p => p.productId);

            builder.Entity<DiscountDetail>()
                .HasOne(x => x.appUser)
                .WithMany(u=> u.DiscountDetails)
                .HasForeignKey(p=> p.AppUserId);

            builder.Entity<DiscountDetail>()
                .HasOne(x => x.discount)
                .WithMany(u => u.DiscountDetails)
                .HasForeignKey(p => p.DiscountId);

            builder.Entity<OrderDetail>()
                .HasOne(x => x.order)
                .WithMany(u => u.orderDetails)
                .HasForeignKey(p => p.OrderId);

            builder.Entity<OrderDetail>()
                .HasOne(x => x.product)
                .WithMany(u => u.orderDetails)
                .HasForeignKey(p => p.productId);

            builder.Entity<MessageDetails>()
                .HasOne(x => x.product)
                .WithMany(u => u.messageDetails)
                .HasForeignKey(p => p.productId);

            builder.Entity<MessageDetails>()
                .HasOne(x => x.messageOfCustomer)
                .WithMany(u => u.messageDetails)
                .HasForeignKey(p => p.messageOfCustomerId);

            builder.Entity<NotificationDetails>()
                .HasOne(x => x.product)
                .WithMany(u => u.notificationDetails)
                .HasForeignKey(p => p.productId);

            builder.Entity<NotificationDetails>()
                .HasOne(x => x.notification)
                .WithMany(u => u.notificationDetails)
                .HasForeignKey(p => p.notificationId);
                
                
            List<IdentityRole> roles  = new List<IdentityRole>{
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

          
        }

    }
}