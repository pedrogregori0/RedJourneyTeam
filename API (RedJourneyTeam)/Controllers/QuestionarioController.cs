using API_RedJourneyTeam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_RedJourneyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Questionario>> GetQuestionarios()
        {
            return Ok();
        }
    }
}
