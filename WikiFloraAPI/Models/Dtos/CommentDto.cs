namespace WikiFloraAPI.Models.Dtos
{
    public class CommentDto
    {
        public required string FloraId { get; set; }
        public required string CommentBody { get; set;}
        public string UserId { get; set; }
    }
}
