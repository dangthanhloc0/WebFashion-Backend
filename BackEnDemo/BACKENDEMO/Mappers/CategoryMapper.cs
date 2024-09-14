using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category ){
            return new CategoryDto{
                Id = category.Id,
                CategorName = category.CategorName,
            
            };
        }

        public static Category ToCategory(this CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                CategorName = categoryDto.CategorName,

            };
        }

        public static Category ToNewCategory(this NewCategory newCategory)
        {
            return new Category
            {
                CategorName = newCategory.CategorName,

            };
        }

    }
}