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
using quiz_api_dotnet7.Models.Quiz.Categories;
using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.validateToken(identity);

            if (!tokenResponse.Success) return Ok(tokenResponse);

            var users = _service.GetAll().Select(_mapper.Map<UserDto>);

            if (users is not null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{userId}")]
        [Authorize]
        public ActionResult<UserDto> GetById(int userId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.validateToken(identity);

            if (!tokenResponse.Success) return Ok(tokenResponse);

            var user = _mapper.Map<UserDto>(_service.GetById(userId));

            if (user is not null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
