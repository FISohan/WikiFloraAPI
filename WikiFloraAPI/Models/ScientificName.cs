namespace WikiFloraAPI.Models
{
    public class ScientificName
    {
        public Guid Id { get; set; }
        public Guid FloraId { get; set; }
        Flora Flora { get; set; }
        public required string Genus { get; set; }
        public required string SpecificEpithet { get; set; }
    }
}
