using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BACKENDEMO.Dtos;
using BACKENDEMO.Dtos.Sessions;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Newtonsoft.Json;

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



        public OrderController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager,
                                IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository
        )
        {
            _userManager = userManager;
            _Itonkenserice = tokenService;
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
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                Ok(new { Status = true, message = "No data in cart" });
            }
            try
            {
                var cart = JsonConvert.DeserializeObject<List<ItemProduct>>(cartJson);
                if (cart == null)
                {
                    return Ok(new { Status = true, message = "No product exsist" });
                }
                var userId = CurrentUser.Id;
                var order = newOrder.ToNewOrder(userId);
                var createOrder = await _order.CreateOrder(order);
                var orderDetails = cart.Select(s => s.ToNewOrderDetail()).ToList();
                var createListOrder = await _orderdetail.CreateListOrderDetail(orderDetails, createOrder);

                if (createListOrder == true)
                {
                    return Ok(new { Status = true, message = "Create successfully" });
                }

                return Ok(new { Status = false, message = "Create faild" });

            }
            catch (JsonException e)
            {
                return BadRequest(new { Status = false, message = e.Message });
            }

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

                if (ListOrder == null)
                {
                    return Ok(new { status = true, message = "User don't have any order" });
                }
                return Ok(new { status = true, message = "Get all order success", Data = ListOrder.Select(s => s.ToOrderDto()) });
            } catch (Exception e) {
                return Ok(new { status = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOrderDetailsByOrderIdAsync([FromRoute] int id)
        {
            try
            {
                var result = await _orderdetail.GetOrderByOrderId(id);
                if(result == null) {
                    return Ok(new { status = true, message = "You don't have any order"});
                }

                return Ok(new { status = true, message = "", Data = result.Select(s => s.toOrderDetailsDto()).ToList() });
            }
            catch(Exception e)
            {
                return BadRequest(new { status = false, message = e.Message });
            }
        }

    

    }
}