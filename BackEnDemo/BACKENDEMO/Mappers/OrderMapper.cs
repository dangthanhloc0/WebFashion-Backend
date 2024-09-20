using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                Date = order.Date,
                totalPrice = 0,
                Address = order.Address,
                stateOrder = order.stateOrder.State,
                stateTransport = order.stateTransport.state,

    };
        }

        public static Order ToNewOrder(this newOrder newOrder,String UserId)
        {
            return new Order
            {
                Date = DateTime.Now,
                totalPrice = 0,
                Address = newOrder.Address,
                AppUserId = UserId,
                methodOfPaymentId = newOrder.methodOfPaymentId,
                stateOrderId = newOrder.stateOrderId,
                stateTransportId = newOrder.stateTransportId,


            };
        }

        public static Category ToCategory(this NewCategory newCategory)
        {
            return new Category
            {
                CategorName = newCategory.CategorName,

            };
        }

    }
}