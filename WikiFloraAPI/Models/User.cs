namespace WikiFloraAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string UserId { get; set; }
        public required string Name { get; set; }
        public required string GivenName { get; set; }
        public required string Mail { get; set; }
        public string? SocialLink { get; set; }
    }
}
