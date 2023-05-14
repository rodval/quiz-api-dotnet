using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly QuizContext _context;

        public CategoryService(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories
                           .Include(c => c.userQuizzes.OrderByDescending(u => u.Score).Take(1))
                           .AsNoTracking()
                           .OrderBy(m => m.Title)
                           .ToList();
        }
    }
}
