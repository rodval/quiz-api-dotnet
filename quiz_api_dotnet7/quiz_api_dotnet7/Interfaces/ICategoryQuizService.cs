using quiz_api_dotnet7.Models.Quiz;

namespace quiz_api_dotnet7.Interfaces
{
    public interface ICategoryQuizService
    {
        public IEnumerable<CategoryQuiz> GetAll();
    }
}
