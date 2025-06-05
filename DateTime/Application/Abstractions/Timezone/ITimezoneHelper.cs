namespace DateTime.Application.Abstractions.Timezone;

public interface ITimezoneHelper
{
    System.DateTime ConvertToTimezone(System.DateTime utcDateTime, string timezoneId);
}