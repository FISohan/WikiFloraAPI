using System.ComponentModel.DataAnnotations;

namespace WikiFloraAPI.Models
{
    public class Hierarchy
    {
        
        public Guid Id { get; set; }
        public Guid FloraId { get; set; }
        Flora Flora { get; set; }
        public required string Kingdom { get; set; }
        public required string Family { get; set; }
        public required string Order { get; set; }
        public required string Genus { get; set; }
        public required string Species { get; set; }
        public required string BionomialName { get; set; }
    }
}
