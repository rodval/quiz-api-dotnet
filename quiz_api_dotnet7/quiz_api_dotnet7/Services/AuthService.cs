using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Auth;
using quiz_api_dotnet7.Models.Auth.Login;
using quiz_api_dotnet7.Models.Auth.Register;
using quiz_api_dotnet7.Models.Users;
using quiz_api_dotnet7.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace quiz_api_dotnet7.Services
{
    public class AuthService : IAuthService
    {
        private readonly QuizContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(QuizContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public LoginResponse Login(LoginRequest login)
        {
            var user = _context.Users
                .Where(u => u.Email == login.Email || u.UserName == login.Email)
                .FirstOrDefault();

            if (user is null || user.Password is null || login.Password is null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = Errors.BadLogin,
                    Result = ""
                };
            }

            var hasherPassword = new PasswordHasher<User>().VerifyHashedPassword(null, user.Password, login.Password);

            if (hasherPassword == PasswordVerificationResult.Failed)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = Errors.BadLogin,
                    Result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<CustomJwt>();

            if (jwt == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = Errors.BadRequest,
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
                Message = Success.SuccessLogin,
                Result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public RegisterResponse? Register(RegisterRequest register)
        {
            var IsUserNameExist = _context.Users.Any(u => u.UserName == register.UserName);

            if (IsUserNameExist) 
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = Errors.IsUserNameExist
                };
            }

            var IsEmailExist = _context.Users.Any(u => u.Email == register.Email);

            if (IsEmailExist)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = Errors.IsEmailExist
                };
            }

            var user = new User
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                Role = UserRoleType.Customer
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new RegisterResponse
            {
                Success = true,
                Message = Success.SuccessRegister,
            };
        }
    }
}
