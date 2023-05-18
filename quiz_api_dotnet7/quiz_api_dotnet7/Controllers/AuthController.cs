using Microsoft.AspNetCore.Mvc;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Auth.Login;
using quiz_api_dotnet7.Models.Auth.Register;

namespace quiz_api_dotnet7.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginResponse> Login([FromBody]LoginRequest login)
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

        [HttpPost]
        [Route("Register")]
        public ActionResult<RegisterRequest> Register([FromBody]RegisterRequest user)
        {
            var response = _service.Register(user);

            if (response is not null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

