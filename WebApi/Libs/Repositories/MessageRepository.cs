using Libs.Data;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;

namespace Libs.Repositories
{
    public interface ImessageRepository : IRepository<MessageDetail>
    {
        
    }
    public class MessageRepository : RepositoryBase<MessageDetail>, ImessageRepository
    {
        public MessageRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

     
    }
}