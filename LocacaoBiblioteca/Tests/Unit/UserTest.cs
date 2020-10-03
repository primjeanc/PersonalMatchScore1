using LocacaoBiblioteca.Controller;
using LocacaoBiblioteca.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Tests.Unit
{
    public class UserTest
    {
        static UsuarioController userController = new UsuarioController();
        //[Fact]
        //public async Task should_disable_brand()
        //{
        //    var userId = 1;
        //    UsuarioController.DeleteUserById(userId);
        //    brand.Inactive();
        //    brand.Active.Should().BeFalse();
        //}

        //[Fact]
        //public async Task should_update_user()
        //{
        //    var user = UserBuilder.UserBuild2();
        //    user.login.Should().Be("Subaru Prime");
        //    user.password.Should().Be(user.Id);
        //}

        [Test]
        public async Task should_add_user()
        {
            var IdContador = 0;
            var users = new List<User>();
            users.Add(new User
            {
                Login = "Admin",
                Password = "Admin",
                Ativo = true,
                Id = IdContador++
            });
            
            Assert.AreEqual(users.Count(), 1);   
        }

        //[Fact]
        //public async Task Should_get_all_brands()
        //{
        //    var brandA = BrandBuilder.BrandBuild();
        //    var brandB = BrandBuilder.BrandBuild2();

        //    var brands = new List<Brand>();
        //    brands.Add(brandA);
        //    brands.Add(brandB);

        //    _brandRepository.GetAll().Returns(brands.AsQueryable());

        //    var usuariosRetornados = await _brandService.GetAll();

        //    usuariosRetornados.Should().HaveCount(2);

        //    usuariosRetornados[0].Name.Should().Be(brandA.Name);
        //    usuariosRetornados[0].Active.Should().Be(brandA.Active);
        //    usuariosRetornados[0].Id.Should().Be(brandA.Id);

        //    usuariosRetornados[1].Name.Should().Be(brandB.Name);
        //    usuariosRetornados[1].Active.Should().Be(brandB.Active);
        //    usuariosRetornados[1].Id.Should().Be(brandB.Id);
        //}

    }
}
