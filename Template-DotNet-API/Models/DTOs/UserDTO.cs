using Template_DotNet_API.Enums;

namespace Template_DotNet_API.Models.DTOs
{
    public class UsuarioDTO
    {        
        public string uuid { get; set; }
        public string email { get; set; }
        public string nome { get; set; }        
        public string provedor { get; set; }
        public string imageUrl { get; set; }
        public Role role { get; set; }
    }
}