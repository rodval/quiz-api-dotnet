using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Quiz;
using quiz_api_dotnet7.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quiz_api_dotnet7.Services
{
    public class UserQuizService : IUserQuizService
    {
        private readonly QuizContext _context;

        public UserQuizService(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<UserQuiz> GetAll()
        {
            return _context.UserQuizzes
                           .OrderByDescending(u => u.Score)
                           .ToList();
        }

        public UserQuizResponse? CheckAnsweredQuiz(UserQuiz userQuiz)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userQuiz.UserId);
            var category = _context.Categories.FirstOrDefault(c => c.Id == userQuiz.CategoryId);

            if (user is null || category is null)
            {
                throw new InvalidOperationException(Errors.NotFound);
            }

            var quiz = _context.UserQuizzes.Where(u => u.UserId == user.Id && u.CategoryId == category.Id);

            if (quiz is not null)
            {
                return Create(userQuiz);
            }

            return Update(userQuiz);
        }

        public UserQuizResponse? Create(UserQuiz userQuiz) 
        {
            _context.UserQuizzes.Add(userQuiz);
            _context.SaveChanges();

            return new UserQuizResponse
            {
                Success = true,
                Message = Success.SuccessUserQuiz,
            };
        }

        public UserQuizResponse? Update(UserQuiz userQuiz)
        {
            var quiz = _context.UserQuizzes.FirstOrDefault(u => u.UserId == userQuiz.UserId && u.CategoryId == userQuiz.CategoryId);

            if (quiz is null)
            {
                throw new InvalidOperationException(Errors.NotFound);
            }

            quiz.Score = (userQuiz.Score is not null) ? userQuiz.Score : quiz.Score;

            _context.SaveChanges();

            return new UserQuizResponse
            {
                Success = true,
                Message = Success.SuccessUserQuiz,
            };
        }
    }
}
