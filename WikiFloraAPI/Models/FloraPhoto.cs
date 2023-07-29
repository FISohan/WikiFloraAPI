namespace WikiFloraAPI.Models
{
    public class FloraPhoto
    {
        public Guid Id { get; set; }
        public required string floraId { get; set; }
        public required string floraName { get; set; }
        public required List<Photo> photoUrls { get; set;}
        public required Photo coverPhotoUrl { get; set; }

    }
}
