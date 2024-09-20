using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;

namespace BACKENDEMO.interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsByQuery(QueryProduct query);

        Task<Product>? CreateProduct(Product product);

        Task<bool> DeleteProduct(int id);

        Task<Boolean> UpdatePRoduct(int id, Product product);

        Task<Product> GetProductById(int id);

        Task<Boolean> CheckProductExsitByName(string ProductName);


 

    
    }
}