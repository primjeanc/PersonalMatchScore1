using LocacaoBiblioteca.Model;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoBiblioteca.Controller
{
    public class UsuarioController
    {
        private LocacaoContext contextDB = new LocacaoContext();

        public UsuarioController()
        {
        }

        public bool Authenticate(User usuarios)
        {
            return contextDB.Users.Exists(u => u.Login == usuarios.Login && u.Password == usuarios.Password);
        }

        public void CreateUser(User usuario)
        {
            usuario.Id = contextDB.IdContador++;
            contextDB.Users.Add(usuario);
        }

        public List<User> RetornaListaDeUsuarios()
        {
            return contextDB.Users.Where(x => x.Ativo).ToList<User>();
        }

        public void DeleteUserById(int intentificadoID)
        {
            contextDB.Users.FirstOrDefault(x => x.Id == intentificadoID).Ativo = false;
        }
    }
}
