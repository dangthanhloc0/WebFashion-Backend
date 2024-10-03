using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class DiscountDetail
    {
        public string AppUserId { get; set; }

        public Guid DiscountId { get; set; }

        public AppUser appUser { get; set; }

        public Discount discount { get; set; }

        
    }
}