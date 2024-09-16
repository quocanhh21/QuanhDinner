namespace QuanhDinner.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByEmail(string email);
    }
}
