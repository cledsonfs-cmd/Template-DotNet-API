using Template_DotNet_API.Enums;

namespace Template_DotNet_API.Models.DTOs
{
    public class AuthResponse
    {        
        public int Uuid { get; set; }
        public string Email { get; set; }
        public string nome { get; set; }
        public string Token { get; set; }
        public string Provedor { get; set; }
        public string ImageUrl { get; set; }
        public Role Role { get; set; }
    }
}
