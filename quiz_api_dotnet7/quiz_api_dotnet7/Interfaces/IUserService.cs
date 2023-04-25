﻿using quiz_api_dotnet7.Models;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IUserService
    {
        public LoginResponse Login(LoginRequest login);
        public User? GetById(int id);
        public User? PostUser(User user);
    }
}
