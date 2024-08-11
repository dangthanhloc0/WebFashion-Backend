using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.interfaces;
using BACKENDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.Repositoory
{
    public class CommentRepository : ICommentRepository
    {

        private readonly AppplicationDBContext _context;

        public CommentRepository(AppplicationDBContext context)
        {
            _context = context ;
        }
        public async Task<Comments?> AddComment(Comments comments)
        {
            await _context.comments.AddAsync(comments);

            await _context.SaveChangesAsync();

            return comments;

        }

        public Task<Comments?> DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comments>> GetAllCommentAsync()
        {
            return await _context.comments.ToListAsync();
        }

        public async Task<Comments?> GetCommentsById(int Id)
        {
            var comment = await _context.comments.FirstOrDefaultAsync(p=> p.id == Id);

            if(comment== null){
                return null;
            }

            return comment;
        }

        public async Task<Comments?> UpdateComment(int id, Comments comments)
        {
            var Ocomment = await _context.comments.FirstOrDefaultAsync(p=> p.id == id);

            if(Ocomment== null){
                return null;
            }

            Ocomment.IdStock = comments.IdStock;
            
            await _context.SaveChangesAsync();

            return Ocomment;
        }
    }
}