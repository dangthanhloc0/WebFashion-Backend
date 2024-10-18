
using Libs.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> Update([FromBody] UserInformation userInformation)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = false, messgae = ModelState });
            } 
            try
            {
                // User's email
                var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }

              /*  if (!string.IsNullOrEmpty(UserDto.Username))
                {
                    
                }*/

                if (!string.IsNullOrEmpty(userInformation.Image))
                {
                    CurrentUser.Image = userInformation.Image;
                }

                string birthDay = userInformation.Day + "/" + userInformation.Month + "/" + userInformation.Year;   
                if (birthDay != null)
                {
                    CurrentUser.birthDay = birthDay;
                }
                var result = await _userManager.UpdateAsync(CurrentUser);
                return Ok(new { status = true, message = "Update Success", data = CurrentUser.ToUserDto() });
          

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

        [HttpGet("GetCurrentUser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                // User's email
                var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }

                return Ok(new { status = true, message = "", data = CurrentUser.ToUserDto() });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
        }

    }
}