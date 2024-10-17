
using Libs.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Libs
{
    public class ApplicationDbContext :  IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Product> products { get; set; }

        public DbSet<listImage> listImages { get; set; }

        public DbSet<Discount> discounts { get; set; }

        public DbSet<DiscountDetail> discountDetails { get; set; }

        public DbSet<Image> images { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        public DbSet<StateOrder> stateOrders { get; set; }

        public DbSet<StateTransport> stateTransports { get; set; }

        public DbSet<Notification> notifications { get; set; }

        public DbSet<MessageOfCustomer> messageOfCustomers { get; set; }

        public DbSet<MethodOfPayment> methodOfPayments { get; set; }

        public DbSet<Event> events { get; set; }

        public DbSet<MessageDetail> messageDetails { get; set; }
        public DbSet<NotificationDetail> notificationDetails { get; set; }

        public DbSet<Category> categories { get; set; }
        public DbSet<SizeDetail> sizeDetails { get; set; }  



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<listImage>(x => x.HasKey(p => new { p.productId, p.imageId }));
            builder.Entity<DiscountDetail>(x => x.HasKey(p => new { p.AppUserId, p.DiscountId }));
            builder.Entity<OrderDetail>(x => x.HasKey(p => new { p.Id, p.OrderId, p.productId }));
            // Configures auto-increment
            builder.Entity<OrderDetail>().Property(p => p.Id).ValueGeneratedOnAdd(); 
            builder.Entity<MessageDetail>(x => x.HasKey(p => new { p.productId, p.messageOfCustomerId }));
            builder.Entity<NotificationDetail>(x => x.HasKey(p => new { p.productId, p.notificationId }));
            builder.Entity<Image>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<SizeDetail>(x => x.HasKey(p => new { p.sizeId, p.ProductId }));



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
                .WithMany(u => u.DiscountDetails)
                .HasForeignKey(p => p.AppUserId);

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

            builder.Entity<MessageDetail>()
                .HasOne(x => x.product)
                .WithMany(u => u.messageDetails)
                .HasForeignKey(p => p.productId);

            builder.Entity<MessageDetail>()
                .HasOne(x => x.messageOfCustomer)
                .WithMany(u => u.messageDetails)
                .HasForeignKey(p => p.messageOfCustomerId);

            builder.Entity<NotificationDetail>()
                .HasOne(x => x.product)
                .WithMany(u => u.notificationDetails)
                .HasForeignKey(p => p.productId);

            builder.Entity<NotificationDetail>()
                .HasOne(x => x.notification)
                .WithMany(u => u.notificationDetails)
                .HasForeignKey(p => p.notificationId);

            builder.Entity<SizeDetail>()
                .HasOne(x => x.size)
                .WithMany(u => u.sizeDetails)
                .HasForeignKey(p => p.sizeId);


            builder.Entity<SizeDetail>()
                .HasOne(x => x.product)
                .WithMany(u => u.sizeDetails)
                .HasForeignKey(p => p.ProductId);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            List<Size> sizes = new List<Size> {
                 new Size
                 {
                    sizeName = "XS",
                 },
                 new Size
                 {
                    sizeName = "S",
                 },
                 new Size
                 {
                    sizeName = "M"
                 } ,
                 new Size
                 {
                    sizeName = "L",
                 },
                  new Size
                 {
                    sizeName = "XL",
                 },
                 new Size
                 {
                    sizeName = "XXL",
                 },
                 
            };


            builder.Entity<IdentityRole>().HasData(roles);






        }

    }
}