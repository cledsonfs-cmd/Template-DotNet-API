namespace TemplateDotNetApi
{
    public interface IRoleService
    {
        ICollection<RoleModel> GetAll();
        RoleModel GetOne(int id);
    }
}
