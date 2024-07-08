namespace TemplateDotNetApi
{
    public class UserService : IUserService
    {
        private IList<UserModel> _userTodos;

        public UserService()
        {
            _userTodos = new List<UserModel>();
            _userTodos.Add(
                new UserModel()
                {
                    Id = 1,
                    nome = "Admin",
                    email = "admin@template.com",
                    password = "admin123456",
                    Ativo = true,
                }
            );
            _userTodos.Add(
                new UserModel()
                {
                    Id = 1,
                    nome = "usuario",
                    email = "usuario@template.com",
                    password = "usuario123456",
                    Ativo = true,
                }
            );
        }

        public ICollection<UserModel> GetAll()
        {
            return _userTodos;
        }

        public UserModel GetOne(int id)
        {
            return _userTodos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
