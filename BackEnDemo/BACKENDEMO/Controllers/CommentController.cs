using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.Controllers
{
    [Route("v2/api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
      private readonly ICommentRepository _Comment;
      public CommentController(ICommentRepository comment)
      {
        _Comment = comment;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll(){

        var comments = await _Comment.GetAllCommentAsync();

        // var  commentDtos = comments.Select(x=> x.ToComentDto());

        return Ok(comments);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetByID([FromRoute] int id){
        var comment = await _Comment.GetCommentsById(id);
        
        if(comment==null){
          return NotFound();
        }

        return Ok(comment);
      }


      [HttpPost]
      [Route("{id}")]
      public async Task<IActionResult> Create([FromRoute] int stockId,CreateCommentDto DtoComment){

        
        return Ok(DtoComment);
      }
    }
}