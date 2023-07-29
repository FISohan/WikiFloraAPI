namespace WikiFloraAPI.Models
{
    public class ScientificName
    {
        public Guid Id { get; set; }
        public required string genus { get; set; }
        public required string specificEpithet { get; set; }
    }
}
