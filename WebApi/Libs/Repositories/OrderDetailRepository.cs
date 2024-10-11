
using Libs.Data;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;

namespace Libs.interfaces
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task<List<OrderDetail>> GetAllOrderDetailByOrderId(Guid orderId);
        
    }
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
        public async Task<List<OrderDetail>> GetAllOrderDetailByOrderId(Guid orderId)
        {
            return await _dbcontext.orderDetails.Include(p => p.product).Where(p => p.OrderId == orderId).ToListAsync();
        }

    }
}