using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;


namespace BACKENDEMO.interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCatetgoryAsync();

        Task<Category>? CreateCategory(NewCategory newCategory);

        Task<bool> DeleteCategory(int id);

        Task<Category> UpdateCategory(int id, NewCategory newCategory);

        Task<Category>? GetCategoryById(int id);
     
    }
}