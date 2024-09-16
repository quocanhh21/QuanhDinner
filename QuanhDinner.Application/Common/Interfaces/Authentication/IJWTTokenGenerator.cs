namespace QuanhDinner.Application.Common.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(User user);
    }
}
