namespace quiz_api_dotnet7.Models.Quiz
{
    public class CategoryQuiz
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public ICollection<UserQuiz>? UserQuizzes { get; set; }
    }
}
