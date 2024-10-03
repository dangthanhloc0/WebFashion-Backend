using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    [Table("Discounts")]
    public class Discount
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string DetailDiscount { get; set; } = string.Empty;
        
        public float numberofpercentdiscount { get; set; } = 0;


        // Event relevant
        public int EventId { get; set; }

        public ICollection<Event> events { get; set; }

        // List DiscoutDetail
        public ICollection<DiscountDetail> DiscountDetails { get; set; }

        
    }
}