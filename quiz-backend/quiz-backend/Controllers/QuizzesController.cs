using Microsoft.AspNetCore.Mvc;
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

        // POST api/<QuizzesController>
        [HttpPost]
        public IActionResult Post([FromBody] Quiz quiz)
        {
            context.Add(quiz);
            return Ok(quiz);
        }

        // PUT api/<QuizzesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuizzesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
