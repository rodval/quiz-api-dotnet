using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();
        public User? GetById(int id);
    }
}
