using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Question>> GetQuizQuestion(int categoryQuizId, int numberOfQuestions)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.validateToken(identity);

            if (!tokenResponse.Success) return Ok(tokenResponse);

            var questions = _service.GetQuizQuestion(categoryQuizId, numberOfQuestions);

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
