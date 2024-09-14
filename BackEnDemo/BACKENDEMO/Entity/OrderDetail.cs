using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        [Range(0,10000)]
        public int quantity {get; set;}

        [Range(0,100000000)]
        public double price { get; set; }

        public int OrderId { get; set; }

        public Order order { get; set; }

        public int productId { get; set; }
        public Product product { get; set; }
   

        
    }
}