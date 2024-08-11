using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;
using BACKENDEMO.Models;

namespace BACKENDEMO.interfaces
{
    public interface IStockUserRepository
    {
        Task<List<Stocks>> GetFullStocks (AppUser user);
    }
}