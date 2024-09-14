using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;


namespace BACKENDEMO.interfaces
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppplicationDBContext _context;

        public OrderDetailRepository(AppplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDetail>>? GetAllOrderDetailByUserId(int  OrderId)
        {
            var result = await _context.orderDetails.Include(x => x.product).
                            Where(p => p.OrderId == OrderId).ToListAsync();
            if(result.Count == 0)
            {
                return null;
            }

            return result;
        }



        public async Task<bool> CreateListOrderDetail(ICollection<OrderDetail> ListOrderdetial, Order order
            )
        {
            if(ListOrderdetial.Count <= 0)
            {
                return false;
            }
            try
            {
                foreach (var item in ListOrderdetial)
                {
                    item.OrderId = order.Id;               
                }
                await _context.orderDetails.AddRangeAsync(ListOrderdetial);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
                       
            return true;
        }

        public async Task<bool> UpdateOrderDetailByUserId(int OrderId,int ProductId, OrderDetail orderDetail)
        {
            var CheckExsit = await _context.orderDetails.FirstOrDefaultAsync(p => p.OrderId == OrderId && p.productId == ProductId);
            if (CheckExsit == null)
            {
                // không tồn tại orderdetail với OrderId và ProductId
                return false;
            }

            CheckExsit.quantity = orderDetail.quantity;
            CheckExsit.price = orderDetail.price;
            await _context.SaveChangesAsync();
            //update thành công
            return true;
        }



        public Task<bool> UpdateOrderDetailByUserId(Order order, OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        Task<OrderDetail>? IOrderDetailRepository.GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}