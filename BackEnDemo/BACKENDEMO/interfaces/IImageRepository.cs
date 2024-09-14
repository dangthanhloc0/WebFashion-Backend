using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;



namespace BACKENDEMO.interfaces
{
    public interface IImageRepository
    {
        Task<List<ImageProduct>> GetAllImageAsync();

        Task<int> SaveImageAsync(ImageProduct imageProduct);
     
    }
}