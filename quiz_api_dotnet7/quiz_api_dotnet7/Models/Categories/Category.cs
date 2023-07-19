using System.ComponentModel.DataAnnotations;

namespace quiz_api_dotnet7.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Image { get; set; }
    }
}
