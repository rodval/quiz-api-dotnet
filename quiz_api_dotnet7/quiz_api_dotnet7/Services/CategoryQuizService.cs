using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Quiz.Categories;
using quiz_api_dotnet7.Utilities;
using System.Linq;

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
                           .Include(cq => cq.UserQuizzes.OrderByDescending(u => u.Score).Take(3))
                           .ThenInclude(uq => uq.User)
                           .AsNoTracking()
                           .OrderBy(cq => cq.Category)
                           .ThenBy(cq => cq.Level)
                           .ToList();
        }

        public IEnumerable<CategoryQuiz>? GetAllByUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            var categories = _context.Categories.ToList();

            if (user is null || categories is null) 
            {
                return null;
            }

            var categoryQuiz = _context.CategoryQuizzes
                                       .Include(cq => cq.UserQuizzes.Where(u => u.UserId == userId).OrderByDescending(u => u.Score).Take(1))
                                       .AsNoTracking()
                                       .ToList();

            var isCategoryQuizWithOutTry = categoryQuiz.Where(cq => cq.UserQuizzes.IsNullOrEmpty());

            var currentCategoryQuizLevel = new List<CategoryQuiz> { };

            foreach (var category in categories)
            {
                var levelCategory = isCategoryQuizWithOutTry.Where(cq => cq.CategoryId == category.Id).OrderBy(cq => cq.Level).Take(1);

                if (levelCategory.Any()) 
                {
                    currentCategoryQuizLevel.AddRange(levelCategory);
                }
            }

            return currentCategoryQuizLevel;
        }
    }
}
