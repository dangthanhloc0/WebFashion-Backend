

using Libs.Entity;
using WebApi.Model.OrderDetails;
using WebApi.Model.Sessions;
using WebApi.Model.User;

namespace WebApi.Mappers
{
    public static class OrdertailMapper
    {
        public static OrderDetail ToNewOrderDetail(this NewOrderDetail newOrderDetail)
        {
            return new OrderDetail
            {
                quantity = newOrderDetail.quantity,

                price = newOrderDetail.price,

                productId = newOrderDetail.productId,

            }; 

        }

        public static OrderDetail ToNewOrderDetail( this ItemProduct itemProduct )
        {
            return new OrderDetail
            {
                quantity = itemProduct.Quantity,

                price = itemProduct.price,

                productId = itemProduct.ProductId,
                sizeId = itemProduct.sizeId,


            };
        }


        public static OrderDetailsDto toOrderDetailsDto(this OrderDetail orderDetail)
        {
            return new OrderDetailsDto
            {
                quantity = orderDetail.quantity,

                price = orderDetail.price,

                productName = orderDetail.product.productName,

            };
        }
    }
}