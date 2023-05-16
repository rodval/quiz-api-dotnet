using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Quiz;

namespace quiz_api_dotnet7.Services
{
    public class CategoryQuizService : ICategoryQuizService
    {
        private readonly QuizContext _context;

        public CategoryQuizService(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryQuiz> GetAll()
        {
            return _context.CategoryQuizzes
                           .Include(cq => cq.Category)
                           .AsNoTracking()
                           .Include(cq => cq.UserQuizzes.OrderByDescending(u => u.Score).Take(1))
                           .AsNoTracking()
                           .OrderBy(cq => cq.Category)
                           .ThenBy(cq => cq.Level)
                           .ToList();
        }
    }
}
