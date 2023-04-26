using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAll();
    }
}
