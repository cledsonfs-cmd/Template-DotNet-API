namespace TemplateDotNetApi
{
    public interface IUserService
    {
        ICollection<UserModel> GetAll();
        UserModel GetOne(int id);
    }
}
