using System.ComponentModel.DataAnnotations.Schema;
using quiz_api_dotnet7.Models.Categories;
using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Models.UsersQuizzes
{
    public class UserQuiz
    {
        public int Id { get; set; }

        public double? Score { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int CategoryQuizId { get; set; }
        public CategoryQuiz? CategoryQuiz { get; set; }
    }
}
