namespace quiz_api_dotnet7.Models.Auth
{
    public class RefreshJwt
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
