using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Models
{
    [Table("Stockss")]
    public class Stocks
    {
        public int Id {get; set;}

        public string symbol {get   ; set;} =string.Empty; // get string is empty

        public string company { get ; set;} =string.Empty;

        [Column(TypeName ="decimal(18,2)")]
        public decimal purchase {get; set;}

        public decimal lastdiv { get; set; }

        public string  Industry { get; set; }= string.Empty;

        public long maketcap { get; set; }


        public List<Comments>? comments{get; set;} = new List<Comments>();

        public List<UserStock> userStocks {get; set;} = new List<UserStock>();
    }
}