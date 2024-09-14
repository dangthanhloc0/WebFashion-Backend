using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;


namespace BACKENDEMO.interfaces
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>>? GetAllOrderDetailByUserId(int OrderId);

        Task<bool> CreateListOrderDetail(ICollection<OrderDetail> ListOrderdetial,Order order);

        Task<bool> UpdateOrderDetailByUserId(Order order, OrderDetail orderDetail);


        Task<OrderDetail>? GetOrderById(int id);
     
    }
}