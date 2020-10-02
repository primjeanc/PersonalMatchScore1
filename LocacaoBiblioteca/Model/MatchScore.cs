namespace LocacaoBiblioteca.Model
{
    public class MatchScore : BaseEntity
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int MinRecordBreakCount { get; set; }
        public int MaxRecordBreakCount { get; set; }

    }
}
