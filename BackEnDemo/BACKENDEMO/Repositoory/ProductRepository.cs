using System;
using System.Collections.Generic;
using BACKENDEMO.Controllers;
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
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AppplicationDBContext appplicationDBContext, ILogger<ProductRepository> logger)
        {
            _context = appplicationDBContext;
            _logger  = logger;
        }

        public async Task<Boolean> CheckProductExsitByName(string ProductName)
        {
             return await _context.products.AnyAsync(x => x.productName == ProductName);
        }

        public async Task<Product> CreateProduct(Product product)
        {
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

            try
            {
                _context.products.Remove(ExsitProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Can't delete product");
                return false;
            }

            return true;
        }

        public async Task<List<Product>> GetAllProductsByQuery(QueryProduct query)
        {
            var products = _context.products.Include(p => p.category).AsQueryable();

            if(products == null)
            {
                return null;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(query.productName))
                    {
                        products = products.Where(s => s.productName.Contains(query.productName));
                    }

                    if (query.IsDecsendingByPrice != null)
                    {
                        if (query.IsDecsendingByPrice == true)
                        {
                            products = products.OrderByDescending(p => p.Price);
                        }
                        else
                        {
                            products = products.OrderBy(p => p.Price);
                        }
                    }

                    if (query.categoryId != 0)
                    {
                        products = products.Where(p => p.CategoryId == query.categoryId);
                    }
                }catch(Exception ex)
                {
                    _logger.LogError(ex,"Query faild");
                    return null;
                }
            }


            var skipnumber = (query.pageNumber -1)  * query.pageSize;
            // pageNumber=2
            // pageSize=3
            // => skipnumber =3
            // products {1 , 10, 32, 4, ,5 }=> skipnumber=3 , pageSize=3
            //  products.Skip(skipnumber).Take(query.pageSize).ToListAsync();
            // => products {4, ,5, "null"}

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

        public async Task<Boolean> UpdatePRoduct(int id, Product product)
        {
            var ExsitProduct = await _context.products.FirstOrDefaultAsync(x => x.ProductId == id);

            if(ExsitProduct == null ) {
                return  false ;
            }
            try
            {
                ExsitProduct.productName = product.productName;

                ExsitProduct.Description = product.Description;

                ExsitProduct.Image = product.Image;

                ExsitProduct.quantityStock = product.quantityStock;

                ExsitProduct.Price = product.Price;

                ExsitProduct.CategoryId = product.CategoryId;

                _context.products.Update(ExsitProduct);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false ;  
            }
            return true;
        }
    }
}