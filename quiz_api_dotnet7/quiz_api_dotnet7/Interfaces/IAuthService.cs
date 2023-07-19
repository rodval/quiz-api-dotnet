using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth.SignIn;
using quiz_api_dotnet7.Models.Auth.SignUp;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IAuthService
    {
        public SignInResponse SignIn(SignInRequest login);
        public SignUpResponse SignUp(SignUpRequest register);
    }
}
