using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;


        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginResponse> Login(LoginRequest login)
        {
            var user = _service.Login(login);

            if (user is not null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(); 
            }
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetById(int userId)
        {
            var user = _service.GetById(userId);

            if (user is not null)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostUser(User user)
        {
            var newUser = _service.PostUser(user);
            return CreatedAtAction(nameof(GetById), new { userId = user!.Id }, user);
        }
    }
}
