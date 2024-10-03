
using Libs.Data;
using Libs.Entity;
using Libs.Helps;
using Microsoft.EntityFrameworkCore;


namespace Libs.Repositoory
{
    public interface IProductRepository : IRepository<Product>  
    {
        public void UpdatePRoduct(Product product, Product ExsitProduct);

    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
        public void  UpdatePRoduct(Product product,Product ExsitProduct)
        {
            ExsitProduct.Id = product.Id;   
            ExsitProduct.productName = product.productName;

            ExsitProduct.Description = product.Description;

            ExsitProduct.Image = product.Image;

            ExsitProduct.quantityStock = product.quantityStock;

            ExsitProduct.Price = product.Price;

            ExsitProduct.CategoryId = product.CategoryId;

        }

    }
}