﻿using Microsoft.EntityFrameworkCore;
using quiz_api_dotnet7.Data;
using quiz_api_dotnet7.Interfaces;
using quiz_api_dotnet7.Models.Quiz.UsersQuizzes;
using quiz_api_dotnet7.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quiz_api_dotnet7.Services
{
    public class UserQuizService : IUserQuizService
    {
        private readonly QuizContext _context;

        public UserQuizService(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<UserQuiz> GetAll()
        {
            return _context.UserQuizzes
                           .Include(uq => uq.User)
                           .AsNoTracking()
                           .OrderByDescending(u => u.Score)
                           .ToList();
        }

        public UserQuizCommandResponse CheckAnsweredQuiz(UserQuiz userQuiz)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userQuiz.UserId);
            var category = _context.Categories.FirstOrDefault(c => c.Id == userQuiz.CategoryQuizId);

            if (user is null || category is null)
            {
                return new UserQuizCommandResponse
                {
                    Success = false,
                    Message = Errors.NotFound
                };
            }

            var quiz = _context.UserQuizzes.Where(u => u.UserId == user.Id && u.CategoryQuizId == category.Id);

            if (quiz is not null)
            {
                return Create(userQuiz);
            }

            return Update(userQuiz);
        }

        public UserQuizCommandResponse Create(UserQuiz userQuiz) 
        {
            _context.UserQuizzes.Add(userQuiz);
            _context.SaveChanges();

            return new UserQuizCommandResponse
            {
                Success = true,
                Message = Success.SuccessProcess,
            };
        }

        public UserQuizCommandResponse Update(UserQuiz userQuiz)
        {
            var quiz = _context.UserQuizzes.FirstOrDefault(u => u.UserId == userQuiz.UserId && u.CategoryQuizId == userQuiz.CategoryQuizId);

            if (quiz is null)
            {
                return new UserQuizCommandResponse
                {
                    Success = false,
                    Message = Errors.NotFound
                };
            }

            quiz.Score = (userQuiz.Score is not null) ? userQuiz.Score : quiz.Score;

            _context.SaveChanges();

            return new UserQuizCommandResponse
            {
                Success = true,
                Message = Success.SuccessProcess,
            };
        }
    }
}
