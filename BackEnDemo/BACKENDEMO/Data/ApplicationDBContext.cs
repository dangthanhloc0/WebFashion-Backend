using System;
using System.Collections.Generic;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserStock>(x => x.HasKey(p => new {p.AppUserId, p.StockId}));

            builder.Entity<UserStock>()
                .HasOne(x => x.appUser)
                .WithMany(u => u.userStocks)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<UserStock>()
                .HasOne(x => x.Stocks)
                .WithMany(u => u.userStocks)
                .HasForeignKey(p => p.StockId);


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