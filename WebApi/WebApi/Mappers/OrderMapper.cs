



using Libs.Entity;
using WebApi.Model.User;

namespace WebApi.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order )
        {
            return new OrderDto
            {
                Id = order.Id,  
                Date = order.Date,
                totalPrice = order.totalPrice,
                Address = order.Address,
                Phone = order.Phone,
                stateOrder = order.stateOrder.State,
                stateTransport = order.stateTransport.state,
                methodOfPayment = order.methodOfPayment.MethodName,
    };
        }

        public static Order ToNewOrder(this newOrder newOrder,String UserId,float price)
        {
            return new Order
            {
                Date = DateTime.Now,
                totalPrice = price,
                Address = newOrder.Address,
                UserId = UserId,
                methodOfPaymentId = newOrder.methodOfPaymentId,
                stateOrderId = newOrder.stateOrderId,
                stateTransportId = newOrder.stateTransportId,
                Phone = newOrder.Phone,


            };
        }


    }
}