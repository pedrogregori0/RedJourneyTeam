using API_Teste_05_09.Context;
using API_Teste_05_09.modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Teste_05_09.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionarioController : ControllerBase
    {
        private readonly QuestionarioContext _context;
        public QuestionarioController(QuestionarioContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questionario>>> GetQuestionarios()
        {
            var questionarios = await _context.Questionario.ToListAsync();
            return Ok(questionarios);
        }
        [HttpPost]
        public async Task<IActionResult> PostQuestionario([FromBody] Questionario questionario)
        {
            if (questionario == null)
            {
                return BadRequest("Questionario é nulo.");
            }

            _context.Questionario.Add(questionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestionarios), new { Id = questionario.Id }, questionario);
        }
    }
}
