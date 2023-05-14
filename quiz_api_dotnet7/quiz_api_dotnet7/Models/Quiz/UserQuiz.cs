﻿using System.ComponentModel.DataAnnotations.Schema;

namespace quiz_api_dotnet7.Models.Quiz
{
    public class UserQuiz
    {
        public int Id { get; set; }

        public double? Score { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}