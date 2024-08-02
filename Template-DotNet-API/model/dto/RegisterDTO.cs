using System.ComponentModel.DataAnnotations;

namespace Template_DotNet_API.Model.DTO
{
    public class RegisterDTO
    {
        [Required]        
        public string email { get; set; }

        [Required]
        public string nome { get; set; }      

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public int idStatus { get; set; }

        [Required]
        public string role { get; set; }
    }
}
