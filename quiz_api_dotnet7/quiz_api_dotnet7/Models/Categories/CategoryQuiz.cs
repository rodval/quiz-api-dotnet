using quiz_api_dotnet7.Models.UsersQuizzes;

namespace quiz_api_dotnet7.Models.Categories
{
    public class CategoryQuiz
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<UserQuiz>? UserQuizzes { get; set; }
    }
}
