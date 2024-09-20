 using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace BACKENDEMO.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _useManager;

        private readonly ITokenService _Itonkenserice;

        private readonly SignInManager<AppUser> _signInManager;


        public AccountController(UserManager<AppUser> userManager,ITokenService tokenService,SignInManager<AppUser> signInManager)
        {
             _useManager = userManager ;
             _Itonkenserice= tokenService;
             _signInManager = signInManager;
        }


        [HttpPost("Login")]
        public async  Task<IActionResult>  Login(LoginDto loginDTo){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var user = await _useManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTo.Username.ToLower());

            if(user == null){
                return Unauthorized("Invalid username!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTo.Password , false);

            if(!result.Succeeded) return Unauthorized("User not found  and/or password incorrect");

            return Ok(
                new newUserDto{
                    Username = user.UserName,
                    EmailAddress = user.Email,
                    Token = _Itonkenserice.CreateToken(user)
                }
            );
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState); 
                }

                var appuser = new AppUser{
                    UserName = registerDto.Username,
                    Email = registerDto.EmailAddress
                };
                // check user name exsit 
                var  CheckEmailExsit = _useManager.FindByEmailAsync(appuser.Email); 
/*                var  CheckUserNameExsit = _useManager.FindByNameAsync(appuser.UserName);*/
                if(CheckEmailExsit != null) {
                    return BadRequest("Your eamil exist");
                }

                var createUser = await _useManager.CreateAsync(appuser, registerDto.Password);
            
                if(createUser.Succeeded)
                {
                    var rolesResult = await _useManager.AddToRoleAsync(appuser, "User");
                    if(rolesResult.Succeeded){
                        return Ok(
                            new newUserDto{
                                Username = appuser.UserName,
                                EmailAddress = appuser.Email,
                                Token = _Itonkenserice.CreateToken(appuser)
                            }
                        );
                    }
                    else{
                        return StatusCode(500, rolesResult.Errors);
                    }
                }
                else{
                    return StatusCode(500, createUser.Errors);
                }
            }catch(Exception e){
              return StatusCode(500,e);
            }
        }

        [HttpGet]
        [Route("signin-google")]
        public IActionResult SignInWithGoogle()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        [HttpGet]
        [Route("TestAbc")]
        public ActionResult testAbc()
        {
            try {
                List<string> testList = new List<string>();
                if (testList.Count == 0) {
                    return Ok(new { status = false, message = "Error" });
                }
                return Ok(new { status = true, message = "", data = testList });
            }catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
           

        }

        [HttpGet]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            var claims = result.Principal.Identities.FirstOrDefault().Claims;
            // Use claims for login or registration
            return Ok(claims);
        }

    }
}