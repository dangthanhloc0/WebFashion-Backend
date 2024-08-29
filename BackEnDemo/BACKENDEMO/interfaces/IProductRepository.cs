using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;

namespace BACKENDEMO.interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsByQuery(QueryProduct query);

        Task<Product>? CreateProduct(Product product);

        Task<Boolean> DeleteProduct(int id);

        Task<Product>? UpdatePRoduct(int id, Product product);

        Task<Product>? GetProductById(int id);

        Task<Boolean> CheckProductExsit(string ProductName); 

    
    }
}