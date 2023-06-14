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
using quiz_api_dotnet7.Models.Users;
using quiz_api_dotnet7.Models.UsersQuizzes;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Customer")]
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
        public ActionResult<UserQuizCommandResponse> SaveUserQuiz([FromBody] UserQuizCommandRequest userQuiz)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.ValidateToken(identity);

            if (!tokenResponse.Success) return BadRequest(tokenResponse);

            int userId = Int32.Parse(tokenResponse.Result);

            var response = _service.CheckAnsweredQuiz(userQuiz, userId);

            if (response is not null && response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
