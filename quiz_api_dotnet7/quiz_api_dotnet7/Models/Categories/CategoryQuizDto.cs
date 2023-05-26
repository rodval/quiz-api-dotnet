using quiz_api_dotnet7.Models.UsersQuizzes;

namespace quiz_api_dotnet7.Models.Categories
{
    public class CategoryQuizDto
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public Category? Category { get; set; }

        public ICollection<UserQuizDto>? UserQuizzes { get; set; }
    }
}
