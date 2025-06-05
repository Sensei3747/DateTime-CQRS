
namespace DateTime.Application.Abstractions.Clock;
public interface IDateTimeProvider
{
    System.DateTime UtcNow { get; }
}