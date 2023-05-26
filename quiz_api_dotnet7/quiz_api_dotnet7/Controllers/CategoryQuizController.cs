using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Auth;
using quiz_api_dotnet7.Models.Categories;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Customer")]
    public class CategoryQuizController : ControllerBase
    {
        private readonly ICategoryQuizService _service;
        private readonly IMapper _mapper;

        public CategoryQuizController(ICategoryQuizService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryQuiz>> GetAll()
        {
            var categories = _service.GetAll().Select(_mapper.Map<CategoryQuizDto>);

            if (categories is not null)
            {
                return Ok(categories);
            }
            else 
            {
                return NotFound();
            }
        }

        [HttpGet("User")]
        public ActionResult<IEnumerable<CategoryQuiz>> GetAllByUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var tokenResponse = CustomJwt.validateToken(identity);

            if (!tokenResponse.Success) return BadRequest(tokenResponse);

            int userId = Int32.Parse(tokenResponse.Result);

            var response = _service.GetAllByUser(userId);

            if (response is not null)
            {
                var categories = response.Select(_mapper.Map<CategoryQuizDto>);

                return Ok(categories);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
