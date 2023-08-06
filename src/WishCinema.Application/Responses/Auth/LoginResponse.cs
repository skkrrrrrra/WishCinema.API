namespace WishCinema.Application.Responses.Auth
{
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token;
        }
        public string Token { get; set; } = string.Empty;
    }
}
