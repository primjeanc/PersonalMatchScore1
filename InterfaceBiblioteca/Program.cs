using LocacaoBiblioteca.Controller;
using LocacaoBiblioteca.Model;
using System;

namespace Interface
{
    class Program
    {
        static MatchScoreController matchScoreController = new MatchScoreController();
        static UsuarioController userController = new UsuarioController();

        static void Main(string[] args)
        {
            string title = "SISTEMA DE PONTUAL PESSOAL POR PARTIDAS 1.0";
            Console.WriteLine(title);
            SwitchUser();
            MostraMenuSistema();
            Console.ReadKey();

        }
        private static void SwitchUser()
        {
            while (!RealizaLoginSistema())
                Console.WriteLine("Login ou senha inválido.");
        }
 
        private static void MostraMenuSistema()
        {

            var opcao = int.MinValue;

            while (opcao != 0)//Menu em LOOP até que aperte 0 "zero"
            {
                Console.Clear();
                string titulo = "SISTEMA DE PONTUAL PESSOAL POR PARTIDAS 1.0";
                string mensagemPadrao = "Aperte qualquer tecla para retornar ao MENU";
                Console.WriteLine(titulo);
                //Mostras as opcoes do menu em sistema
                Console.WriteLine("Menu Sistema:");
                Console.WriteLine("1 - Listar usuários");
                Console.WriteLine("2 - Listar Pontuação Pessoal");
                Console.WriteLine("3 - Cadastrar Usuários");
                Console.WriteLine("4 - Cadastrar Resultado da Partida");
                Console.WriteLine("5 - Troca de Usuário");
                Console.WriteLine("6 - Remover Usuário");
                Console.WriteLine("7 - Remover Resultado");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                switch (opcao)
                {

                    case 1:
                        GetUsers(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        GetMatchScores();
                        Console.WriteLine(mensagemPadrao);
                        Console.ReadKey();
                        break;
                    case 3:
                        CreateUser(); Console.ReadKey();
                        break;
                    case 4:
                        AddPersonalMatchScore();
                        break;
                    case 5:
                        SwitchUser();
                        break;
                    case 6:
                        DeleteUser();
                        break;
                    case 7:
                        RemoveScoreById();
                        break;

                    case 0:
                        return;
                    default:
                        break;
                }

            }

        }
  
        private static bool RealizaLoginSistema()
        {

            Console.WriteLine("Informe seu login e senha para acessar o sistema:");

            Console.WriteLine("Login: ");
            var loginDoUsuario = Console.ReadLine();
            Console.WriteLine("Senha: ");
            var senhaDoUsuario = Console.ReadLine();

            return userController.Authenticate(new User()
            {
                Login = loginDoUsuario,
                Password = senhaDoUsuario
            });

        }

        private static void GetMatchScores()
        {
            Console.WriteLine($"Jogo|Placar|Mínimo da Temporada|Máximo da Temporada|Quebra Recorde Mínimo|Quebra Recorde Máximo");
            matchScoreController.GetMatchScores().ForEach(l => Console.WriteLine($"{l.Id}      {l.Score}            {l.Min}                 {l.Max}                  {l.MinRecordBreakCount}                 {l.MaxRecordBreakCount}"));
        }
        private static void GetUsers()
        {
            Console.Clear();
            userController.RetornaListaDeUsuarios().ForEach(i => Console.WriteLine($"ID: {i.Id} -- Login: {i.Login}"));

        }

        private static void CreateUser()
        {

            User user = new User();
            Console.WriteLine("Login a ser cadastrado:");
            user.Login = Console.ReadLine();
            Console.WriteLine("Senha a ser cadastrada:");
            user.Password = Console.ReadLine();
            Console.WriteLine("Cadastrado com sucesso!");
            new User()
            {
                Login = user.Login,
                Password = user.Password,
                Ativo = true
            };
            userController.CreateUser(user);
        }

        private static void AddPersonalMatchScore()
        {
            Console.WriteLine("Cadastrar Novo Resultado");
            Console.WriteLine("Informe sua pontuaçao pessoal da partida");
            var nomeDoLivro = int.Parse(Console.ReadLine());
            matchScoreController.AddMatchScore(new MatchScore()
            {
                Score = nomeDoLivro      
            });
            Console.WriteLine("Livro cadastrado com sucesso.");
            Console.ReadKey();
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Desativação de Usuários");
            GetUsers();
            Console.WriteLine("Informe o ID do usuário a ser desativado:");
            var usuarioID = int.Parse(Console.ReadLine());
            
            userController.DeleteUserById(usuarioID);

            Console.WriteLine("Usuário desativado!");
            Console.ReadKey();

        }
        private static void RemoveScoreById()
        {
            Console.WriteLine("Remoção de Resultado");
            GetMatchScores();
            Console.WriteLine("Informe o ID do resultado a ser removido:");
            var livroID = int.Parse(Console.ReadLine());

            matchScoreController.RemoveScoreById(livroID);

            Console.WriteLine("Exemplar removido!");
            Console.ReadKey();
        }

    }
}
