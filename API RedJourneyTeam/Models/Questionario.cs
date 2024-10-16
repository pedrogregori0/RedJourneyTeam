namespace API_RedJourneyTeam.Models
{
    public class VisitantesQuestionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string RespostaPergunta1 { get; set; }
        public string RespostaPergunta2 { get; set; }
        public string RespostaPergunta3 { get; set; }
        public string? SugestaoTema { get; set; }
    }
}
