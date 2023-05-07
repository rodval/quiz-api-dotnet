﻿using Microsoft.AspNetCore.Identity;
using quiz_api_dotnet7.Models;
using quiz_api_dotnet7.Utilities;

namespace quiz_api_dotnet7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(QuizContext context)
        {

            if (context.Users.Any()
                && context.Categories.Any()
                && context.Questions.Any())
            {
                return;   // DB has been seeded
            }

            var hasher = new PasswordHasher<User>();

            var users = new User[]
            {
                new User
                {
                    FirstName = "Rodrigo",
                    LastName = "Valladares",
                    UserName = "rod",
                    Email = "rodrigovalladares@gmail.com",
                    Password = hasher.HashPassword(null, "P@ssword1"),
                    Role = UserRoleType.Administrator
                },
                new User
                {
                    FirstName = "Daniel",
                    LastName = "Sanchez",
                    UserName = "dan",
                    Email = "danielsanchez@gmail.com",
                    Password = hasher.HashPassword(null, "P@ssword1"),
                    Role = UserRoleType.Customer
                }
            };

            var categories = new Category[]
            {
                new Category
                {
                    Id = 1,
                    Title = "Propiedad Intelectual",
                },
                new Category
                {
                    Id = 2,
                    Title = "Matematicas",
                }
            };

            var questions = new Question[]
            {
                new Question
                {
                    QuestionTitle = "A Daniel Sanchez lo tienen bien controlad?",
                    QuestionType = QuestionType.TrueOrFalse,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Falso",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "Rodrigo Lobo es adicto a LOL?",
                    QuestionType = QuestionType.TrueOrFalse,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Verdadero",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "Falso",
                            IsCorrect = false
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "2 + 2 es 6?",
                    QuestionType = QuestionType.TrueOrFalse,
                    CategoryId = 1,
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            AnswerTitle = "Verdadero",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "Falso",
                            IsCorrect = true
                        }
                    }
                },
                new Question
                {
                    QuestionTitle = "Quien es la dueña de la quincena de Rogelio?",
                    QuestionType = QuestionType.TrueOrFalse,
                    CategoryId = 2,
                    Answers = new Answer[] 
                    {
                        new Answer 
                        {
                            AnswerTitle = "Mafer",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            AnswerTitle = "La PC cerda",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "LOL",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            AnswerTitle = "El gym y sus productos de dudosa procedencia",
                            IsCorrect = false
                        }
                    }
                },
            };

            context.Users.AddRange(users);
            context.Categories.AddRange(categories);
            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
