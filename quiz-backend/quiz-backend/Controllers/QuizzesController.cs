using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        readonly QuizContext context;
        public QuizzesController(QuizContext context) 
        { 
            this.context = context;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Quiz> Get()
        {
            string userId = HttpContext.User.Claims.FirstOrDefault().Value;

            //if (userId is null) return Unauthorized();
            return context.Quizzes.Where(q => userId == q.OwnerId);
        }

        // POST api/<QuizzesController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid) { return  BadRequest(ModelState); }

            string? userId = HttpContext.User.Claims.FirstOrDefault().Value;
            quiz.OwnerId = userId;
            context.Quizzes.Add(quiz);
            await context.SaveChangesAsync();
            
            return CreatedAtAction("POST", quiz);
        }

        // PUT api/<QuizzesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Quiz quiz)
        {
            if (quiz.Id != id) return BadRequest("Id parameter must match quiz.Id");
            
            context.Entry(quiz).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(quiz);
        }

        // DELETE api/<QuizzesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
