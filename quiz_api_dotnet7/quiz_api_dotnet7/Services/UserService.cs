using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace quiz_api_dotnet7.Services
{
    public class UserService : IUserService
    {
        private readonly QuizContext _context;
        private readonly IConfiguration _configuration;

        public UserService(QuizContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public LoginResponse Login(LoginRequest login)
        {
            if (_context.Users == null)
            {
                throw new InvalidOperationException(Erros.NotFound);
            }

            var user = _context.Users
                .Where(u => u.Email == login.Email && u.Password == login.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = true,
                    Message = Erros.BadLogin,
                    Result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<CustomJwt>();

            if (jwt == null)
            {
                return new LoginResponse
                {
                    Success = true,
                    Message = Erros.BadRequest,
                    Result = ""
                };
            }

            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, DateTime.UtcNow.ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim("role", user.Role.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: singIn
                );

            return new LoginResponse
            {
                Success = true,
                Message = "Inicio de session exitoso",
                Result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public User? GetById(int userId)
        {
            return _context.Users
                .AsNoTracking()
                .SingleOrDefault(u => u.Id == userId);
        }

        public User? PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
