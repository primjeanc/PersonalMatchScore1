using System.Collections.Generic;

namespace LocacaoBiblioteca.Model
{
    public class LocacaoContext
    {
        public int IdContador { get; set; } = 1;
        public int IdHistoricoContador { get; set; } = 1;
        public LocacaoContext()
        {
            #region RelacaoUsuarios
            Users = new List<User>();
            Users.Add(new User()
            {
                Login = "Admin",
                Password = "Admin",
                Ativo = true,
                Id = IdContador++
            });
            Users.Add(new User()
            {
                Login = "Maria",
                Password = "Maria",
                Ativo = true,
                Id = IdContador++
            });
            #endregion          
            PersonalMatchScores = new List<MatchScore>();
        }

        public List<User> Users { get; set; }
        public List<MatchScore> PersonalMatchScores { get; set; }
    }
}


