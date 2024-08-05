using Microsoft.AspNetCore.Identity;
using Template_DotNet_API.Enums;

namespace Template_DotNet_API.Models
{
    public class ApplicationUser: IdentityUser
    {
        public Role Role { get; set; } 
    }
}
