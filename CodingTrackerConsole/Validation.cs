using System.Globalization;

namespace CodingTrackerConsole
{
    internal class Validation
    {
        private TimeOnly StartTime;
        private TimeOnly EndTime;

        public bool IsValidDate(string date)
        {
            return DateOnly.TryParseExact(date, "MM-dd-yyyy", out DateOnly Date);
        }

        public bool IsValidStartTime(string startTime)
        {
            return TimeOnly.TryParseExact(startTime, "HH:mm", null, DateTimeStyles.None, out StartTime);
        }

        public bool IsValidEndTime(string endTime)
        {
            return TimeOnly.TryParseExact(endTime, "HH:mm", null, DateTimeStyles.None, out EndTime);
        }

        public bool IsValidDuration()
        {
            return StartTime.CompareTo(EndTime) < 0;
        }
    }
}
