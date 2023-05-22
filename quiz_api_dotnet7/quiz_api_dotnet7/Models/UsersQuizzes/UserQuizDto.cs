using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Models.UsersQuizzes
{
    public class UserQuizDto
    {
        public int Id { get; set; }

        public double? Score { get; set; }

        public UserDto? User { get; set; }

        public int CategoryQuizId { get; set; }
    }
}
