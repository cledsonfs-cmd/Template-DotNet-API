using Template_DotNet_API.Model;

namespace Template_DotNet_API.Service
{
    public interface IRoleService
    {
        ICollection<RoleModel> GetAll();
        RoleModel GetOne(int id);
    }
}
