using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Helps;
using BACKENDEMO.Models;

namespace BACKENDEMO.interfaces
{
    public interface IstockRepository
    {
        Task<List<Stocks>> GetAllasync(QueryObject query);

        Task<Stocks?> GetByIDasync(int id);
         
        Task<Stocks> CreateStockAsync(Stocks stocks);

        Task<Stocks?>  UpdateStockAsync(int id, UpdateStockDto stockmodel);

        Task<Stocks?> DeleteStockAsync(int id);

        Task<bool> StockExsit(int id);


    }
}