using System;
using System.Collections.Generic;
using AutoMapper;
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
        public ActionResult<IEnumerable<UserQuiz>> GetAll()
        {
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
        public ActionResult<UserQuizCommandResponse> SaveUserQuiz([FromBody] UserQuiz userQuiz)
        {
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
