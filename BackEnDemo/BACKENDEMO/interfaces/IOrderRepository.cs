using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;


namespace BACKENDEMO.interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrderAsync();

        Task<Order>? CreateOrder(Order Order);

       /* Task<bool> DeleteCategory(int id);*/

       /* Task<Category> UpdateCategory(int id, NewCategory newCategory);*/

        Task<List<Order>>? GetAllOrderByUserId(String IdUser);
     
    }
}