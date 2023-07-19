using quiz_api_dotnet7.Models.Categories;

namespace quiz_api_dotnet7.Interfaces
{
    public interface ICategoryQuizService
    {
        public IEnumerable<CategoryQuiz> GetAll();
        public IEnumerable<CategoryQuiz>? GetAllByUser(int userId);
    }
}
