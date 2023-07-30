namespace WikiFloraAPI.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public Guid FloraId { get; set; }
        Flora Flora { get; set; }
        public required string Url { get; set; }
        public string? Reference { get; set; }
        public string? Credit { get; set; }
    }
}
