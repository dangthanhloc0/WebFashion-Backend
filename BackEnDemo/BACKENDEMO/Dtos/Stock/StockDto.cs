using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Models;

namespace BACKENDEMO.Dtos.Stock
{
    public class StockDto
    {
           public int Id {get; set;}
        [Required]
        [MinLength(5,ErrorMessage ="You need to  over 5")]
        public string symbol {get   ; set;} =string.Empty; // get string is empty

        public string company { get ; set;} =string.Empty;

        public decimal purchase {get; set;}

        public decimal lastdiv { get; set; }

        public string  Industry { get; set; }= string.Empty;

        public long maketcap { get; set; }

        public  List<CommentDto> Comments{get; set;}
    }
}