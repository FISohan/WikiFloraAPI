namespace WikiFloraAPI.Models.Dtos
{
    public class ReplyDto
    {
        public required Guid CommentId { get; set; }
        public required string ReplyBody { get; set; }
    }
}
