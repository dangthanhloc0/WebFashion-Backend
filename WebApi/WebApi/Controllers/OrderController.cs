using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.WebSockets;
using System.Numerics;
using System.Security.Claims;
using Libs.Entity;
using Libs.Service;
using Libs.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Newtonsoft.Json;
using WebApi.Mappers;
using WebApi.Model.Sessions;
using WebApi.Model.User;

namespace WebApi.Controllers
{
    [Route("v5/Api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly TokenService _tokenService;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly SellService _sell;

        private readonly ProductService _productService;


        public OrderController(UserManager<AppUser> userManager, TokenService tokenService, SignInManager<AppUser> signInManager,
                  SellService sell, ProductService productService
        )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _sell = sell;
            _productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] newOrder newOrder)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { status = true, message = "", data = ModelState });
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
                return Ok(new { Status = true, message = "No data in cart" });
            }
            try
            {
                var cart = JsonConvert.DeserializeObject<List<ItemProduct>>(cartJson);
                if (cart == null)
                {
                    return Ok(new { Status = true, message = "No product exsist" });
                }
                var orderDetails = cart.Select(s => s.ToNewOrderDetail()).ToList();
                var userId = CurrentUser.Id;
                float  price = 0;
                foreach(var item in orderDetails)
                {
                    price += item.price;
                }
                var order = newOrder.ToNewOrder(userId, price);
                /* var createOrder = await _order.CreateOrder(order);*/

                /* var createListOrder = await _orderdetail.CreateListOrderDetail(orderDetails, createOrder);*/
                var result = _sell.CreateBillSellProdcut(orderDetails, order);


                if (result == "Ok")
                {
                    HttpContext.Session.Remove("Cart");
                    return Ok(new { Status = true, message = "Create successfully" });
                }

                return Ok(new { Status = false, message = "Create faild" });

            }
            catch (JsonException e)
            {
                return Ok(new { Status = false, message = e.Message });
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

                var ListOrder = await _sell.GetAllOrderByUserId(CurrentUser.Id);

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
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAllOrderDetailsByOrderIdAsync([FromRoute] Guid id)
        {
            try
            {
                var result =  _sell.GetAllOrderDetailByOrderId(id);
                if(result == null) {
                    return Ok(new { status = true, message = "You don't have any order"});
                }

                return Ok(new { status = true, message = "", Data = result.Result.Select(s => s.toOrderDetailsDto()).ToList() });
            }
            catch(Exception e)
            {
                return Ok(new { status = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("Admin")]
        public async Task<IActionResult> GetAllOrderByAdmin()
        {
            try
            {
                var result = await _sell.getOrderList();
                if(result == null)
                {
                    return Ok(new { status = true, message = "not found order" });
                }

                return Ok(new { status = true, message = "GetAllOrder", data = result.Select(s => s.ToOrderDto()).ToList() });
            }catch(Exception e)
            {
                return Ok(new { status = false,messgae = e.Message});   
            }
        }




    

    }
}