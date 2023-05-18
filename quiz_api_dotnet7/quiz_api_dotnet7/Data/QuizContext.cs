using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Quiz.Categories;
using quiz_api_dotnet7.Models.Quiz.UsersQuizzes;
using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizContext).Assembly);

            modelBuilder.Entity<UserQuiz>()
                        .HasOne(e => e.CategoryQuiz)
                        .WithMany(d => d.UserQuizzes)
                        .HasForeignKey(e => e.CategoryQuizId)
                        .IsRequired(true)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserQuiz>()
                .HasIndex(c => c.UserId).IsUnique(false);

            modelBuilder.Entity<UserQuiz>()
                .HasIndex(c => c.CategoryQuizId).IsUnique(false);
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Answer> Answer => Set<Answer>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<CategoryQuiz> CategoryQuizzes => Set<CategoryQuiz>();
        public DbSet<UserQuiz> UserQuizzes => Set<UserQuiz>();
    }
}
