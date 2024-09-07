using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.Extensions;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BACKENDEMO.Controllers
{
    [Route("v3/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppplicationDBContext _context ;
        private readonly IUserRepository _user ;
        private readonly UserManager<AppUser> _userManager;
        public UserController(AppplicationDBContext context, IUserRepository user, UserManager<AppUser> userManager)
        {
            _context = context;
            _user = user;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var ListUser = await _user.GetAllasync();
            var result = ListUser.Select(x => x.ToUserDto()).ToList();
            return Ok(result);
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> GetById([FromRoute] String name){
            var User = await _user.GetByIDasync(name);
            var result = User.ToUserDto();
            return Ok(result);
        }


        [HttpPut] 
        [Route("{name}")]
        public async Task<IActionResult> Update ([FromRoute] String name,[FromBody] UserDto UserDto){
            var Appuser = await _user.UpdateUserAsync(name, UserDto);
            return Ok(Appuser.ToUserDto()); 
        }

        [Authorize]
        [HttpPut("ChangePassWord")]
        public async Task<IActionResult> ChnagePassWordUser([FromBody] ChangePassWordDto changePassWordDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value; // User's email

            var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
            if (CurrentUser == null)
            {
                return Unauthorized();
            }
            var result = await _user.ChangePassWord(changePassWordDto, CurrentUser);
            if (result)
            {
                return Ok("Update passWord's User Succces");
            }

            return BadRequest("Update passWord's User faild");
            
        }

    }
}