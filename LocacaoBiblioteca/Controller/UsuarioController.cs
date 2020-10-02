using LocacaoBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Controller
{
    /// <summary>
    /// Classe que contem os metodos de usuarios do sistema
    /// </summary>
    public class UsuarioController
    {
        private LocacaoContext contextDB = new LocacaoContext();//contextDB recebe LocacaoContext para que 
        //o conteudo de LocacaoContext (como ListaDeUsuaris) seja acessivel em 'contextDB.Lista...'
        public UsuarioController()
        {
            
            
        }
        
        /// <summary>
        /// Metodo que realiza o login dentro do nosso sistema
        /// Para realizar login padrao use:
        /// Login: Admin
        /// Senha: Admin
        /// </summary>
        /// <param name="Usuario">Passamos um objeto de nome Ususario como parametro</param>        
        /// <returns>Retorna verdadeiro quando existir o usuario com este login e senha</returns>
        public bool Authenticate(User usuarios)//Usuarios= id,login,senha etc
        {
            //como a lista ja foi inicializada e salva na memoria na propria classe, o teste na LISTA de USUARIOS fica mais simples
            return contextDB.Users.Exists(u => u.Login == usuarios.Login && u.Password == usuarios.Password);
            /*if (usuarios.Login == "Admin" && usuarios.Senha == "Admin")
                return true;
            else
                return false;*/// antigo teste
        }
        
        public void CreateUser(User usuario)//cadastro de usuario na lista criada acima "ListaDeUsuarios"
        {
            usuario.Id = contextDB.IdContador++;
            contextDB.Users.Add(usuario);
        }
        /// <summary>
        /// Metodo publico pra mostrar ListaDeUsuarios ATIVOS(que esta privada na CLASSE para evitar acesso externo)
        /// </summary>
        /// <returns></returns>
        public List<User> RetornaListaDeUsuarios()
        {
            return contextDB.Users.Where(x => x.Ativo).ToList<User>();
        }
        /// <summary>
        /// Metodo que desativa um regstro de usuario cadastrado em nossa lista
        /// </summary>
        /// <param name="intentificadoID">intendifica usuario a ser desativado</param>
        public void DeleteUserById(int intentificadoID)
        {
            //aqui usamos FirstOrDefault para localiza nosso usuario dentro da lista
            //com isso conseguimos acessar as propriedades dele e desativar o registro
            contextDB.Users.FirstOrDefault(x => x.Id == intentificadoID).Ativo = false;
        }
    }
}
