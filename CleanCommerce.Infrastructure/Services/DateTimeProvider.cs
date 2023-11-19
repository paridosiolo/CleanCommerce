using CleanCommerce.Application.Common.Interfaces.Services;

namespace CleanCommerce.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
