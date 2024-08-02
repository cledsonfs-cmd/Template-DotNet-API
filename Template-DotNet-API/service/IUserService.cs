using Template_DotNet_API.Model;

namespace Template_DotNet_API.Service
{
    public interface IUserService
    {
        ICollection<UserModel> GetAll();
        UserModel GetOne(int id);
    }
}
