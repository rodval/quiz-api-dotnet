using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Quiz;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryQuizController : ControllerBase
    {
        private readonly ICategoryQuizService _service;

        public CategoryQuizController(ICategoryQuizService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryQuiz>> GetAll()
        {
            var categories = _service.GetAll();

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
