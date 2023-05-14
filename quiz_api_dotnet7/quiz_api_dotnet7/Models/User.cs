using quiz_api_dotnet7.Models.Quiz;
using quiz_api_dotnet7.Utilities;
using System.ComponentModel.DataAnnotations;

namespace quiz_api_dotnet7.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public UserRoleType Role { get; set; }
    }
}
