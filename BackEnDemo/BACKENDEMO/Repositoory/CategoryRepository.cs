using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BACKENDEMO.Repositoory
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppplicationDBContext _context;

        public CategoryRepository(AppplicationDBContext context)
        {
            _context = context ;
        }

        public async Task<Category>? CreateCategory(NewCategory newCategory)
        {
            var result = await _context.categories.FirstOrDefaultAsync(x => x.CategorName == newCategory.CategorName);
            if (result == null)
            {
                await _context.categories.AddAsync(newCategory.ToCategory());   
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await _context.categories.FindAsync(id);
           if(result == null)
            {
                return false;
            }
           _context.categories.Remove(result);
           await _context.SaveChangesAsync();
            return true;
                
        }

        public async Task<List<Category>> GetAllCatetgoryAsync()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category>? GetCategoryById(int id)
        {
            var result = await _context.categories.FindAsync(id);
            return result == null ? null : result;

        }

        public async Task<Category>? UpdateCategory(int id, NewCategory newCategory)
        {
            var result = await GetCategoryById(id);
            if (result == null)
            {
                return null;
            }
            result.CategorName = newCategory.CategorName;
            _context.categories.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }

    }
}