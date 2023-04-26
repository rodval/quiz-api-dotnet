using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IQuestionService
    {
        public IEnumerable<Question> GetQuizQuestion(int numberOfQuestion);
    }
}
