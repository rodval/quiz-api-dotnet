using NuGet.Common;
using quiz_api_dotnet7.Models.Common;

namespace quiz_api_dotnet7.Models.Auth.SignIn
{
    public class SignInResponse : BaseResponse
    {
        public string? Result { get; set; }
    }
}
