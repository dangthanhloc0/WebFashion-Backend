
using Libs.Data;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;

namespace Libs.interfaces
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

    }
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

    }
}