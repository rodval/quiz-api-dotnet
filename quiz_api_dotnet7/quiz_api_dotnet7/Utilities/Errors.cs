namespace quiz_api_dotnet7.Utilities
{
    public static class Errors
    {
        public static readonly string NotFound = "The resource was not found.";
        public static readonly string BadLogin = "Credential are not correct.";
        public static readonly string BadRequest = "Bad request.";
        public static readonly string IsEmailExist = "There is already an account with that email.";
        public static readonly string IsUserNameExist = "There is already an account with that user name.";
    }
}
