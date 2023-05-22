﻿using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Models.UsersQuizzes;

namespace quiz_api_dotnet7.Interfaces
{
    public interface IUserQuizService
    {
        public IEnumerable<UserQuiz> GetAll();
        public UserQuizCommandResponse CheckAnsweredQuiz(UserQuiz userQuiz);
        public UserQuizCommandResponse Create(UserQuiz userQuiz);
        public UserQuizCommandResponse Update(UserQuiz userQuiz);
    }
}
