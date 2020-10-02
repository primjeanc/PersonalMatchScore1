namespace LocacaoBiblioteca.Model
{
    public class Usuario : BaseEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
