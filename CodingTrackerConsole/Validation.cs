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
            return TimeOnly.TryParse(startTime, out StartTime);
        }

        public bool IsValidEndTime(string endTime)
        {
            return TimeOnly.TryParse(endTime, out EndTime);
        }

        public bool IsValidDuration()
        {
            return StartTime.CompareTo(EndTime) < 0;
        }
    }
}
