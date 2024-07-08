namespace TemplateDotNetApi
{
    public interface IStatusService
    {
        ICollection<StatusModel> GetAll();
        StatusModel GetOne(int id);
    }
}
