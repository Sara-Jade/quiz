using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_backend.Models;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly QuizContext context;
        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public void Post([FromBody]Question question)
        {
            context.Questions.Add(question);
            context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return context.Questions;
            //[
            //    new Question("Ping?"),
            //    new Question("Pong?"),
            //];
        }
    }
}
