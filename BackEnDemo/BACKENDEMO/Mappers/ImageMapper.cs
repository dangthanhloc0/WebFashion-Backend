using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Mappers
{
    public static class ImageMapper
    {
        public static ImageProduct ToImageProductDto(this ImageDto ImageDto)
        {
            return new ImageProduct
            {
               /* ImageUrl = ImageDto.imageUrl,*/
            
            };
        }

  

    }
}