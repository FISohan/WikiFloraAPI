namespace WikiFloraAPI.Models.Dtos
{
    public class PhotoDto
    {
        public required IFormFile File { get; set; }
        public string? Reference { get; set; }
        public string? Credit { get; set; }
    }
}
