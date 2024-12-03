
using Libs.Entity;
using Libs.Helps;
using Libs.Service;
using Libs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Security.Claims;
using WebApi.Mappers;
using WebApi.Model.Product;
using WebApi.Model.Sessions;
using WebApi.Model.SizeDetail;
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

        private readonly UserManager<AppUser> _userManager;


        public ProductController(UserManager<AppUser> userManager, TokenService token, IHttpContextAccessor contx, ProductService productService)
        {
            _token = token;
            _contx = contx;
            _productService = productService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] QueryProduct query)
        {
            try
            {
                List<product> listProductResult = new List<product>();
                var productQuery = await _productService.GetAllProductsByQuery(query);
                foreach(var item in productQuery) {
                    var id = item.Id;
                    var GetListImageProduct = await _productService.GetAllListImageAsyncByProductId(id);
                    var GetSizeDetails = await _productService.GetAllSizeByProduct(id);
                    var messages = await _productService.GetAllMessageByProduct(id);
                    var result = item.toProduct(GetListImageProduct, GetSizeDetails, messages);
                    listProductResult.Add(result);
                }
                if (productQuery.Count != 0)
                {
                    return Ok(new { status = true, message = "Get successed", data = listProductResult });
                }
                return Ok(new { status = false, message = "Get =failed" });

            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
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
                        return Ok(new { status = true, message = "not found image", data = Product.toProduct() });
                    }

                    var messages = await _productService.GetAllMessageByProduct(id);
                    var GetSizeDetails = await _productService.GetAllSizeByProduct(id);
                    var result = Product.toProduct(GetListImageProduct, GetSizeDetails,messages);

                    

                    return Ok(new { status = true, message = "",data = result });

                    

                }
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }


        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> NewProduct([FromBody] NewProduct newProduct)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = false, message = "", data = ModelState });
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
                List<SizeDetail> sizeDetails = new List<SizeDetail>();
                foreach (var item in newProduct.sizeDetails)
                {
                    SizeDetail SD = new SizeDetail
                    {
                        ProductId = product.Id,
                        Quantity = item.quantity,
                        sizeId = item.sizeId,
                    };
                    sizeDetails.Add(SD);
                }
                var message = _productService.CreateProduct(product, ListStringImage, sizeDetails);
                if (message == "Ok")
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
/*
        [Authorize(Roles = "User")]*/
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct updateProduct)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = false, message = "Update product failed by id =" + updateProduct.Id, Data = ModelState }); ;
            }
            try
            {
                var product = updateProduct.ToUpdateProduct();
                var category = _productService.GetCategoryById(product.CategoryId);
                if (category == null)
                {
                    return Ok(new { status = false, message = "not found categoy by id =" + product.CategoryId, Data = product });
                }
                bool result = await _productService.UpdatePRoduct(product, updateProduct.imageUrls,updateProduct.sizes.Select(x => x.toSizeDetail()).ToList());

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

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok(new { status = true, message = "Delete sucessed" });
            }
            catch (Exception e)
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
                    if (checkExist != null)
                    {
                        checkExist.Quantity += item.Quantity;

                    }
                    else
                    {
                        cart.Add(item);
                    }
                    var convert = JsonConvert.SerializeObject(cart);

                    HttpContext.Session.SetString("Cart", convert);
                    return Ok(new { status = true, message = "", data = convert });
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
                foreach (var item in cart)
                {
                    if (item.ProductId == id)
                    {
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

        [HttpGet]
        [Route("GetAllSize/{id:Guid}")]
        public async Task<IActionResult> GetAllSizeByProductId(Guid id)
        {
            try
            {
                var result = await _productService.GetAllSizeByProduct(id);
                if (result == null)
                {
                    return Ok(new { Status = false, message = "not found size" });
                }

                return Ok(new { Status = false, message = "", Data = result.Select(s => s.toSizeDetailUi()) });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("addMessage/{id:Guid}")]
        public async Task<IActionResult> AddMessage(Guid id, string message, string Image)
        {
            try
            {
                var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }
                var userId = CurrentUser.Id;
                _productService.AddMessage(message, Image, userId, id);
                return Ok(new { Status = true, message = "Ok" });
            }
            catch (Exception e)
            {
                return Ok(new { Status = false, message = e.Message });
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