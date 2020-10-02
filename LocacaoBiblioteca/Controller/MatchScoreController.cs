using LocacaoBiblioteca.Model;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoBiblioteca.Controller
{
    public class MatchScoreController
    {
        private LocacaoContext contextDB = new LocacaoContext();//inicia a classe do LocacaoContext
        public MatchScoreController()
        {


        }

        public void AddMatchScore(MatchScore score)
        {
            
            score.Id = contextDB.IdHistoricoContador++;
            score.Min = ScoreResults(score.Score).Min;
            score.Max = ScoreResults(score.Score).Min;
            contextDB.PersonalMatchScores.Add(score);
        }

        public MatchScore ScoreResults(int score) 
        {
            var scoreResult = new MatchScore();
            //var lowestScore = 0;
            //var hightestScore = 0;
            var result = contextDB.PersonalMatchScores.Where(x => x.Ativo).ToList<MatchScore>();
            var currentLowestScore = result.Min(x => x.Score);
            var currentHightestScore = result.Max(x => x.Score);

            if (!result.Any())
            {
                scoreResult.Min = score;
                scoreResult.Max = score;
            }
            scoreResult.Min = currentLowestScore;
            scoreResult.Max = currentHightestScore;

            return scoreResult;
        }

        public int HightestScore(int score)
        {
            var hightestScore = 0;
            var result = contextDB.PersonalMatchScores.Where(x => x.Ativo).ToList<MatchScore>();
            var currentLowestScore = result.Max(x => x.Score);

            if (!result.Any())
                hightestScore = score;
            hightestScore = currentLowestScore;

            return hightestScore;
        }

        public List<MatchScore> GetMatchScores()
        {
            return contextDB.PersonalMatchScores.Where(x => x.Ativo).ToList<MatchScore>();
            //where(..ativo) onde o where procura retorno BOOLEAN do Ativo, que seriam os TRUE apenas
            //quando passa pela lambda '=>' deixa de ser lista, o ToList faz voltar a ser lista
        }

        /// <summary>
        /// Metodo para desativar registro do livro selecionado pelo ID
        /// </summary>
        /// <param name="intentificadoID"></param>
        public void RemoveScoreById(int intentificadoID)
        {
            //aqui usamos FirstOrDefault para localiza nosso usuario dentro da lista
            //com isso conseguimos acessar as propriedades dele e desativar o registro
            var livro = contextDB.PersonalMatchScores.FirstOrDefault(x => x.Id == intentificadoID);
            if (livro != null)
                livro.Ativo = false;
            //usando if(...) ao inves de usar direto '.Ativo = false' para evitar erro ao tentar remover ID que nao existe ou n foi encontrado
            //poderia usar IF no usuarioController tambem
        }
    }
}
