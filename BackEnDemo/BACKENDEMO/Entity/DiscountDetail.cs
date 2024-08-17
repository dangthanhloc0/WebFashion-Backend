using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class DiscountDetail
    {
        public int AppUserId { get; set; }

        public int DiscountId { get; set; }

        public AppUser appUser { get; set; }

        public Discount discount { get; set; }

        
    }
}