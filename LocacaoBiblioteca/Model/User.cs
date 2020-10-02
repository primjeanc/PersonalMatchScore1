namespace LocacaoBiblioteca.Model
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
