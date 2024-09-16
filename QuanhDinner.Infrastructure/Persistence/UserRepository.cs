namespace QuanhDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _user = new();

        public void Add(User user)
        {
            _user.Add(user);
        }

        public User? GetByEmail(string email)
        {
            return _user.FirstOrDefault(u => u.Email == email);
        }
    }
}
