using DateTime.Application.Abstractions.Timezone;

namespace DateTime.Infrastructure.Timezone;

public class TimezoneHelper : ITimezoneHelper
{
    public System.DateTime ConvertToTimezone(System.DateTime utcDateTime, string timezoneId)
    {
        try
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(System.DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc), timezone);
        }
        catch (TimeZoneNotFoundException)
        {
            return utcDateTime;
        }
        catch (InvalidTimeZoneException)
        {
            return utcDateTime;
        }
    }
}
