using API_RedJourneyTeam.Data;
using API_RedJourneyTeam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace API_RedJourneyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionarioController : ControllerBase
    {
        private readonly QuestionarioDBContext _context;
        public QuestionarioController(QuestionarioDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<VisitantesQuestionario>> GetQuestionarios()
        {
            var questionarios = _context.Visitantes.ToList();
            return Ok(questionarios);
        }

        [HttpGet("{Id}")]
        public ActionResult<VisitantesQuestionario> GetQuestionarioById(int id)
        {
            var resposta = _context.Visitantes.FirstOrDefault(r => r.Id == id);

            if (resposta == null)
            {
                return NotFound("Resposta não encontrada");
            }

            return Ok(resposta);
        }

        [HttpGet("Calculos")]
        public async Task<IActionResult> GetCalculosPerguntas()
        {
            try
            {
                if (!await _context.Visitantes.AnyAsync())
                {
                    return BadRequest("Tabela 'Visitantes' está vazia ou não foi possível acessar.");
                }
            }
            catch
            {
                return BadRequest("Não foi possível conectar ao banco de dados.");
            }

            var dados = await ObterDadosRespostasAsync();

            var possiveisRespostas = ObterPossiveisRespostas();

            var resumo = CalcularResumoRespostas(dados, possiveisRespostas);

            return Ok(resumo);
        }

        private async Task<List<VisitantesQuestionario>> ObterDadosRespostasAsync()
        {
            return await _context.Visitantes.ToListAsync();
        }

        private Dictionary<string, List<string>> ObterPossiveisRespostas()
        {
            return new Dictionary<string, List<string>>
            {
                { "RespostaPergunta1", new List<string> { "Muito Claras", "Claras", "Pouco Claras", "Confusas" } },
                { "RespostaPergunta2", new List<string> { "Muito", "Moderadamente", "Pouco", "Nada" } },
                { "RespostaPergunta3", new List<string> { "Muito Alta", "Alta", "Moderada", "Baixa" } }
            };
        }

        private Dictionary<string, Dictionary<string, double>> CalcularResumoRespostas(
            List<VisitantesQuestionario> dados,
            Dictionary<string, List<string>> possiveisRespostas)
        {
            var resumo = new Dictionary<string, Dictionary<string, double>>();

            var mapeamentoRespostas = new Dictionary<string, Func<VisitantesQuestionario, string>>
            {
                { "RespostaPergunta1", dado => dado.RespostaPergunta1 },
                { "RespostaPergunta2", dado => dado.RespostaPergunta2 },
                { "RespostaPergunta3", dado => dado.RespostaPergunta3 }
            };

            foreach (var pergunta in possiveisRespostas.Keys)
            {
                var contagemPergunta = InicializarContagem(possiveisRespostas[pergunta]);

                foreach (var dado in dados)
                {
                    string resposta = mapeamentoRespostas[pergunta](dado);

                    if (resposta != null && contagemPergunta.ContainsKey(resposta))
                    {
                        contagemPergunta[resposta]++;
                    }
                }

                resumo[pergunta] = CalcularPorcentagem(contagemPergunta);
            }

            return resumo;
        }

        private Dictionary<string, int> InicializarContagem(List<string> opcoes)
        {
            return opcoes.ToDictionary(opcao => opcao, opcao => 0);
        }

        private Dictionary<string, double> CalcularPorcentagem(Dictionary<string, int> contagemPergunta)
        {
            int totalRespostas = contagemPergunta.Values.Sum();

            return contagemPergunta.ToDictionary(
                kvp => kvp.Key,
                kvp => totalRespostas > 0 ? (kvp.Value / (double)totalRespostas) * 100 : 0);
        }

        [HttpPost]
        public async Task<ActionResult> PostQuestionario([FromBody] VisitantesQuestionario questionario)
        {
            if (questionario == null)
            {
                return BadRequest("Dados inválidos! Todos os campos obrigatórios devem ser preenchidos.");
            }

            _context.Visitantes.Add(questionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestionarioById), new { id = questionario.Id }, questionario);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateQuestionario(int Id, [FromBody] VisitantesQuestionario respostaAtualizada)
        {
            if (respostaAtualizada == null || respostaAtualizada.Id != Id)
            {
                return BadRequest("Os dados estão inválidos!");
            }

            var respostaExistente = _context.Visitantes.FirstOrDefault(r => r.Id == Id);

            if (respostaExistente == null)
            {
                return NotFound("Resposta não encontrada");
            }

            respostaExistente.RespostaPergunta1 = respostaAtualizada.RespostaPergunta1;
            respostaExistente.RespostaPergunta2 = respostaAtualizada.RespostaPergunta2;
            respostaExistente.RespostaPergunta3 = respostaAtualizada.RespostaPergunta3;
            respostaExistente.Nome = respostaAtualizada.Nome;
            respostaExistente.Email = respostaAtualizada.Email;
            respostaExistente.SugestaoTema = respostaAtualizada.SugestaoTema;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteQuestionario(int id)
        {
            var resposta = _context.Visitantes.FirstOrDefault(r => r.Id == id);

            if (resposta == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            _context.Visitantes.Remove(resposta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
