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
    public class ImageRepository : IImageRepository
    {

        private readonly AppplicationDBContext _context;

        public ImageRepository(AppplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ImageProduct>> GetAllImageAsync()
        {
            return await _context.imageProducts.ToListAsync();
        }

        public async Task<int> SaveImageAsync(ImageProduct imageProduct)
        {
            try
            {
                await _context.imageProducts.AddAsync(imageProduct);
                await _context.SaveChangesAsync();
                return imageProduct.ImageProductId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}