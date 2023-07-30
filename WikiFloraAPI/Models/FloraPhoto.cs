namespace WikiFloraAPI.Models
{
    public class FloraPhoto
    {
        public Guid Id { get; set; }
        public Guid FloraId { get;set; }
        Flora Flora { get; set; }
        public required List<Photo> PhotoUrls { get; set;}
        public required Photo CoverPhotoUrl { get; set; }
    }
}
