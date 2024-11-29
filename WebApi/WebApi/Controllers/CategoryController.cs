
using Libs.Entity;
using Libs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;
using WebApi.Model.Category;


namespace WebApi.Controllers
{
    [Route("v4/api/Category")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {

       
        private readonly ProductService _productService ;

        public CategoryController(ProductService productService)
        {
            _productService = productService;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategory(){
            try
            {
                var Result = await _productService.GetAllCatetgoryAsync();
                if (Result.Count != 0)
                {
                    return Ok(new { status = true, message = "Get successed", data = Result.Select(s => s.toCategory())});
                }
                return Ok(new { status = false, message = "no category in db" });
            }
            catch (Exception e) {
                return Ok(new { status = false, message = e.Message });
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id){
            try
            {
                var result = _productService.GetCategoryById(id);
                if (result == null)
                {
                    return Ok(new { status = false, message = "not found category by id =" + id });
                }
                return Ok(new { status = true, message = "Get successed", data = result.toCategory() });

            }
            catch (Exception e) {
                return Ok(new { status = false, message = e.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut] 
        public  ActionResult UpdateCategory (category category)
        {
            if (!ModelState.IsValid) {
                return Ok(new { status = false, message = "ModelState is not done", data=ModelState });
            }
            try
            {
                var result = _productService.UpdateCategory(category.toCategory());
                if (result == null)
                {
                    return Ok(new { status = false, message = "update failed" });
                }
                return Ok(new { status = true, message = "update successed", data = result.toCategory() });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            try
            {
                var result = _productService.DeleteCategory(id);
                if (result == false)
                {
                    return Ok(new { status = false, message = "not found category"});
                }
                return Ok(new { status = true, message = "delete successed"});
            }
            catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message});
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] NewCategory newCategory)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = false, message = "",data = ModelState });
            }
            try
            {
                var result = _productService.CreateCategory(newCategory.ToNewCategory());
                if (result != null)
                {
                    return Ok(new { status = true, message = "category successed" });
                }
                return Ok(new { status = false, message = "Create exsisted" ,data =result });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
        }



    }
}