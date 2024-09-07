using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Runtime.InteropServices;

namespace BACKENDEMO.Controllers
{
    [Route("v4/api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly AppplicationDBContext _context ;
        private readonly ICategoryRepository _category ;
        private readonly UserManager<AppUser> _userManager;
        public CategoryController(AppplicationDBContext context, ICategoryRepository Category, UserManager<AppUser> userManager)
        {
            _context = context;
            _category = Category;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategory(){
           var listResult = await _category.GetAllCatetgoryAsync();
           var result = listResult.Select(s => s.ToCategoryDto()).ToList();    
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Not found category");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id){
            var result = await _category.GetCategoryById(id);
            if (result == null) {
                return BadRequest("not found category by id =" + id);
            }

            return Ok(result.ToCategoryDto());

        }


        [HttpPut] 
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory ([FromRoute] int id,[FromBody] NewCategory newCategory)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _category.UpdateCategory(id, newCategory); 
            if(result == null) { 
                return BadRequest("Update category faild");
            }
            return Ok(result); 
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var result = await _category.DeleteCategory(id);
            if (result == null)
            {
                return BadRequest("Delete category faild");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CretaeCategory([FromBody] NewCategory newCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _category.CreateCategory(newCategory);
            return Ok(result);
        }



    }
}