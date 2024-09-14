using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;



namespace BACKENDEMO.interfaces
{
    public interface IListImageRepository
    {
        Task<List<listImage>> GetAllListImageAsyncByProductId(int productId);

        Task<bool> SaveListImageAsync(listImage listImage);
     
    }
}