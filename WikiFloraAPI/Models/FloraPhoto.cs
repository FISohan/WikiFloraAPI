namespace WikiFloraAPI.Models
{
    public class FloraPhoto
    {
        Guid Id { get; set; }
        public required string floraId { get; set; }
        public required string floraName { get; set; }
        public required List<string> photoUrls { get; set;}
        public required string coverPhotoUrl { get; set; }

    }
}
