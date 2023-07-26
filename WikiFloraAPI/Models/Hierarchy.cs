using System.ComponentModel.DataAnnotations;

namespace WikiFloraAPI.Models
{
    public class Hierarchy
    {
        
        public required string kingdom { get; set; }
        public required string family { get; set; }
        public required string order { get; set; }
        public required string genus { get; set; }
        public required string species { get; set; }
        public required string bionomialName { get; set; }
    }
}
