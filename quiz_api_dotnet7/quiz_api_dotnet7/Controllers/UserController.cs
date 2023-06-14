using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Auth;
using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _service.GetAll();

            if (users is not null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("CurrentUser")]
        [Authorize]
        public ActionResult<User> GetById()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.ValidateToken(identity);

            if (!tokenResponse.Success) return BadRequest(tokenResponse);

            int userId = Int32.Parse(tokenResponse.Result);

            var user = _service.GetById(userId);

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
