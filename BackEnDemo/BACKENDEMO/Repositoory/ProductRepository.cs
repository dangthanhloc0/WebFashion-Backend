using System;
using System.Collections.Generic;
using BACKENDEMO.Data;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using Microsoft.EntityFrameworkCore;


namespace BACKENDEMO.Repositoory
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppplicationDBContext _context;

        public ProductRepository(AppplicationDBContext appplicationDBContext)
        {
            _context = appplicationDBContext;
        }

        public async Task<bool> CheckProductExsit(string ProductName)
        {
             var ExsitProduct = await _context.products.FirstOrDefaultAsync(x => x.productName == ProductName);

            if(ExsitProduct == null ) {
                return false;
            }

            return true;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var ExsitProduct = await _context.products.FirstOrDefaultAsync(x => x.productName == product.productName);

            if(ExsitProduct == null ) {
                return null;
            }

            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var ExsitProduct = await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);

            if(ExsitProduct == null ) {
                return false;
            }

            _context.products.Remove(ExsitProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsByQuery(QueryProduct query)
        {
           var products = _context.products.Include(p => p.category).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.productName)){
                products = products.Where(s => s.productName.Contains(query.productName));
            }

            if(!string.IsNullOrWhiteSpace(query.price)){
                if(query.bigger == true){
                    products = products.Where(s => s.Price < int.Parse(query.price));
                }
                else{
                    products = products.Where(s => s.Price > int.Parse(query.price));
                }
                
            }

            var skipnumber = (query.pageNumber -1)  * query.pageSize;

            return await products.Skip(skipnumber).Take(query.pageSize).ToListAsync();

        }

        public async Task<Product>? GetProductById(int id)
        {
            var ExsitProduct = await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);

            if(ExsitProduct == null ) {
                return  null ;
            }
            return ExsitProduct;
        }

        public async Task<Product> UpdatePRoduct(int id, Product product)
        {
            var ExsitProduct = await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);

            if(ExsitProduct == null ) {
                return  null ;
            }

            return ExsitProduct;
        }
    }
}