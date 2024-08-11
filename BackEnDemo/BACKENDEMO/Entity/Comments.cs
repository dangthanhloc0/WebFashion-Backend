using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.Models
{

  [Table("Commentss")]
    public class Comments
    {

      public int id {get ; set;}
      public int? IdStock {get; set;}

      public Stocks ? Stock {get; set;}

      
      
    }
}