namespace WikiFloraAPI.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public required string FloraId { get; set; }
        public required string CommentBody { get; set; }
        public List<Reply>? Replies { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
