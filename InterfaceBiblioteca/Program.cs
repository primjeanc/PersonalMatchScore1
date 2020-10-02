using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocacaoBiblioteca.Controller;
using LocacaoBiblioteca.Model;


namespace Interface
{
    class Program
    {              
        static MatchScoreController livroController = new MatchScoreController();//Instanciamos "Carregamos para memoria, nosso controlador de livros
        static UsuarioController usuarioController = new UsuarioController();

        static void Main(string[] args)
        {

            Console.WriteLine("SISTEMA DE LOCAÇÃO DE LIVROS 1.0");
            TrocaDeUsuario();
            MostraMenuSistema();
            Console.ReadKey();

        }
        private static void TrocaDeUsuario()// chama o teste de usuario, caso login/senha INVALIDOS, fica travado no login e acessa MENU
        {
            while (!RealizaLoginSistema())
                Console.WriteLine("Login ou senha inválido.");
        }

        /// <summary>
        /// Mostra no Console o Menu apos logar em sistema
        /// </summary>
        private static void MostraMenuSistema()
        {
            
            var opcao = int.MinValue;//variavel iniciada com menor valor de int possivel
            
            while (opcao != 0)//Menu em LOOP até que aperte 0 "zero"
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE LOCAÇÃO DE LIVROS 1.0");
                //Mostras as opcoes do menu em sistema
                Console.WriteLine("Menu Sistema:");
                Console.WriteLine("1 - Listar usuários");
                Console.WriteLine("2 - Listar Livros");
                Console.WriteLine("3 - Cadastrar Usuários");
                Console.WriteLine("4 - Cadastrar Livros");
                Console.WriteLine("5 - Troca de Usuário");
                Console.WriteLine("6 - Remover Usuário");
                Console.WriteLine("7 - Remover Livro");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                switch (opcao)
                {

                    case 1:
                        ListagemUsuarios(); Console.ReadKey();
                        break;
                    case 2:
                        ListagemLivros(); Console.ReadKey();
                        break;
                    case 3:
                        CadastraUsuario(); Console.ReadKey();
                        break;
                    case 4:
                        CadastraLivro(); 
                        break;
                    case 5:
                        TrocaDeUsuario(); 
                        break;
                    case 6:
                        RemoverUsuario();
                        break;
                    case 7:
                        RemoverLivro();
                        break;

                    case 0:
                        return;
                    default:
                        break;
                }         
            
        }             

        }
        /// <summary>
        /// Realiza login em sistema [entrando login/senha]. Retorna teste TRUE/FALSE do login [validação]
        /// </summary>
        /// <returns>Returna  TRUE-FALSE quando informado login e senha</returns>
        private static bool RealizaLoginSistema()
        {
            
            Console.WriteLine("Informe seu login e senha para acessar o sistema:");

            Console.WriteLine("Login: ");
            var loginDoUsuario = Console.ReadLine();
            Console.WriteLine("Senha: ");
            var senhaDoUsuario = Console.ReadLine();

            //UsuarioController usuarioController = new UsuarioController();//esse cara esta RESETANDO A LISTA NA HORA DE VALIDAR NOVOSO USUARIOS
            //o sistema cadastra usuarios e lista eles, mas quando vai LOGAR, os novos logins nao funcionam
            /*
             * Usuario usuario = new Usuario();//objeto usuario recebe Classe Usuario inicializada 'new'
            usuario.Login = loginDoUsuario;//atribui Login ao loginDoUsuario
            usuario.Senha = senhaDoUsuario;
            *///item para senhaDo...

            return usuarioController.LoginSistema(new Usuario()
            {
                Login = loginDoUsuario,
                Senha = senhaDoUsuario
            });
            
        }
        /// <summary>
        /// Lista todos os livros registrados
        /// </summary>
        private static void ListagemLivros()//"Retorna..Livros" =private List<Livro> ListaDeLivros {get;set;} mas usado em metodo PUBLIC para conseguir LER e nao ESCREVER
        {
            livroController.RetornaListaScore().ForEach(l => Console.WriteLine($"ID: {l.Id} -- Nome: {l.Score}"));//imprime todos os livros cadastrados
        }
        private static void ListagemUsuarios()
        {
            //mostra a lista de usuarios ja cadastrados
            Console.Clear();
            usuarioController.RetornaListaDeUsuarios().ForEach(i => Console.WriteLine($"ID: {i.Id} -- Login: {i.Login}"));
            
        }
        /// <summary>
        /// Metodo que cadastra usuarios pelo programa acessando e registrando na lista da classe
        /// </summary>
        private static void CadastraUsuario()
        {
            
            Usuario usuario = new Usuario();// inicia objeto'usuario' (lista)
            Console.WriteLine("Login a ser cadastrado:");
            usuario.Login = Console.ReadLine();
            Console.WriteLine("Senha a ser cadastrada:");
            usuario.Senha = Console.ReadLine();
            Console.WriteLine("Cadastrado com sucesso!");
            new Usuario() //lista (um ou mais objetos)
            {
                Login = usuario.Login,
                Senha = usuario.Senha,
                Ativo = true                
            };
            usuarioController.AdicionaUsuario(usuario);
        }

        /// <summary>
        /// Metodo que adiciona ("cadastra") novos livros 
        /// </summary>
        private static void CadastraLivro()
        {
            Console.WriteLine("Cadastrar livro em sistema:");
            Console.WriteLine("Informe o título de livro");
            var nomeDoLivro = int.Parse(Console.ReadLine());
            livroController.AdicionarLivro(new MatchScore()//livroControler objeto(variavel) que recebeu a CLASSE LISTA LivroController
            {
                Score = nomeDoLivro //,
                //Id = livroController.ListaDeLivros.Count+1
            });
            Console.WriteLine("Livro cadastrado com sucesso.");
            Console.ReadKey();
        }

        /// <summary>
        /// Metodo que desativa registro (troca Ativo TRUE por FALSE
        /// ocultando da lista pois a mesma retorna apenas ativo igual a true
        /// </summary>
        private static void RemoverUsuario()
        {
            Console.WriteLine("Desativação de Usuários");
            ListagemUsuarios();//chama o metodo que ja mostrava lista de usuarios
            Console.WriteLine("Informe o ID do usuário a ser desativado:");
            var usuarioID = int.Parse(Console.ReadLine());
            //metodo da classe recebe variavel INT "usuarioID" do programa para conferir remocao
            usuarioController.RemoverUsuarioPorID(usuarioID);

            Console.WriteLine("Usuário desativado!");//retorna mensagem apos remover/desativar usuario
            Console.ReadKey();

        }
        private static void RemoverLivro()
        {
            Console.WriteLine("Remoção de exemplar/livro do catálogo");
            ListagemLivros();//chama o metodo que ja mostrava lista de livros
            Console.WriteLine("Informe o ID do livro a ser desativado:");
            var livroID = int.Parse(Console.ReadLine());
            
            livroController.RemoverLivroPorID(livroID);

            Console.WriteLine("Exemplar removido!");//retorna mensagem apos remover/desativar usuario
            Console.ReadKey();
        }

    }
}
