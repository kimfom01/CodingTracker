using System.Globalization;

namespace CodingTrackerConsole
{
    internal class Validation
    {
        public static bool IsValidDate(string date)
        {
            return DateOnly.TryParseExact(date, "MM-dd-yyyy", out _);
        }

        public bool IsValidTime(string time)
        {
            return TimeOnly.TryParseExact(time, "HH:mm", null, DateTimeStyles.None, out _);
        }
    }
}