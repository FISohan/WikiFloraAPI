namespace WikiFloraAPI.Models
{
    public class Flora
    {
        public Guid Id { get; set; }
        public required string banglaName { get; set; }
        public required string englishName { get; set;}
        public required List<string> othersName { get; set; }
        public required string description { get; set; }
        public required string contributer { get; set; }
        public required string coverPhotoUrl { get; set; }
        public List<string>? othersPhoto { get; set; }
        public required Hierarchy hierarchy { get; set; }
    }
}
