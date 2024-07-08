namespace TemplateDotNetApi
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public DateTime DataDaAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
