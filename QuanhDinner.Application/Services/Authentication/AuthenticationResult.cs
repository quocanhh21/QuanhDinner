namespace QuanhDinner.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
