using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class Discount
    {
        public int Id { get; set; }

        [Required]
        public string DetailDiscount { get; set; } = string.Empty;
        
        public int numberofpercentdiscount { get; set; } = 0;


        // Event relevant
        public int EventId { get; set; }

        public ICollection<Event> events { get; set; }

        // List DiscoutDetail
        public ICollection<DiscountDetail> DiscountDetails { get; set; }

        
    }
}