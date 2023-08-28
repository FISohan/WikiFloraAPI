namespace WikiFloraAPI.Models.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; }
        public required string Name { get; set; }
        public required string Mail { get; set; }
        public required string SocialLink { get; set; }
    }
}
