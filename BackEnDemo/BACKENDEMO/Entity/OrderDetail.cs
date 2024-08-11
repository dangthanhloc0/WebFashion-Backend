using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        [Range(0,10000)]
        public int quantity {get; set;}

        [Range(0,100000000)]
        public double price { get; set; }

        

        
    }
}