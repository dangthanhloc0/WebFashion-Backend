using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Helps;
using BACKENDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllCommentAsync();

        Task<Comments?> GetCommentsById(int id); 

        Task<Comments?>  UpdateComment(int id, Comments comments);

        Task<Comments?>  DeleteComment(int id);

        Task<Comments?>  AddComment(Comments comments);
    }
}