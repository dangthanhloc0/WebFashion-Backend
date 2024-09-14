using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Mappers
{
    public static class OrdertailMapper
    {
        public static OrderDetail ToNewOrderDetail(this OrdertailDto OrdertailDto)
        {
            return new OrderDetail
            {
                quantity = OrdertailDto.quantity,

                price = OrdertailDto.price,

                productId = OrdertailDto.productId,

            }; 

        }
    }
}