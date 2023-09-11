
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;
using WikiFloraAPI.Services;

namespace WikiFloraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("get/allComment")]
        public async Task<ActionResult<List<Comment>>> GetAllComment(string florId)
        {
            return Ok( await _commentService.GetAllComment(florId));
        }

        [HttpPost("post")]
        public async Task<ActionResult<bool>> PostComment(CommentDto comment)
        {
            bool? isAtuth = User.Identity?.IsAuthenticated;
            if (isAtuth is not true) comment.UserId = "Anonymous";
            else
            {
                string userId = ClaimService.getClaimData(User.Claims).sub;
                comment.UserId = userId;
            }
            bool success = await _commentService.AddComment(comment);
            if (!success) return NoContent();
            return Ok(success);
        }

        [HttpPost("reply")]
        public async Task<ActionResult<bool>> Reply(ReplyDto replyDto)
        {
            bool? isAtuth = User.Identity?.IsAuthenticated;
            if (isAtuth is null || isAtuth is not true) replyDto.ReplyerId = "Anonymous";
            else
            {
                string userId = ClaimService.getClaimData(User.Claims).sub;
                replyDto.ReplyerId = userId;
            }
            bool sucess = await _commentService.Reply(replyDto);
            if (!sucess) return BadRequest();
            return Ok(sucess); 
        }
        [Authorize("Admin")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteComment(Guid commentId)
        {
            bool sucess = await _commentService.Delete(commentId);
            if (!sucess) return NoContent();
            return Ok(sucess);
        }
        [Authorize("Admin")]
        [HttpDelete("reply/delete")]
        public async Task<ActionResult<bool>> DeleteReply(Guid replyId) {
            bool res = await _commentService.DeleteReply(replyId);
            if (!res) return NoContent();
            return Ok(res);
        }
    }
}
