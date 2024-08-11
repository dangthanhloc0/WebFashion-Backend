using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Models;

namespace BACKENDEMO.Entity
{
    [Table("UserStocks")]
    public class UserStock
    {
        public string AppUserId { get; set; }

        public int  StockId { get; set; }
        public AppUser appUser { get; set; }

        public Stocks Stocks {get; set;}


    }
}