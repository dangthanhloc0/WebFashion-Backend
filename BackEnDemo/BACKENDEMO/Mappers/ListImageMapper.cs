using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Mappers
{
    public static class ListImageMapper
    {
        public static listImage ToListImageProductDto(this ListImageDto listImage)
        {
            return new listImage
            {
                productId = listImage.productId,
                imageId = listImage.imageId,

            };
        }

  

    }
}