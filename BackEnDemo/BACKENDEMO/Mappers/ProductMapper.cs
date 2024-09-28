using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Dtos.Product;
using BACKENDEMO.Entity;



namespace BACKENDEMO.Mappers
{
    public static class ProductMapper
    {
       public static ProductDto ToProductDto(this Product product, List<string> listImages){
            return new ProductDto
            {
                ProductId = product.ProductId,

                productName = product.productName,

                Description = product.Description,

                Image = product.Image,

                quantityStock = product.quantityStock,

                Price = product.Price,

                categoryName = product.category.CategorName,

                ListStringImage = listImages,

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

                CategoryId = newproduct.CategoryId,

                // ListImages = product.ListImages.ToList(),

                // orderDetails = product.orderDetails.ToList(),

                // messageDetails = product.messageDetails.ToList(),
                
                // notificationDetails = product.notificationDetails.ToList(),

            };
        }

        public static Product ToUpdateProduct(this UpdateProduct updateProduct){
            return new Product
            {
                productName = updateProduct.productName,
        
                Description = updateProduct.Description,

                Image       = updateProduct.Image,

                quantityStock = updateProduct.quantityStock,

                Price = updateProduct.Price,

                CategoryId = updateProduct.CategoryId,

                // ListImages = product.ListImages.ToList(),

                // orderDetails = product.orderDetails.ToList(),

                // messageDetails = product.messageDetails.ToList(),
                
                // notificationDetails = product.notificationDetails.ToList(),

            };
        }

        public static ProductOrder toProductOrder (this Product product,int quantity)
        {
            return new ProductOrder
            {
                ProductId = product.ProductId,
                productName = product.productName,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Quantity = quantity,
            };
        }
    }
}