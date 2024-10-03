
using Libs.Entity;
using WebApi.Model.Category;

namespace WebApi.Mappers
{
    public static class CategoryMapper
    {
        public static Category toCategory(this category category)
        {
            return new Category
            {
                Id = category.Id,
                CategorName = category.CategorName,

            };
        }

        public static category toCategory(this Category Category)
        {
            return new category
            {
                Id = Category.Id,
                CategorName = Category.CategorName,

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