using Microsoft.AspNetCore.Identity;
using Template_DotNet_API.Enums;

namespace Template_DotNet_API.Models.DTOs
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }
    }
}
