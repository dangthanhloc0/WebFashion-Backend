using Libs.Data;
using Libs.Entity;


namespace Libs.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
/*        public List<Order> getOrderList();*/
    }
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
