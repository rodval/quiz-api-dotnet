using quiz_api_dotnet7.Models.Auth.Login;
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

        public static dynamic validateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new LoginResponse
                    {
                        Success = false,
                        Message = "Verificar token",
                        Result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                return new LoginResponse
                {
                    Success = true,
                    Message = "Verificar token",
                    Result = id
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Error: " + ex.Message,
                    Result = ""
                };
            }
        }
    }
}
