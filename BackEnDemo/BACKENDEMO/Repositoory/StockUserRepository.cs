using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;
using BACKENDEMO.Models;

namespace BACKENDEMO.Repositoory
{
    public class StockUserRepository : IStockUserRepository
    {

         private readonly AppplicationDBContext _context;
        public StockUserRepository(AppplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stocks>> GetFullStocks(AppUser user)
        {
            return await _context.userStocks.Where(u => u.AppUserId == user.Id)
            .Select(s => new Stocks
            {
                Id = s.StockId,
                symbol = s.Stocks.symbol,
                company = s.Stocks.company,
                purchase = s.Stocks.purchase,
                lastdiv = s.Stocks.lastdiv,
                Industry = s.Stocks.Industry,

            }).ToListAsync();          
        }
    }
}