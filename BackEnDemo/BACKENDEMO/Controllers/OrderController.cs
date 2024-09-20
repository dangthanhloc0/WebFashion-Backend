using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace BACKENDEMO.Controllers
{
    [Route("v5/Api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ITokenService _Itonkenserice;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly IOrderRepository _order;

        private readonly IOrderDetailRepository _orderdetail;



        public OrderController(UserManager<AppUser> userManager,ITokenService tokenService,SignInManager<AppUser> signInManager,
                                IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository
        )
        {
            _userManager = userManager ;
             _Itonkenserice= tokenService;
             _signInManager = signInManager;
            _order = orderRepository;
            _orderdetail = orderDetailRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] newOrder newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // User's email
            var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value; 

            var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            var userId = CurrentUser.Id;
            var order = newOrder.ToNewOrder(userId);
            var createOrder = await _order.CreateOrder(order);
            var orderDetails = newOrder.OrdertailDto.Select(s => s.ToNewOrderDetail()).ToList();
            var createListOrder = await _orderdetail.CreateListOrderDetail(orderDetails, createOrder);

            if (createListOrder == true)
            {
                return Ok("Create list Order Successfully");
            }

            return BadRequest("Create failed");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrderByUserIdAsync()
        {

            try {
                // find user 
                var emailClaim = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var CurrentUser = await _userManager.FindByEmailAsync(emailClaim);
                if (CurrentUser == null)
                {
                    return Unauthorized();
                }

                var ListOrder = await _order.GetAllOrderByUserId(CurrentUser.Id);

                if(ListOrder == null)
                {
                    return Ok(new { status = true, message = "User don't have any order" });
                }
                return Ok(new { status = true, message = "Get all order success", Data = ListOrder.Select(s => s.ToOrderDto()) });
            } catch(Exception e) { 
                return Ok(new { status = false , message =  e.Message });
            }
        }

    

    }
}