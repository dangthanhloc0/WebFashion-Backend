
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Product;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using BACKENDEMO.Repositoory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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

            var ExsitProduct = await _product.CheckProductExsitByName(ProductDto.productName);

            if(ExsitProduct){
                return Ok("Product Exist by name " + ProductDto.productName);
            }

            var ExsitCategory = await _context.categories.AnyAsync(x => x.Id == ProductDto.CategoryId);

            if(!ExsitCategory){
                return Ok("Category not found by id =" + ProductDto.CategoryId);
            }

            var newproducts = ProductDto.ToCreateNewProductDto();
            var product = await _product.CreateProduct(newproducts);

            return Ok(product);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id,[FromBody]UpdateProduct updateProduct){
            if (!ModelState.IsValid)
            {
                return( BadRequest(ModelState) );
            }
            var product = updateProduct.ToUpdateProduct();
            var result = _product.UpdatePRoduct(id,product);

            if(result != null){
                return Ok("Update product successed");
            }

            return BadRequest("Update product failed by id =" + id);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute,FromBody]int id)
        {
            
            bool result = await _product.DeleteProduct(id);

            if(!result)
            {
                return BadRequest("Product not found or exception");
            }

            return Ok("Delete sucessed");
        }
    }
}