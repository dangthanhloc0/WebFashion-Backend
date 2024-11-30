using Libs.Entity;
using Libs.Helps;
using Libs.Service;
using Libs.Services;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApi.Model.User;


namespace WebApi.Controllers
{

    [ApiController]
    [Route("Mail")]
    public class MailController : ControllerBase
    {
        const string SessionKeyProduct = "code";

        
        public string? SessionInfo_SessionTime { get; private set; }
        private MailServices _mailSV;
        private  UserManager<AppUser> _userManager;
        private readonly TokenService _Ttken;

        public MailController(MailServices _MailService, UserManager<AppUser> user, TokenService token)
        {
            _mailSV = _MailService;
            _userManager = user;
            _Ttken = token;
        }


        [HttpPost]
        public async Task<IActionResult> SendMail(MailData Mail_Data)
        {
            Random rnd = new Random();
            int s1 = rnd.Next(0, 10);
            int s2 = rnd.Next(0, 10);
            int s3 = rnd.Next(0, 10);
            int s4 = rnd.Next(0, 10);
            int s5 = rnd.Next(0, 10);
            int s6 = rnd.Next(0, 10);
            int s7 = rnd.Next(0, 10);
            int s8 = rnd.Next(0, 10);
            int s9 = rnd.Next(0, 10);
            int s10 = rnd.Next(0, 10);
            String code = s1.ToString() + s2.ToString() + s3.ToString() + s4.ToString() + s5.ToString() + s6.ToString() + s7.ToString() + s8.ToString() + s9.ToString() + s10.ToString();
            try
            {
                var user = await _userManager.FindByEmailAsync(Mail_Data.EmailToId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

  
                HttpContext.Session.SetString("Code", code);
                // var resetUrl = Url.Action("ResetPassword", "Account", new { Token, userId = user.Id }, protocol: Request.Scheme);
                var result = _mailSV.sendEmail(Mail_Data, code);
                return Ok(new { status = true, messgae = "", data = result }) ;
            }
            catch(Exception e) {
                return Ok(new { status = true, messgae = e.Message });
            }
           
        }
        [HttpPost("verifyCode")]
        public async Task<IActionResult> SaveSessionProduct(String code,String email)
        {
            try
            {
                var CodeJson = HttpContext.Session.GetString("Code");
                if(code == CodeJson)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        return NotFound("User not found");
                    }
                    var Token = _userManager.GeneratePasswordResetTokenAsync(user);
                    return Ok(new { status = true, message = "OK",data = Token });
                }
                return Ok(new { status = false, message = "Error code"});

            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }

        }

        // forgot password
        [HttpPut("ForGotPassWord")]
        public async Task<IActionResult> FogotPassWordUser([FromBody] ForGotPassWord forGotPassWord)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var CurrentUser = await _userManager.FindByEmailAsync(forGotPassWord.EmailUser);
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }
                var result = await _userManager.ResetPasswordAsync(CurrentUser, forGotPassWord.Token, forGotPassWord.NewPassword);
                if (result.Succeeded)
                {
                    return Ok(new { status = true, message = "Change your password successed" });
                }

                return Ok(new { status = false, message = "Change your password flaid" });
            }
            catch (Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }

        }


    }
}
