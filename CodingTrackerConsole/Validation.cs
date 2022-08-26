namespace CodingTrackerConsole
{
    internal class Validation
    {
        UserInput input = new UserInput();
        TimeOnly startTime;
        TimeOnly endTime;

        public bool IsValidDate()
        {
            DateOnly date;
            return DateOnly.TryParse(input.Date, out date);
        }

        public bool IsValidStartTime()
        {
            return TimeOnly.TryParse(input.StartTime, out startTime);
        }

        public bool IsValidEndTime()
        {
            return TimeOnly.TryParse(input.EndTime, out endTime);
        }

        public bool IsValidDuration()
        {
            return startTime.CompareTo(endTime) < 0;
        }
    }
}
