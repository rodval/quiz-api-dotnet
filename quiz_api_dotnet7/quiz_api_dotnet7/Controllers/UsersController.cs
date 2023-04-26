using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth;

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

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
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
    }
}
