using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Dtos.Stock
{
    public class UpdateStockDto
    {
        
        public string symbol {get   ; set;} =string.Empty; // get string is empty

        public string company { get ; set;} =string.Empty;

        public decimal purchase {get; set;}

        public decimal lastdiv { get; set; }

        public string  Industry { get; set; }= string.Empty;

        public long maketcap { get; set; }
    }
}