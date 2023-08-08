using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiFloraAPI.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public Guid FloraId { get; set; }
        Flora? Flora { get; set; }
        public bool IsCoverPhoto { get; set; } = false;
        public required string Path { get; set; }
      //  public required  string imageName { get; set; }
        public string? Reference { get; set; }
        public string? Credit { get; set; }
    }
}
