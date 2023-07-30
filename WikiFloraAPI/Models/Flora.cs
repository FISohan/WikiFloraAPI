namespace WikiFloraAPI.Models
{
    public class Flora
    {
        public Guid Id { get; set; }
        public required string BanglaName { get; set; }
      //  public Guid ScientificNameId { get; set; }
        public required ScientificName ScientificName { get; set; }
        public required string OthersName { get; set; }
        public required string Description { get; set; }
        public required string Contributer { get; set; }
       // public Guid FloraPhotoId { get; set; }
        public required FloraPhoto FloraPhoto { get; set; }
       // public required Guid HierarchyId { get; set; }
        public required Hierarchy Hierarchy { get; set; }
    }
}
