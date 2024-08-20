using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class MessageDetails
    {
        [Required]
        public DateTime Time { get; set; }
        
        public int messageOfCustomerId { get; set; }
        public MessageOfCustomer messageOfCustomer { get; set; }

        public int productId { get; set; }

        public Product product { get; set; }
    }
}