
using Libs.Entity;
using Libs.Helps;
using Libs.Service;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Linq.Expressions;
using WebApi.Mappers;
using WebApi.Model.Product;
using WebApi.Model.Sessions;
using static System.Net.Mime.MediaTypeNames;


namespace BACKENDEMO.Controllers
{
    [Route("v2/api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        const string SessionKeyProduct = "SessionsProduct";
        public string? SessionInfo_SessionTime { get; private set; }
        private readonly UserManager<AppUser> _useManager;

        private readonly TokenService _token;

        private readonly SignInManager<AppUser> _signInManager;
 
        private readonly IHttpContextAccessor _contx;

        private readonly ProductService _productService;

 
        public ProductController(TokenService token, IHttpContextAccessor contx, ProductService productService)
        {
            _token = token;
            _contx = contx;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] QueryProduct query) {
            try {
                var productQuery = await _productService.GetAllProductsByQuery(query);
                if (productQuery.Count != 0) {
                    return Ok(new { status = true, message = "Get successed", data = productQuery.Select(s => s.toProduct())});
                }
                return Ok(new { status = false, message = "Get =failed" });

            } catch (Exception e) {
                return Ok(new { status = false, message = e.Message });
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id) {
            try
            {
                var Product = _productService.GetProductById(id);
                if (Product == null)
                {
                    return Ok(new { status = false, message = "not found product by id=" + id });
                }
                else
                {
                    var GetListImageProduct = await _productService.GetAllListImageAsyncByProductId(id);
                    if (GetListImageProduct.Count == 0)
                    {
                        return Ok(new { status = true, message = "not found image" ,data= Product.toProduct() });
                    }
                    var result = Product.toProduct(GetListImageProduct);
                    return Ok(new { status = true, message = "", data = result });
                }
            }
            catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }


        }

        [HttpPost]
        public async Task<IActionResult> NewProduct([FromBody] NewProduct newProduct)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = false, message ="", data = ModelState });
            }
            try
            {
                var ExsitProduct = _productService.CheckProductExsitByName(newProduct.productName);

                if (ExsitProduct)
                {
                    return Ok(new { status = false, message = "Product Exist by name " + newProduct.productName });
                }

                var ExsitCategory = _productService.GetCategoryById(newProduct.CategoryId);

                if (ExsitCategory == null)
                {
                    return Ok(new { status = false, message = "Category not found by id =" + newProduct.CategoryId });
                }
                var product = newProduct.ToCreateNewProductDto();
                var ListStringImage = newProduct.imageUrls;
                var message =_productService.CreateProduct(product, ListStringImage);
                if(message == "Ok")
                {
                    return RedirectToAction("GetProduct", null);
                }
                return BadRequest(new { status = false, message = message });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct updateProduct) {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = false, message = "Update product failed by id =" + updateProduct.Id, Data = ModelState }); ;
            }
            try
            {
                var product = updateProduct.ToUpdateProduct();
                var category = _productService.GetCategoryById(product.CategoryId); 
                if (category == null) {
                    return Ok(new { status = false, message = "not found categoy by id =" + product.CategoryId, Data = product });
                }
                bool result = await _productService.UpdatePRoduct(product);

                if (result)
                {
                    return Ok(new { status = true, message = "Update product successed", Data = product });
                }
                return Ok(new { status = false, message = "Update product failed by id =" + updateProduct.Id, Data = product });

            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
   
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok(new { status = true, message = "Delete sucessed" });
            }
            catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }

    
        }

        [HttpPost("sessions")]
        public IActionResult SaveSessionProduct([FromBody] ItemProduct item)
        {
            List<ItemProduct> cart = new List<ItemProduct>();
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                cart.Add(item);
                var convert = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("Cart", convert);
                return Ok(convert);
            }
            try
            {
                cart = JsonConvert.DeserializeObject<List<ItemProduct>>(cartJson);
                {
                    var checkExist = cart.SingleOrDefault(p => p.ProductId == item.ProductId);
                    if (checkExist != null) {
                        checkExist.Quantity += item.Quantity;

                    } else
                    {
                        cart.Add(item);
                    }
                    var convert = JsonConvert.SerializeObject(cart);

                    HttpContext.Session.SetString("Cart", convert);
                    return Ok(new { status = true, message = "",data= convert });
                }
            }
            catch (JsonException e)
            {
                return Ok(new { status = false, message = e.Message });
            }

        }

        [HttpGet("GetAllSessions")]
        public async Task<IActionResult> GetAllSessionProduct()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return BadRequest("No cart data in sessions");
            }
            try
            {
                var cart = JsonConvert.DeserializeObject<List<ItemProduct>>(cartJson);
                var listProduct = new List<ProductOrder>();
                foreach(var item in cart)
                {

                    var product = _productService.GetProductById(item.ProductId);
                    if (product != null)
                    {
                        product.Price = item.price;
                        listProduct.Add(product.toProductOrder(item.Quantity));
                    }
                }
                if (listProduct == null)
                {
                    return Ok(new { Status = true, message = "Not found product" });
                }

                return Ok(new { Status = true, message = "Ok", Data = listProduct });
            }
            catch (JsonException ex)
            {
                return Ok(new { Status = false, message = ex.Message });
            }

        }


        [HttpDelete]
        [Route("Remove/{id:Guid}")]
        public async Task<IActionResult> RemoveFormCartAsync([FromRoute] Guid id)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return BadRequest("No cart data in sessions");
            }
            try
            {
                var cart = JsonConvert.DeserializeObject<List<ItemProduct>>(cartJson);
                foreach(var item in cart)
                {
                    if(item.ProductId == id) {
                        cart.Remove(item); 
                        break;
                    }
                }
                var convert = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("Cart", convert);
                var listProduct = new List<ProductOrder>();
                foreach (var item in cart)
                {

                    var product = _productService.GetProductById(item.ProductId);
                    if (product != null)
                    {
                        product.Price = item.price;
                        listProduct.Add(product.toProductOrder(item.Quantity));
                    }
                }
                if (listProduct == null)
                {
                    return Ok(new { Status = true, message = "Not found product" });
                }

                return Ok(new { Status = true, message = "Ok", Data = listProduct });
            }
            catch (JsonException ex)
            {
                return Ok(new { Status = false, message = ex.Message });
            }
        }

/*        [HttpGet]
        [Route("AddToCart")]
        public IActionResult AddToCart()
        {
            List<Task<Product>> products = new List<Task<Product>>();   
            try
            {
                string Value = HttpContext.Request.Cookies["Cart"];
                string[] ListIdProduct = Value.Split(",");
                foreach(var item in ListIdProduct)
                {
                    int id = Int32.Parse(item);
                    var product = _productService.GetProductById(id);
                    if(product != null)
                    {
                        products.Add(product); 
                    }

                }

                return Ok(new { status = true, message = "GetDataSuccess", Data = products });
            } catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }

            
        }*/
    }
    
}