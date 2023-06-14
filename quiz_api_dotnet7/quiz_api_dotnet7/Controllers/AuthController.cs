using Microsoft.AspNetCore.Mvc;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Auth.SignIn;
using quiz_api_dotnet7.Models.Auth.SignUp;

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
        [Route("SignIn")]
        public ActionResult<SignInResponse> SignIn([FromBody]SignInRequest login)
        {
            var response = _service.SignIn(login);

            if (response is not null)
            {
                if (!response.Success) return BadRequest(response);

                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("SignUp")]
        public ActionResult<SignUpRequest> SignUp([FromBody]SignUpRequest user)
        {
            var response = _service.SignUp(user);

            if (response is not null)
            {
                if (!response.Success) return BadRequest(user);

                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

