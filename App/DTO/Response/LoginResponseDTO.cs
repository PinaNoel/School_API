

namespace School_API.App.DTO
{
    public class LoginResponseDTO
    {
        public required string Token { get; set; }
        public required string Role { get; set; }
    }
}