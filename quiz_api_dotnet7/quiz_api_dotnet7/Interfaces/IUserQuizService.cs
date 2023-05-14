using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Quiz;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IUserQuizService
    {
        public IEnumerable<UserQuiz> GetAll();
        public UserQuizResponse? CheckAnsweredQuiz(UserQuiz userQuiz);
        public UserQuizResponse? Create(UserQuiz userQuiz);
        public UserQuizResponse? Update(UserQuiz userQuiz);
    }
}
