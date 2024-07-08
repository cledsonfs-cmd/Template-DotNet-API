namespace TemplateDotNetApi
{
    public class StatusService : IStatusService
    {
        private IList<StatusModel> _statusTodos;

        public StatusService()
        {
            _statusTodos = new List<StatusModel>();
            _statusTodos.Add(
                new StatusModel()
                {
                    Id = 1,
                    nome = "ATIVO",
                    Ativo = true,
                }
            );
            _statusTodos.Add(
                new StatusModel()
                {
                    Id = 2,
                    nome = "INATIVO",
                    Ativo = true,
                }
            );
        }

        public ICollection<StatusModel> GetAll()
        {
            return _statusTodos;
        }

        public StatusModel GetOne(int id)
        {
            return _statusTodos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
