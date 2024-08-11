using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Dtos.Stock
{
    public class CreateStockRequest
    {

        public string symbol {get   ; set;} =string.Empty; 
         public string company { get ; set;} =string.Empty;

        public decimal purchase {get; set;}

        public decimal lastdiv { get; set; }

        public string  Industry { get; set; }= string.Empty;

        public long maketcap { get; set; }
    }
}