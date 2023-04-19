using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace quiz_api_dotnet7.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string? AnswerTitle { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [JsonIgnore]
        public ICollection<Question>? Questions { get; set; }
    }
}
