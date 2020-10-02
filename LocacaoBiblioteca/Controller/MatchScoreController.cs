using LocacaoBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Controller
{
    public class MatchScoreController
    {
        private LocacaoContext contextDB = new LocacaoContext();//inicia a classe do LocacaoContext
        public MatchScoreController()
        {
            

        }    
       
        public void AdicionarLivro(MatchScore livro)
        {
            livro.Id = contextDB.IdHistoricoContador++;
            contextDB.PersonalMatchScores.Add(livro);
        }
        public List<MatchScore> RetornaListaScore()
        {
            return contextDB.PersonalMatchScores.Where(x => x.Ativo).ToList<MatchScore>(); 
            //where(..ativo) onde o where procura retorno BOOLEAN do Ativo, que seriam os TRUE apenas
            //quando passa pela lambda '=>' deixa de ser lista, o ToList faz voltar a ser lista
        }

        /// <summary>
        /// Metodo para desativar registro do livro selecionado pelo ID
        /// </summary>
        /// <param name="intentificadoID"></param>
        public void RemoverLivroPorID(int intentificadoID)
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
