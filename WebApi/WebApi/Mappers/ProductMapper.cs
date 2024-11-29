
using Libs.Entity;
using WebApi.Model.Product;
using WebApi.Model.SizeDetail;



namespace WebApi.Mappers
{
    public static class ProductMapper
    {
       public static product toProduct(this Product product, List<string>? listImages,List<SizeDetail> sizeDetails, List<MessageDetail> messageDetails)
        {
            return new product
            {
                Id = product.Id,

                productName = product.productName,

                Description = product.Description,

                Image = product.Image,

                quantityStock = product.quantityStock,

                Price = product.Price,

                categoryName = product.category.CategorName,

                ListStringImage = listImages.ToList(),
                sizeDetails = sizeDetails.Select(s => s.toSizeDetailUi()).ToList(),

                messageDetails = messageDetails.Select(m => m.toMessageDetail()).ToList()
            };
        }

        public static product toProduct(this Product product)
        {
            return new product
            {
                Id = product.Id,

                productName = product.productName,

                Description = product.Description,

                Image = product.Image,

                quantityStock = product.quantityStock,

                Price = product.Price,

                categoryName = product.category.CategorName,
            };
        }

        public static Product  ToCreateNewProductDto(this NewProduct newproduct){
            return new Product
            {
                Id = Guid.NewGuid(),    
                productName = newproduct.productName,
        
                Description = newproduct.Description,

                Image       = newproduct.Image,

                quantityStock = newproduct.quantityStock,

                Price = newproduct.Price,

                CategoryId = newproduct.CategoryId,


            };
        }

        public static Libs.Entity.Product ToUpdateProduct(this UpdateProduct updateProduct){
            return new Libs.Entity.Product
            {
                Id = updateProduct.Id,
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
                ProductId = product.Id,
                productName = product.productName,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Quantity = quantity,
            };
        }
    }
}