using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Dtos.Comment
{
    public class CreateCommentDto
    {
           public int id {get ; set;}
          public int? IdStock {get; set;}
    }
}