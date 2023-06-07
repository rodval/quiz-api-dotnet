using quiz_api_dotnet7.Models.Auth.SignIn;
using quiz_api_dotnet7.Models.Common;
using System.Security.Claims;

namespace quiz_api_dotnet7.Models.Auth
{
    public class CustomJwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static dynamic ValidateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new SignInResponse
                    {
                        Success = false,
                        Message = "Verificar token",
                        Result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                return new SignInResponse
                {
                    Success = true,
                    Message = "",
                    Result = id
                };
            }
            catch (Exception ex)
            {
                return new SignInResponse
                {
                    Success = false,
                    Message = "Error: " + ex.Message,
                    Result = ""
                };
            }
        }
    }
}
