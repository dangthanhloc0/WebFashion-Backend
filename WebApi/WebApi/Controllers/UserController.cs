
using Libs.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Mappers;
using WebApi.Model.User;

namespace WebApi.Controllers
{
    [Route("v3/api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ListUser = _userManager.Users.Select(x => x.ToUserDto()).ToList();
                return Ok(new { status = true, message = "Get All User", data = ListUser });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, message = ex.Message });
            }
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> GetById([FromRoute] String name)
        {
            try
            {
                var User = await _userManager.FindByNameAsync(name);
                var result = User.ToUserDto();
                return Ok(new { status = true, message = "Get User success", data = result });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, message = ex.Message });
            }
        }


        [HttpPut]
        [Route("{name}")]
        public async Task<IActionResult> Update([FromRoute] String name, [FromBody] UserDto UserDto)
        {
            try
            {
                var User = await _userManager.FindByNameAsync(name);
                User.UserName = UserDto.Username;
                var result = await _userManager.UpdateAsync(User);
                return Ok(new { status = true, message = "Update Success", data = User.ToUserDto() });
            }
            catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
        }

        [HttpPut("ChangePassWord")]
        public async Task<IActionResult> ChnagePassWordUser([FromBody] ChangePassWordDto changePassWordDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value; // User's email

                var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }
                var result = await _userManager.ChangePasswordAsync(CurrentUser, changePassWordDto.OldPassword, changePassWordDto.NewPassword);
                if (result.Succeeded)
                {
                    return Ok(new { status = true, message = "Update passWord's User Succces" });
                }

                return Ok(new { status = false, message = "Update passWord's User faild\"" });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }

        }

    }
}