using Microsoft.EntityFrameworkCore;
using WikiFloraAPI.Data;
using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;

        public CommentService(DataContext context) {
            _context = context;
        }
        public async Task<List<Comment>> GetAllComment(string floraId)
        {
            List<Comment> comments = await _context.Comments
                .Include(c => c.Replies)
                .Where(c => c.FloraId == floraId)
                .ToListAsync();
            return comments;
        }
        public async Task<bool> AddComment(CommentDto newComment)
        {
            Comment comment = new Comment { CommentBody = newComment.CommentBody, FloraId = newComment.FloraId,UserId = newComment.UserId};
            await _context.Comments.AddAsync(comment);
            try
            {
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<Comment>GetComentById(string id)
        {
            Comment comment = await _context.Comments.FirstAsync(c => c.Id.Equals(id));
            return comment;
        }
        public async Task<bool> Delete(string commentId)
        {
            Comment comment = await GetComentById(commentId);
            _context.Comments.Remove(comment);
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }
       public async Task<bool> Reply(ReplyDto newReply)
       {
            Reply reply = new Reply { 
                CommentId = newReply.CommentId,
                ReplyBody = newReply.ReplyBody,
                ReplyerId = newReply.ReplyerId
            };

            await _context.Replies.AddAsync(reply);
            try
            {
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                return false;
            }
            return true;
       }
    }
}
