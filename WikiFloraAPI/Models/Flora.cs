using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiFloraAPI.Models
{
    [Index(nameof(AlphabetIndex))]
    public class Flora
    {
        public Guid Id { get; set; }
        public required string BanglaName { get; set; }
        public int AlphabetIndex { get; set; }
        public required string OthersName { get; set; }
        public required string Description { get; set; }
        public required string Contributer { get; set; }
        public required ScientificName ScientificName { get; set; }
        public required List<Photo> Photos { get; set; }
        public required Hierarchy Hierarchy { get; set; }
    }
}
