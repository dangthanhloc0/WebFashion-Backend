
using Libs.Data;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;


namespace Libs.Repositoory
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<List<String>> GetAllListImageAsyncByProductId(Guid productId);
    }
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
        public async Task<List<String>> GetAllListImageAsyncByProductId(Guid productId)
        {
            var ListImage = new List<String>();
            var resutl = await _dbcontext.listImages.Include(p =>p.ImageProducts).Where(p => p.productId == productId).ToListAsync();
            if (resutl.Count <= 0)
            {
                return ListImage;
            }
            foreach (var image in resutl)
            {
                ListImage.Add(image.ImageProducts.ImageUrl);
            }

            return ListImage;
        }

    }
}