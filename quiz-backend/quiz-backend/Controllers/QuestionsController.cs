using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Gets all the questions in the database.
        /// </summary>
        /// <returns>A DbSet<Question></returns>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return context.Questions;
        }

        /// <summary>
        /// Get the questions associated with the quizId parameter
        /// </summary>
        /// <param name="quizId">The quizId for which to get questions</param>
        /// <returns>An IEnumerable of questions associated with the quizId param</returns>
        [HttpGet("{quizId}")]
        public IEnumerable<Question> Get([FromRoute] int quizId)
        {
            var questions = context.Questions.Where(q => q.QuizId == quizId);
            return questions;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Question question)
        {
            if (context.Quizzes == null || context.Quizzes.Count() == 0) 
            { 
                return BadRequest("Must have a quiz before adding quizzes."); 
            }

            context.Questions.Add(question);
            await context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Question question)
        {
            if (id != question.Id) { return BadRequest("Id parameter must match question id"); }

            context.Entry(question).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(question);
        }
    }
}