using Microsoft.EntityFrameworkCore;
using API_RedJourneyTeam.Data;
using API_RedJourneyTeam.Models;
using API_RedJourneyTeam.Repositorios.Interfaces;

namespace API_RedJourneyTeam.Repositorios
{
    public class VisitanteRepositorio : IVisitantesInterface
    {
        private readonly QuestionarioDBContext _dBContext;
        public VisitanteRepositorio(QuestionarioDBContext questionarioDBContext)
        {
         _dBContext = questionarioDBContext;
        }
        public async Task<VisitantesQuestionario> BuscarPorID(int id)
        {
            return await _dBContext.Visitantes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VisitantesQuestionario>> BuscarTodosUsuarios()
        {
            return await _dBContext.Visitantes.ToListAsync();
        }
        public async Task<VisitantesQuestionario> Adicionar(VisitantesQuestionario visitantes)
        {
            await _dBContext.Visitantes.AddAsync(visitantes);
            await _dBContext.SaveChangesAsync();
            return visitantes;
        }
         
        public async Task<VisitantesQuestionario> Atualizar(VisitantesQuestionario visitantes, int id)
        {
            VisitantesQuestionario visitantePorId = await BuscarPorID(id);

            if(visitantePorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado.");
            }

            visitantePorId.Nome = visitantes.Nome;
            visitantePorId.Email = visitantes.Email;
            visitantePorId.RespostaPergunta1 = visitantes.RespostaPergunta1;
            visitantePorId.RespostaPergunta2 = visitantes.RespostaPergunta2;
            visitantePorId.RespostaPergunta3 = visitantes.RespostaPergunta3;
            visitantePorId.SugestaoTema = visitantes.SugestaoTema;

            _dBContext.Visitantes.Update(visitantePorId);
            await _dBContext.SaveChangesAsync();

            return visitantePorId;
        }
        public async Task<bool> Apagar(int id)
        {
            VisitantesQuestionario visitantePorId = await BuscarPorID(id);

            if (visitantePorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado.");
            }

            _dBContext.Visitantes.Remove(visitantePorId);
            await _dBContext.SaveChangesAsync();
            return true;
        
        }


        
    }
}
