using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetAllComment(string floraId);
        public Task<bool> AddComment(CommentDto comment);
        public Task<bool> Reply(ReplyDto newReply);
        public Task<bool> Delete(Guid commentId);
        public Task<Comment> GetComentById(Guid id);
        public Task<bool> DeleteReply(Guid replyId);
        public Task<Reply> GetReplyById(Guid replyId);
    }
}
