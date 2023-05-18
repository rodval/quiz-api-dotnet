using AutoMapper;
using quiz_api_dotnet7.Models.Quiz.Categories;
using quiz_api_dotnet7.Models.Quiz.UsersQuizzes;
using quiz_api_dotnet7.Models.Users;

namespace quiz_api_dotnet7.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CategoryQuiz, CategoryQuizDto>();
            CreateMap<UserQuiz, UserQuizDto>();
            CreateMap<User, UserDto>();
        }  
    }
}
