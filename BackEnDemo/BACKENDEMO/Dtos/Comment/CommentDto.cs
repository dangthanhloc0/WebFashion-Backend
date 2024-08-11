using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Models;

namespace BACKENDEMO.Dtos.Comment
{
    public class CommentDto
    {
      public int id {get ; set;}
      public int? IdStock {get; set;}
    }
}