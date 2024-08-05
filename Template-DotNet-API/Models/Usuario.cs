using Microsoft.AspNetCore.Identity;

namespace Template_DotNet_API.Models
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set;  }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public int IdStatus { get; set; }
        public int IdRole { get; set; }

    }
}
