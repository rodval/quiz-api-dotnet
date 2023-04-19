using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Answer> Answer => Set<Answer>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Question> Questions => Set<Question>();
    }
}
