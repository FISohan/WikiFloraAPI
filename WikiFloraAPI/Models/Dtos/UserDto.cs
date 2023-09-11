namespace WikiFloraAPI.Models.Dtos
{
    public class UserDto
    {
        public required string UserId { get; set; }
        public required string GivenName { get; set; }
        public required string Mail { get; set; }
        public required string SocialLink { get; set; }
    }
}
