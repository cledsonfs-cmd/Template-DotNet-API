namespace TemplateDotNetApi
{
    public class RoleService : IRoleService
    {
        private IList<RoleModel> _roleTodos;

        public RoleService()
        {
            _roleTodos = new List<RoleModel>();
            _roleTodos.Add(
                new RoleModel()
                {
                    Id = 1,
                    nome = "ATIVO",
                    Ativo = true,
                }
            );
            _roleTodos.Add(
                new RoleModel()
                {
                    Id = 2,
                    nome = "INATIVO",
                    Ativo = true,
                }
            );
        }

        public ICollection<RoleModel> GetAll()
        {
            return _roleTodos;
        }

        public RoleModel GetOne(int id)
        {
            return _roleTodos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
