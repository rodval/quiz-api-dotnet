using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Models.UsersQuizzes
{
    public class UserQuizCommandRequest
    {
        public double? Score { get; set; }

        public int CategoryQuizId { get; set; }
    }
}
