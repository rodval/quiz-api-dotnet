using AutoMapper;
using quiz_api_dotnet7.Models.Categories;
using quiz_api_dotnet7.Models.Users;
using quiz_api_dotnet7.Models.UsersQuizzes;

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
