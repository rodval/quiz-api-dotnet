using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuizContext _context;

        public QuestionService(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetQuizQuestion(int numberOfQuestion)
        {
            return _context.Questions
                                .Include(m => m.Answers)
                                .AsNoTracking()
                                .ToList()
                                .Take(numberOfQuestion);
        }
    }
}
