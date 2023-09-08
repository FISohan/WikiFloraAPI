namespace WikiFloraAPI.Models
{
    public class Reply
    {
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        Comment Comment { get; set; }
        public required  string ReplyBody { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
