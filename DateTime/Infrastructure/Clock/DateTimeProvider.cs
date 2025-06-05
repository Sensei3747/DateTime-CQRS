using DateTime.Application.Abstractions.Clock;

namespace DateTime.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public System.DateTime UtcNow => System.DateTime.UtcNow;
}