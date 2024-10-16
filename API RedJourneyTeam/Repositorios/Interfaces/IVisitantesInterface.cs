using API_RedJourneyTeam.Models;

namespace API_RedJourneyTeam.Repositorios.Interfaces
{
    public interface IVisitantesInterface
    {
        Task<List<VisitantesQuestionario>> BuscarTodosUsuarios();
        Task<VisitantesQuestionario> BuscarPorID(int id);
        Task<VisitantesQuestionario> Adicionar(VisitantesQuestionario visitantes);
        Task<VisitantesQuestionario> Atualizar(VisitantesQuestionario visitantes, int id);
        Task<bool> Apagar(int id);

    }
}
