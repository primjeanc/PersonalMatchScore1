namespace LocacaoBiblioteca.Tests.Builders
{
    public class UserBuilder
    {
        private int _id;
        private string _login;
        private string _password;
        private bool _active;

        //Users = new List<User>();// CONSTRUTOR
        //    Users.Add(new User() //lista (um ou mais objetos)
        //{
        //    Login = "Admin",
        //        Password = "Admin",
        //        Ativo = true,
        //        Id = IdContador++//contador++ incrementa apos a acao . ID comecou no 1, salvaria 1, e mudaria a espera para 2.
        //                         //"++contador" incrementa antes. ID comecou no 1, salvaria 2
        //});

        //public User Build()
        //{
        //    var users = new List<User>();
        //    users.Add(new User()
        //    {
        //        Id = _id,
        //        Password = _password,
        //        Ativo = _active
        //    });
        //    return users;
        //}
        public UserBuilder WithName(string name)
        {
            _login = name;
            return this;
        }

        public UserBuilder WithPassword(string type)
        {
            _password = type;
            return this;
        }

        public UserBuilder Active()
        {
            _active = true;
            return this;
        }

        public UserBuilder Inactive()
        {
            _active = false;
            return this;
        }

        public UserBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
        //public static UserBuilder UserBuild1()
        //{
        //    var brand = new UserBuilder()
        //        .WithId(1)
        //        .WithName("Admin")
        //        .WithPassword("Admin")
        //        .Active()
        //        .Build();
        //    return brand;
        //}             
    }
}
