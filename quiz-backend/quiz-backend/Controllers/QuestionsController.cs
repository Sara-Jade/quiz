using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "Pong";
        }
    }
}
