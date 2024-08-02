namespace Template_DotNet_API.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public DateTime DataDaAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
