using Libs.Entity;
using Libs.interfaces;
using Libs.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class SellService
    {
        private ApplicationDbContext dbContext;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;

        public SellService(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
            this.orderRepository = new OrderRepository(this.dbContext);
            this.orderDetailRepository = new OrderDetailRepository(this.dbContext);
        }
        public void Save() {
            this.dbContext.SaveChanges();
        }
        public async Task<List<Order>> getOrderList() {

            return await orderRepository.GetAllAsync();
      
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailByOrderId(Guid orderId)
        {
            return await dbContext.orderDetails.Include(p => p.product).Where(p => p.OrderId == orderId).ToListAsync();
        }



        public String CreateBillSellProdcut(IEnumerable<OrderDetail> listOrderDetial, Order order)
        {
            try
            {
                var IdOrder = Guid.NewGuid();   
                order.Id = IdOrder;
                orderRepository.Add(order);
                float totalPrice = 0;
                foreach (OrderDetail orderDetail in listOrderDetial)
                {
                    orderDetail.OrderId = IdOrder;
                    orderDetailRepository.Add(orderDetail);
                    totalPrice += orderDetail.quantity * orderDetail.price;
                }
                order.totalPrice = totalPrice;
            }catch(Exception e)
            {
                return e.Message;
            }

            Save();
            return "Ok";
        }

        public void UpdateOrderDetailByUserId(int OrderId, int ProductId, OrderDetail orderDetail)
        {
/*            var CheckExsit = _dbcontext.orderDetail.FirstOrDefault(p => p.OrderId == OrderId && p.productId == ProductId);
            CheckExsit.quantity = orderDetail.quantity;
            CheckExsit.price = orderDetail.price;*/
        }

        public async Task<List<Order>> GetAllOrderByUserId(String userId)
        {
            var result = await dbContext.orders.Include(x => x.stateOrder).Include(p => p.stateTransport)
                               .Include(t => t.methodOfPayment).Where(c => c.UserId == userId).ToListAsync();
            if (result == null)
            {
                return null;
            }

            return result;
        }

   



    }

}
