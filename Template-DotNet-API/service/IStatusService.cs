using Template_DotNet_API.Model;

namespace Template_DotNet_API.Service
{
    public interface IStatusService
    {
        ICollection<StatusModel> GetAll();
        StatusModel GetOne(int id);
    }
}
