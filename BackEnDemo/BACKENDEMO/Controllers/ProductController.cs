
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Product;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using BACKENDEMO.Repositoory;

using Microsoft.AspNetCore.Mvc;


namespace BACKENDEMO.Controllers
{
    [Route("v20/api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppplicationDBContext _context ;
        private readonly IProductRepository _product;
        public ProductController(AppplicationDBContext context, IProductRepository productRepository)
        {
            _context = context;
            _product = productRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery]QueryProduct query){
            Boolean Success = false;
            
            var productQuery = await _product.GetAllProductsByQuery(query);
            try{
                var products = productQuery.Select(s => s.ToProductDto());
                if(products==null){
                    Success = false;
                }
                else{
                    Success = true ;
                }
                            
                if(Success == true){
                    return Ok(products);
                }

            }catch(Exception ex){
                return NotFound();  
            }
    

            return BadRequest("not found");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id){
            var Product = await _product.GetProductById(id);
            if(Product == null){
                return BadRequest("not found product by id=" + id);
            }
            return Ok(Product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]NewProduct ProductDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newproducts = ProductMapper.ToCreateNewProductDto(ProductDto);
            var product = await _product.CreateProduct(newproducts);

            if(product == null){
                return BadRequest("Duplicate product by name = "+ProductDto.productName);
            }

            return Ok(product);
        }
    }
}