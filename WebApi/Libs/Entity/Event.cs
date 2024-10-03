using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Event
    {
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime operationEvent { get; set; } = DateTime.Now;

        public Guid DiscountId { get; set; }

        public Discount discounts { get; set; }



    }
}