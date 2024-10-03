using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class MessageDetail
    {
        [Required]
        public DateTime Time { get; set; }
        
        public Guid messageOfCustomerId { get; set; }
        public MessageOfCustomer messageOfCustomer { get; set; }

        public Guid productId { get; set; }

        public Product product { get; set; }
    }
}