using Libs.Data;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;

namespace Libs.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

     
    }
}