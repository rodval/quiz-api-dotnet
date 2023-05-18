using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth;
using quiz_api_dotnet7.Models.Quiz.UsersQuizzes;
using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuizController : ControllerBase
    {
        private readonly IUserQuizService _service;
        private readonly IMapper _mapper;

        public UserQuizController(IUserQuizService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserQuiz>> GetAll()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.validateToken(identity);

            if (!tokenResponse.Success) return Ok(tokenResponse);

            var quizzes = _service.GetAll().Select(_mapper.Map<UserQuizDto>);

            if (quizzes is not null)
            {
                return Ok(quizzes);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<UserQuizCommandResponse> SaveUserQuiz([FromBody] UserQuiz userQuiz)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.validateToken(identity);

            if (!tokenResponse.Success) return Ok(tokenResponse);

            var quiz = _service.CheckAnsweredQuiz(userQuiz);

            if (quiz is not null)
            {
                return Ok(quiz);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
