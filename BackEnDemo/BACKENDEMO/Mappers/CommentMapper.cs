using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Models;

namespace BACKENDEMO.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToComentDto(this Comments comments){
            return new CommentDto{
                id = comments.id,
                IdStock = comments.IdStock,
            
            };
        }

        public static CommentDto ToComentCrateDto(this Comments comments){
            return new CommentDto{
                id = comments.id,
                IdStock = comments.IdStock,
            
            };
        }
    }
}