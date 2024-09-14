using BACKENDEMO.Data;
using BACKENDEMO.Dtos;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;

using Microsoft.EntityFrameworkCore;


namespace BACKENDEMO.Repositoory
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppplicationDBContext _context;
        private readonly OrderDetailRepository _ordertail;
        public OrderRepository(AppplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order>? CreateOrder(Order order)
        {
            if (order == null)
            {
                return null;
            }
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();  
            return order;
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            return await _context.orders.ToListAsync();
        }

        public async Task<List<Order>>? GetAllOrderByUserId(String IdUser)
        {
            var result = await _context.orders.Include(x => x.stateOrder).Include(p => p.stateTransport)
                        .Include(t => t.methodOfPayment).Where(c => c.AppUserId == IdUser).ToListAsync();
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }


    }