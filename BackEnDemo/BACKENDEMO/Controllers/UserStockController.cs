using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Entity;
using BACKENDEMO.Extensions;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using BACKENDEMO.Repositoory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BACKENDEMO.Controllers
{   
    [Route("v4/api/Userstock")]
    [ApiController]
    public class UserStockController : ControllerBase
    {

        public readonly UserManager<AppUser> _userManager;


        public readonly IstockRepository _stock;
        public readonly IStockUserRepository _StockUser;
        public UserStockController(UserManager<AppUser> userManager, IstockRepository istockRepository,IStockUserRepository stockUserRepository)
        {
            _userManager = userManager;
            _stock = istockRepository;    
            _StockUser = stockUserRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserStock(){
            var userName = User.GetUserName();
            var appuser = await _userManager.FindByNameAsync(userName);
            var UserStock = await  _StockUser.GetFullStocks(appuser);

            if(UserStock == null){
                return BadRequest("No Stock in here");
            }

            return Ok(UserStock);
        }
    
    }
}