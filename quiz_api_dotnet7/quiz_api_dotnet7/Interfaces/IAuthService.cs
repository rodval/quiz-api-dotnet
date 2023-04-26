using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IAuthService
    {
        public LoginResponse Login(LoginRequest login);
        public RegisterResponse? Register(RegisterRequest register);
    }
}
