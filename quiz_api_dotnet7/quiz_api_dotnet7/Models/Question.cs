using quiz_api_dotnet7.Models.Quiz;
using quiz_api_dotnet7.Utilities;
using System.ComponentModel.DataAnnotations;

namespace quiz_api_dotnet7.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string? QuestionTitle { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        public ICollection<Answer>? Answers { get; set; }

        public int Level { get; set; }

        public int CategoryQuizId { get; set; }
        public CategoryQuiz? CategoryQuiz { get; set; }
    }
}
