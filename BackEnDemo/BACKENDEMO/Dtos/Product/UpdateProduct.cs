using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Dtos.Product
{
    public class UpdateProduct
    {
        public string productName { get; set; } = string.Empty;
        
        public string Description {get; set;} =  string.Empty;

        public string Image {get; set;} = string.Empty;

        public long quantityStock { get; set; } = 0;

        public double Price { get; set; } =0;

        public int CategoryId { get; set; }

    }
}