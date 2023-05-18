using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Quiz.Categories;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<CategoryQuiz>> GetAllByUser(int userId)
        {
            var categories = _service.GetAllByUser(userId).Select(_mapper.Map<CategoryQuizDto>);

            if (categories is not null)
            {
                return Ok(categories);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
