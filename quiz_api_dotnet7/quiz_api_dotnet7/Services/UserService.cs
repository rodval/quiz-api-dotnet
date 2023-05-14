using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.Auth;
using quiz_api_dotnet7.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace quiz_api_dotnet7.Services
{
    public class UserService : IUserService
    {
        private readonly QuizContext _context;

        public UserService(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .AsNoTracking()
                .OrderBy(m => m.FirstName)
                .ToList();
        }

        public User? GetById(int userId)
        {
            return _context.Users
                .AsNoTracking()
                .SingleOrDefault(u => u.Id == userId);
        }
    }
}
