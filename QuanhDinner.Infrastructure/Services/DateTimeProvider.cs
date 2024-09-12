namespace QuanhDinner.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UTCNow => DateTime.UtcNow;
    }
}
