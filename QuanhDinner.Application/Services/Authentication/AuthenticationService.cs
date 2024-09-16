namespace QuanhDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(
            IJWTTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // Check if user exists
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            // Check if password is correct
            if (user.Password != password)
            {
                throw new Exception("Password is incorrect");
            }

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists
            if (_userRepository.GetByEmail(email) != null)
            {
                throw new Exception("User already exists");
            }

            // Create user
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
