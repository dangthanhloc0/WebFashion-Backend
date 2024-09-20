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
    public class ListImageRepository :IListImageRepository
    {

        private readonly AppplicationDBContext _context;

        public ListImageRepository(AppplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<String>> ?  GetAllListImageAsyncByProductId(int productId)
        {
            var ListImage = new List<String>();
            var resutl = await _context.listImages.Include(p => p.ImageProducts).Where(p => p.productId == productId).ToListAsync();
            if(resutl.Count <= 0) {
                return ListImage;   
            }         
           foreach (var image in resutl) {
                ListImage.Add(image.ImageProducts.ImageUrl);
           }

           return ListImage;    
        }

        public async Task<bool> SaveListImageAsync(listImage listImage)
        {
            try
            {
                await _context.listImages.AddAsync(listImage);  
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}