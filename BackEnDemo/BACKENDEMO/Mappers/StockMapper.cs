using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Models;


namespace BACKENDEMO.Mappers
{
    public static class StockMapper
    {
        public static StockDto  ToStockDto(this Stocks StockModel){
            return new StockDto
            {
                Id       = StockModel.Id,
                symbol   = StockModel.symbol,
                company  = StockModel.company,
                purchase = StockModel.purchase,
                lastdiv  = StockModel.lastdiv,
                Industry = StockModel.Industry,
                maketcap = StockModel.maketcap,
                Comments = StockModel.comments.Select(s=> s.ToComentDto()).ToList(),
            };
        }

        public static Stocks ToCreateStockRequestDto(this CreateStockRequest StockModel){
            return new Stocks
            {
                symbol=StockModel.symbol,
                company=StockModel.company,
                purchase=StockModel.purchase,
                lastdiv=StockModel.lastdiv,
                Industry=StockModel.Industry,
                maketcap=StockModel.maketcap
            };
        }
    }
}