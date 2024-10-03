using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Libs.Entity
{
    public class AppUser : IdentityUser
    {
        public ICollection<DiscountDetail> DiscountDetails { get; set;} 
        public ICollection<Order> orders { get; set; } 
        public ICollection<MessageOfCustomer> messageOfCustomers { get; set; }

        
    }
}