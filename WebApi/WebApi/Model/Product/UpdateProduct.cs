using Libs.Entity;
using Libs.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.SizeDetail;


namespace WebApi.Model.Product
{
    public class UpdateProduct
    {
        public Guid Id { get; set; }
        public string productName { get; set; } = string.Empty;
        
        public string Description {get; set;} =  string.Empty;

        public string Image {get; set;} = string.Empty;

        public int quantityStock { get; set; } = 0;

        public float Price { get; set; } =0;

        public Guid CategoryId { get; set; }

        public List<String>? imageUrls { get; set; }

       public List<SizeDetailUpdate> sizes { get; set; }

    }
}