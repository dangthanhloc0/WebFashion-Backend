using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        public string sizeName { get; set; } = string.Empty;
 

        public ICollection<SizeDetail> ? sizeDetails { get; set; }

        public ICollection<OrderDetail> ? orderDetails { get; set; }    

    }
}