using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;



namespace BACKENDEMO.interfaces
{
    public interface IListImageRepository
    {
        Task<List<String>> ? GetAllListImageAsyncByProductId(int productId);

         void SaveListImageAsync(listImage listImage);
     
    }
}