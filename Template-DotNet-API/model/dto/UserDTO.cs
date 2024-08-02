using Template_DotNet_API.Model;

namespace Template_DotNet_API.Model.DTO
{
    public class UserDTO
    {
        public int uid { get; set; }        
        public string email { get; set; }        
        public string nome { get; set; }
        public string token { get; set; }
        public string provedor { get; set; }
        public string imageUrl { get; set; }
        public RoleModel role { get; set; }
    }
}
