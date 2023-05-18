using quiz_api_dotnet7.Utilities;
using System.ComponentModel.DataAnnotations;

namespace quiz_api_dotnet7.Models.Auth.Register
{
    public class RegisterRequest
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
