using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        [Range(0,10000)]
        public int quantity {get; set;}

        [Range(0,100000000)]
        public float price { get; set; }

        public Guid OrderId { get; set; }

        public Order order { get; set; }

        public Guid productId { get; set; }
        public Product product { get; set; }

        public int sizeId { get; set; } 
        public Size ? size { get; set; }
   

        
    }
}