using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Image;
using WebApi.Model.User;



namespace WebApi.Mappers
{
    public static class ImageMapper
    {
        public static Image ToImageProductDto(this ImageDto ImageDto)
        {
            return new Image
            {
               /* ImageUrl = ImageDto.imageUrl,*/
            
            };
        }

  

    }
}