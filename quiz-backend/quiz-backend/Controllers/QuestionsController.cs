using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_backend.Models;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody]Question question)
        {
            
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return
            [
                new Question("Ping?"),
                new Question("Pong?"),
            ];
        }
    }
}
