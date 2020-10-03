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
            score.Max = ScoreResults(score.Score).Max;
            score.MinRecordBreakCount = ScoreResults(score.Score).MinRecordBreakCount;
            score.MaxRecordBreakCount = ScoreResults(score.Score).MaxRecordBreakCount;
            contextDB.PersonalMatchScores.Add(score);
        }

        public MatchScore ScoreResults(int score) 
        {
            var scoreResult = new MatchScore();
            var lowestRecordBreak = 0;
            var highestRecordBreak = 0;

            var result = contextDB.PersonalMatchScores.Where(x => x.Ativo).ToList<MatchScore>();
            var currentLowestScore = result.Any()? result.Min(x => x.Score): score;
            var currentHightestScore = result.Any()? result.Max(x => x.Score): score;

            if (!result.Any())
            {
                scoreResult.Min = score;
                scoreResult.Max = score;
                scoreResult.MinRecordBreakCount = lowestRecordBreak;
                scoreResult.MaxRecordBreakCount = highestRecordBreak;

            }
            scoreResult.Min = currentLowestScore;
            scoreResult.Max = currentHightestScore;
            if (score < scoreResult.Min)
                scoreResult.MinRecordBreakCount++;
            if (score > scoreResult.Max)
                scoreResult.MaxRecordBreakCount++;
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
        }

        public void RemoveScoreById(int intentificadoID)
        {            
            var livro = contextDB.PersonalMatchScores.FirstOrDefault(x => x.Id == intentificadoID);
            if (livro != null)
                livro.Ativo = false;           
        }
    }
}
