using QuanhDinner.Application.Common.Interfaces.Authentication;

namespace QuanhDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "Quanh", "Le", " [email protected]", "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists

            // Create user

            // Generate JWT token
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firstName, lastName);

            return new AuthenticationResult(userId, "Quanh", "Le", " [email protected]", token);
        }
    }
}
