
using System.ComponentModel.DataAnnotations;
using Template_DotNet_API.Enums;

namespace Template_DotNet_API.Models.DTOs
{
    public class RegistrationRequest
    {
      [Required]
      public string? Email { get; set; }
    
      [Required]
      public string? Username { get; set; }
      
      [Required]
      public string? Password { get; set; }
      
      public Role Role { get; set; }
    }
}
