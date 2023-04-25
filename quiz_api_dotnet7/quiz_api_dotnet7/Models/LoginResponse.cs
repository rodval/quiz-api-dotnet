using NuGet.Common;

namespace quiz_api_dotnet7.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Result { get; set; }
    }
}
