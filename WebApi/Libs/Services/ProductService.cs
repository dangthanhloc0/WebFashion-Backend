using Libs.Entity;
using Libs.Helps;
using Libs.Repositoory;
using Libs.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class ProductService
    {
        private ApplicationDbContext _dbContext;
        private ICategoryRepository _categoty;
        private IProductRepository _product;
        private IImageRepository _image;
        private ImessageRepository _message;

        public ProductService(ApplicationDbContext dbContext, ICategoryRepository categoty, IProductRepository product, ImessageRepository message)
        {
            this._dbContext = dbContext;
            this._product = new ProductRepository(this._dbContext);
            this._categoty = new CategoryRepository(this._dbContext);
            this._image = new ImageRepository(this._dbContext);
            this._message = new MessageRepository(this._dbContext); ;
        }
        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        public void ClearUnsavedChanges()
        {
            ClearChanges(this._dbContext);
        }

        private void ClearChanges(DbContext context)
        {
            var entries = context.ChangeTracker.Entries()
                                .Where(e => e.State == EntityState.Added ||
                                            e.State == EntityState.Modified ||
                                            e.State == EntityState.Deleted)
                                .ToList();
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }

        public bool CheckProductExsitByName(string productName)
        {

            Expression<Func<Product, bool>> filer = x => x.productName == productName;
            return _product.Any(filer);
        }

        public string CreateProduct(Product product, List<string> imageUrls, List<SizeDetail> sizeDetails)
        {
            try
            {
                _product.Add(product);
                if (imageUrls.Count > 0)
                {
                    foreach (var imageUrl in imageUrls)
                    {
                        Image image = new Image
                        {
                            Id = Guid.NewGuid(),
                            ImageUrl = imageUrl

                        };
                        _dbContext.images.Add(image);

                        listImage listImage = new listImage
                        {
                            productId = product.Id,
                            imageId = image.Id
                        };
                        _dbContext.listImages.Add(listImage);
                    }
                }
                if (sizeDetails.Count > 0)
                {
                    foreach (var item in sizeDetails)
                    {
                        _dbContext.sizeDetails.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                ClearUnsavedChanges();
                return e.Message;
            }
            Save();
            return "Ok";

        }

        public void DeleteProduct(Guid id)
        {
            _product.Delete(_product.GetById(id));
            Save(); ;
        }

        public async Task<List<Product>> GetAllProductsByQuery(QueryProduct query)
        {
            var product = _dbContext.products.Include(x => x.category).AsQueryable();

            if (product == null)
            {
                return null;
            }
            else
            {

                if (!string.IsNullOrWhiteSpace(query.productName))
                {
                    product = product.Where(s => s.productName.Contains(query.productName));
                }

                if (query.IsDecsendingByPrice != null)
                {
                    if (query.IsDecsendingByPrice == true)
                    {
                        product = product.OrderByDescending(p => p.Price);
                    }
                    else
                    {
                        product = product.OrderBy(p => p.Price);
                    }
                }

                if (query.categoryId != null)
                {
                    product = product.Where(p => p.CategoryId == query.categoryId);
                }
            }


            var skipnumber = (query.pageNumber - 1) * query.pageSize;
            // pageNumber=2
            // pageSize=3
            // => skipnumber =3
            // product {1 , 10, 32, 4, ,5 }=> skipnumber=3 , pageSize=3
            //  product.Skip(skipnumber).Take(query.pageSize).ToListAsync();
            // => product {4, ,5, "null"}

            return await product.Skip(skipnumber).Take(query.pageSize).ToListAsync();

        }

        /*        public async Task<List<ProductOrder>> GetListProductByListId(List<ItemProduct> itemproduct)
                {
                    var products = new List<ProductOrder>();
                    foreach (var item in itemproduct)
                    {
                        Expression<Func<Product, bool>> filer = p => p.Id == item.ProductId;
                        var product = _product.FindSingOrDefault(filer);
                        if (product != null)
                        {
                            product.Price = item.price;
                            products.Add(product.toProductOrder(item.Quantity));
                        }
                    }

                    return products;
                }*/

        public Product GetProductById(Guid id)
        {
            return _dbContext.products.Include(p => p.category).SingleOrDefault(x => x.Id == id);
        }

        public async Task<Boolean> UpdatePRoduct(Product product, List<Imageupdate> LImages)
        {
            var ExsitProduct = _product.GetById(product.Id);
            if (ExsitProduct == null)
            {
                return false;
            }

            if (LImages.Count >= 0)
            {
                var listImage = GetAllListImageAsyncByProductId(product.Id);
                foreach (var item in LImages)
                {
                    {
                        var result = listImage.Result.FirstOrDefault(x => x == item.value);
                        if (result == null)
                        {
                            if (item.key == 0)
                            {
                                var IdImage = _dbContext.images.SingleOrDefault(x => x.ImageUrl == item.value);
                                var ListImage = _dbContext.listImages.FirstOrDefault(x => x.imageId == IdImage.Id && x.productId == product.Id);
                                _dbContext.listImages.Remove(ListImage);
                            };
                            if(item.key == 1)
                            {
                                Image image = new Image
                                {
                                    Id = Guid.NewGuid(),
                                    ImageUrl = item.value

                                };
                                _dbContext.images.Add(image);

                                listImage listImagesss = new listImage
                                {
                                    productId = product.Id,
                                    imageId = image.Id
                                };
                                _dbContext.listImages.Add(listImagesss);
                            }
                        }
                    }
                }
            }

            _product.UpdatePRoduct(product, ExsitProduct);
            Save(); ;
            return true;

        }

        // category
        public Category CreateCategory(Category Category)
        {
            Expression<Func<Category, bool>> filer = x => x.CategorName == Category.CategorName;
            var result = _categoty.FindSingOrDefault(filer);
            if (result == null)
            {
                _categoty.Add(Category);
                Save();
                return Category;
            }

            return null;

        }

        public bool DeleteCategory(Guid id)
        {
            var result = _categoty.GetById(id);
            if (result == null)
            {
                return false;
            }
            _categoty.Delete(result);
            Save();
            return true;

        }

        public async Task<List<Category>> GetAllCatetgoryAsync()
        {
            return await _categoty.GetAllAsync();
        }

        public Category GetCategoryById(Guid id)
        {
            var result = _categoty.GetById(id);
            return result;

        }

        public Category UpdateCategory(Category category)
        {
            _categoty.Update(category);
            Save();
            return category;
        }

        public async Task<List<Image>> GetAllImageAsync()
        {
            return await _image.GetAllAsync();
        }

        public void SaveImageAsync(Image image)
        {
            _image.Add(image);
            Save();
        }
        public async Task<List<String>> GetAllListImageAsyncByProductId(Guid productId)
        {
            return await _image.GetAllListImageAsyncByProductId(productId);
        }

        public async Task<List<SizeDetail>> GetAllSizeByProduct(Guid productId)
        {
            return await _dbContext.sizeDetails
                .Where(x => x.ProductId == productId)  
                .Include(x => x.size) 
                .ToListAsync(); 
        }

        public async void AddSizeDetial(SizeDetail sizeDetail)
        {
            _dbContext.sizeDetails.Add(sizeDetail);
            Save();
        }


        public Product calculatorQuantitySuccess(Guid Id, int quantity)
        {
            var product = _dbContext.products.FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return null;
            }
            product.quantitySellSucesss = product.quantitySellSucesss + quantity;
            _dbContext.SaveChanges();
            return product;
        }

        public async void AddMessage(string message, string url, String userID, Guid productId)
        {
            var ID = Guid.NewGuid();
            var messageOfCustommer = new MessageOfCustomer
            {
                Id = ID,
                Image = url,
                Message = message,
                UserId = userID
            };
            _dbContext.messageOfCustomers.Add(messageOfCustommer);
            var messageDetail = new MessageDetail
            {
                messageOfCustomerId = ID,
                productId = productId,
                Time = DateTime.Now,

            };
            _dbContext.messageDetails.Add(messageDetail);
            _dbContext.SaveChanges();
        }

        public async Task<List<MessageDetail>> GetAllMessageByProduct(Guid productId)
        {
            return await _dbContext.messageDetails
                .Where(md => md.productId == productId) // Lọc theo sản phẩm
                .OrderByDescending(md => md.Time) // Sắp xếp theo thời gian
                .Select(md => new MessageDetail
                {
                    Time = md.Time,
                    messageOfCustomer = md.messageOfCustomer, // Lấy nội dung đánh giá từ MessageOfCustomer
                    productId = md.productId
                })
                .ToListAsync();
        }
    }

}