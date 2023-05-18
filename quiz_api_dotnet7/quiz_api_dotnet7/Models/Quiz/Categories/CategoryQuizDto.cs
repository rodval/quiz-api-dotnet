using quiz_api_dotnet7.Models.Quiz.UsersQuizzes;

namespace quiz_api_dotnet7.Models.Quiz.Categories
{
    public class CategoryQuizDto
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public int CategoryId { get; set; }

        public ICollection<UserQuizDto>? UserQuizzes { get; set; }
    }
}
