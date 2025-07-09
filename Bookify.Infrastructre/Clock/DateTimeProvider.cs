using Bookify.Application.Abstractions.Clock;

namespace Bookify.Infrastructre.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
