using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BACKENDEMO.Controllers
{
    [Route("v1/api/stock")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {

        private readonly AppplicationDBContext _context ;
        private readonly IstockRepository _Stock ;
        public StocksController(AppplicationDBContext context,IstockRepository istock)
        {
            _context = context;
            _Stock = istock;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){
            var stocks= await _Stock.GetAllasync(query);

            var StockDto= stocks.Select(s=>s.ToStockDto());

            return Ok(stocks); 
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock=await _Stock.GetByIDasync(id);
            if(stock==null){    
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequest stockDto){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var StockModel=stockDto.ToCreateStockRequestDto();
            await _Stock.CreateStockAsync(StockModel);
            return  Ok(StockModel.ToStockDto());
        }

        [HttpPut] 
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id,[FromBody] UpdateStockDto updateDto){
            var stockmodel=await _Stock.UpdateStockAsync(id, updateDto);
            if(stockmodel==null){
                return NotFound();
            }

            return Ok(stockmodel.ToStockDto());         
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id){
            await _Stock.DeleteStockAsync(id);
            return NoContent();
        }
    }
}