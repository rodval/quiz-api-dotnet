using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;


        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
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
