using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Product;
using BACKENDEMO.Entity;



namespace BACKENDEMO.Mappers
{
    public static class ProductMapper
    {
       public static ProductDto  ToProductDto(this Product product){
            return new ProductDto
            {
                ProductId = product.ProductId,

                productName = product.productName,
        
                Description = product.Description,

                Image       = product.Image,

                quantityStock = product.quantityStock,

                Price = product.Price,

                category = product.category,

                // ListImages = product.ListImages.ToList(),

                // orderDetails = product.orderDetails.ToList(),

                // messageDetails = product.messageDetails.ToList(),
                
                // notificationDetails = product.notificationDetails.ToList(),

            };
        }

        public static Product  ToCreateNewProductDto(this NewProduct newproduct){
            return new Product
            {
                productName = newproduct.productName,
        
                Description = newproduct.Description,

                Image       = newproduct.Image,

                quantityStock = newproduct.quantityStock,

                Price = newproduct.Price,

                category = newproduct.category,

                // ListImages = product.ListImages.ToList(),

                // orderDetails = product.orderDetails.ToList(),

                // messageDetails = product.messageDetails.ToList(),
                
                // notificationDetails = product.notificationDetails.ToList(),

            };
        }
    }
}