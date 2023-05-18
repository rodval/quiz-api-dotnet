using System;
using System.Collections.Generic;
using AutoMapper;
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
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
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
        public ActionResult<UserDto> GetById(int userId)
        {
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
