using Libs.Data;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface ISizeRepository : IRepository<SizeDetail>
    {

    }
    public class SizeRepository : RepositoryBase<SizeDetail>, ISizeRepository
    {
        public SizeRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
