using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;


        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet("{categoryId}/{numberOfQuestion}")]
        public ActionResult<IEnumerable<Question>> GetQuizQuestion(int categoryId, int numberOfQuestion)
        {
            var questions = _service.GetQuizQuestion(categoryId, numberOfQuestion);

            if (questions is not null)
            {
                return Ok(questions);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
