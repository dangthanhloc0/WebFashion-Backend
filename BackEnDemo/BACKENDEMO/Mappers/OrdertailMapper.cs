using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Dtos.Sessions;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Mappers
{
    public static class OrdertailMapper
    {
        public static OrderDetail ToNewOrderDetail(this NewOrderDetail OrdertailDto)
        {
            return new OrderDetail
            {
                quantity = OrdertailDto.quantity,

                price = OrdertailDto.price,

                productId = OrdertailDto.productId,

            }; 

        }

        public static OrderDetail ToNewOrderDetail( this ItemProduct itemProduct )
        {
            return new OrderDetail
            {
                quantity = itemProduct.Quantity,

                price = itemProduct.price,

                productId = itemProduct.ProductId,

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