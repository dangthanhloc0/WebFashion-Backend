using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.Repositoory
{
    public class StockRepository : IstockRepository
    {

        private readonly AppplicationDBContext _context;
        public StockRepository(AppplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stocks> CreateStockAsync(Stocks stocks)
        {
            await _context.stock.AddAsync(stocks);
            await _context.SaveChangesAsync();
            return stocks;
        }

        public async Task<Stocks?> DeleteStockAsync(int id)
        {
            var  stockmodel= await _context.stock.Include(x => x.comments).FirstOrDefaultAsync(p=> p.Id == id); 
            if(stockmodel==null){
                return null;
            }
            _context.stock.Remove(stockmodel);

            await _context.SaveChangesAsync();
            

            return stockmodel;
        }

        public async Task<List<Stocks>> GetAllasync(QueryObject query)
        {
            var stocks =  _context.stock.Include(p=> p.comments).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.company)){
                stocks = stocks.Where(s =>  s.company.Contains(query.company));
            }

            if(!string.IsNullOrWhiteSpace(query.symbol)){
                stocks = stocks.Where(s => s.symbol.Contains(query.symbol));
            }

            if(!string.IsNullOrWhiteSpace(query.shortBy)){
                if(query.shortBy.Equals("purchase",StringComparison.OrdinalIgnoreCase)){
                    stocks = query.IsDecsending ? stocks.OrderByDescending(p => p.purchase) : stocks.OrderBy(p => p.purchase);
                }                      
            }

            var skipnumber = (query.pageNumber -1) * query.pageSize;

            return await stocks.Skip(skipnumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<Stocks?> GetByIDasync(int id)
        {
            return await _context.stock.Include(x=> x.comments).FirstOrDefaultAsync(p=> p.Id == id );
        }

        public  Task<bool> StockExsit(int id)
        {         
            return _context.stock.AnyAsync(p => p.Id == id);         
        }

        public async Task<Stocks?> UpdateStockAsync(int id, UpdateStockDto stockmodel)
        {
            var existingStock = await _context.stock.FirstOrDefaultAsync(p=> p.Id == id);

            if(existingStock == null){
                return null;
            }

            existingStock.symbol = stockmodel.symbol;
            existingStock.company = stockmodel.company;
            existingStock.purchase = stockmodel.purchase;
            existingStock.lastdiv = stockmodel.lastdiv;
            existingStock.Industry = stockmodel.Industry;
            existingStock.maketcap = stockmodel.maketcap;

           await _context.SaveChangesAsync();

           return existingStock;
        }
    }
}