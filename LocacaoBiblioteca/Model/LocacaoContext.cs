using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Model
{
    public class LocacaoContext
    {
        public int IdContador { get; set; } = 1;//PRIVATE para impedir o programador adicionar ou alterar o ID de fora da classe
        public int IdHistoricoContador { get; set; } = 1;//
        public LocacaoContext()
        {
            #region RelacaoUsuarios
            ListaDeUsuarios = new List<Usuario>();// CONSTRUTOR
            ListaDeUsuarios.Add(new Usuario() //lista (um ou mais objetos)
            {
                Login = "Admin",
                Senha = "Admin",
                Ativo = true,
                Id = IdContador++//contador++ incrementa apos a acao . ID comecou no 1, salvaria 1, e mudaria a espera para 2.
                                 //"++contador" incrementa antes. ID comecou no 1, salvaria 2
            });            
            ListaDeUsuarios.Add(new Usuario()
            {
                Login = "Maria",
                Senha = "Maria",
                Ativo = true,
                Id = IdContador++
            });
            #endregion
            #region RelacaoPontuacao
            PersonalMatchScores = new List<MatchScore>();
            PersonalMatchScores.Add(new MatchScore() //lista (um ou mais objetos)
            {
                Score = 22,
                Min = 22,
                Max = 22,
                Id = IdHistoricoContador++,
                Ativo = true
            });
            PersonalMatchScores.Add(new MatchScore()
            {
                Score = 33,
                Min = 22,
                Max = 33,
                Id = IdHistoricoContador++
            });
            PersonalMatchScores.Add(new MatchScore()
            {
                Score = 11,
                Min = 11,
                Max = 33,
                Id = IdHistoricoContador++
            });
            #endregion
        }
        public List<Usuario> ListaDeUsuarios { get; set; }
        public List<MatchScore> PersonalMatchScores { get; set; }
    }
}


