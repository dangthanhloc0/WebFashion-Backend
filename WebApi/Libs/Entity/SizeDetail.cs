using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class SizeDetail
    {
        public Guid ProductId { get; set; }

        public int sizeId { get; set; }

        public Product ? product { get; set; }    
        public Size ? size { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
