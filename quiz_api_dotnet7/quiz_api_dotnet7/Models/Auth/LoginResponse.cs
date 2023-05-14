using NuGet.Common;
using quiz_api_dotnet7.Models.Common;

namespace quiz_api_dotnet7.Models.Auth
{
    public class LoginResponse : BaseResponse
    {
        public string? Result { get; set; }
    }
}
