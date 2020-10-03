//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentAssertions;
//using LocacaoBiblioteca.Model;
//using Xunit;

//namespace LocacaoBiblioteca.Tests.Builders
//{
//    public class MatchScoreBuilder
//    {
//        private Guid _id;
//        private string _login;
//        private string _password;
//        private bool _active;

//        //public int Id { get; set; }
//        //public string Login { get; set; }
//        //public string Password { get; set; }

//        public User Build()
//        {
//            return new User(_login, _password)
//            {
//                Id = _id,
//                Active = _active
//            };
//        }
//        public UserBuilder WithName(string name)
//        {
//            _login = name;
//            return this;
//        }

//        public UserBuilder WithType(int type)
//        {
//            _password = type;
//            return this;
//        }

//        public UserBuilder Active()
//        {
//            _active = true;
//            return this;
//        }

//        public UserBuilder Inactive()
//        {
//            _active = false;
//            return this;
//        }

//        public UserBuilder WithId(Guid id)
//        {
//            _id = id;
//            return this;
//        }
//        public static UserBuilder BrandBuild()
//        {
//            var brand = new UserBuilder()
//                .WithId(new Guid("D552E358-0752-4771-AD17-08D782F5ECF9"))
//                .WithName("Subaru")
//                .WithType(0)
//                .Active()
//                .Build();
//            return brand;
//        }

//        public static UserBuilder BrandBuild2()
//        {
//            var brand = new UserBuilder()
//                .WithId(new Guid("25ba9018-4b38-481c-91c2-a8af0aae63d7"))
//                .WithName("Honda")
//                .WithType(1)
//                .Active()
//                .Build();
//            return brand;
//        }               
//    }
//}
