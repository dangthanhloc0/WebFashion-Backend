
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Dtos.Product;
using BACKENDEMO.Dtos.Sessions;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using BACKENDEMO.Repositoory;
using BACKENDEMO.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;


namespace BACKENDEMO.Controllers
{
    [Route("v2/api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        const string SessionKeyProduct = "SessionsProduct";
        public string? SessionInfo_SessionTime { get; private set; }
        private readonly ISessions _Sessions;
        private readonly AppplicationDBContext _context;
        private readonly IProductRepository _product;
        private readonly IImageRepository _image;
        private readonly IListImageRepository _Listimage;
        private readonly ILogger<ProductController> _logger;
        private readonly IHttpContextAccessor _contx;
        public ProductController(AppplicationDBContext context, IProductRepository productRepository, IImageRepository image, IListImageRepository listImage
           , ISessions sessios, ILogger<ProductController> logger, IHttpContextAccessor contx)
        {
            _context = context;
            _product = productRepository;
            _image = image;
            _Listimage = listImage;
            _Sessions = sessios;
            _logger = logger;
            _contx = contx;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] QueryProduct query) {
            Boolean Success = false;
            var productQuery = await _product.GetAllProductsByQuery(query);

            try {
                var products = productQuery.Select(s => s.ToProductDto(null));
                if (products == null) {
                    Success = false;
                }
                else {
                    Success = true;
                }

                if (Success == true) {
                    return Ok(products);
                }

            } catch (Exception ex) {
                return NotFound();
            }


            return BadRequest("not found");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id) {
            var Product = await _product.GetProductById(id);
            if (Product == null) {
                return BadRequest("not found product by id=" + id);
            } else
            {
                var GetListImageProduct = await _Listimage.GetAllListImageAsyncByProductId(id);
                if (GetListImageProduct.Count == 0)
                {
                    return BadRequest("Image not found");
                }
                var result = Product.ToProductDto(GetListImageProduct);
                return Ok(result);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] NewProduct ProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ExsitProduct = await _product.CheckProductExsitByName(ProductDto.productName);

            if (ExsitProduct) {
                return Ok("Product Exist by name " + ProductDto.productName);
            }

            var ExsitCategory = await _context.categories.AnyAsync(x => x.Id == ProductDto.CategoryId);

            if (!ExsitCategory) {
                return Ok("Category not found by id =" + ProductDto.CategoryId);
            }

            var newproducts = ProductDto.ToCreateNewProductDto();
            var product = await _product.CreateProduct(newproducts);
            var ListStringImage = ProductDto.ListStringImage;
            var id = newproducts.ProductId;
            // create list image 
            if (ListStringImage == null && ListStringImage.imageUrl.Count == 0)
            {
                return BadRequest("Image not found");
            }
            int count = 0;
            foreach (var image in ListStringImage.imageUrl)
            {
                var imageProduct = new ImageProduct
                {
                    ImageUrl = image
                };
                var IdImage = await _image.SaveImageAsync(imageProduct);
                var ListImage = new listImage
                {
                    productId = id,
                    imageId = IdImage
                };
                try
                {
                    _Listimage.SaveListImageAsync(ListImage);
                } catch (Exception e)
                {
                    return Ok(new { status = false, message = "Create image found by image =" + image });
                }

                count++;
            }

            if (count != ListStringImage.imageUrl.Count)
            {
                return BadRequest("Create something image faild");
            }
            return Ok(product);
        }



        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProduct updateProduct) {
            if (!ModelState.IsValid)
            {
                return (BadRequest(ModelState));
            }
            var product = updateProduct.ToUpdateProduct();
            bool result = await _product.UpdatePRoduct(id, product);

            if (result) {
                return Ok("Update product successed");
            }

            return BadRequest("Update product failed by id =" + id);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute, FromBody] int id)
        {

            bool result = await _product.DeleteProduct(id);

            if (!result)
            {
                return BadRequest("Product not found or exception");
            }

            return Ok("Delete sucessed");
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
                    return Ok(convert);
                }
            }
            catch (JsonException ex)
            {
                return BadRequest("Exception when try get cart data in sessions");
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
                var listProduct = await _product.GetListProductByListId(cart);
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
        [Route("Remove/{id:int}")]
        public async Task<IActionResult> RemoveFormCartAsync([FromRoute] int id)
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
                var listProduct = await _product.GetListProductByListId(cart);
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
                    var product = _product.GetProductById(id);
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

            
        }
    }
    
}