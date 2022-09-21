using System.Globalization;

namespace CodingTrackerConsole
{
    internal class UserInput
    {
        private readonly Validation _dateTimeValidation = new();

        public string GetDate()
        {
            Console.Write("Enter date (mm-dd-yyyy): ");
            var date = Console.ReadLine();

            while (!_dateTimeValidation.IsValidDate(date))
            {
                Console.WriteLine("Invalid date! Expected format (mm-dd-yyyy)");
                date = Console.ReadLine();
            }

            return date;
        }

        public string GetTime()
        {
            Console.Write("Enter start time (hh:mm): ");
            var time = Console.ReadLine();

            while (!_dateTimeValidation.IsValidStartTime(time))
            {
                Console.Write("Invalid time! Expected format (hh:mm): ");
                time = Console.ReadLine();
            }

            return time;
        }

        public string GetDuration(string startTime, string endTime)
        {
            DateTime parsedStartTime = DateTime.ParseExact(startTime, "HH:mm", null, DateTimeStyles.None);
            DateTime parsedEndTime = DateTime.ParseExact(endTime, "HH:mm", null, DateTimeStyles.None);

            TimeSpan duration = parsedEndTime.Subtract(parsedStartTime);

            if (duration < TimeSpan.Zero)
            {
                duration += TimeSpan.FromDays(1);
            }

            return duration.ToString();
        }

        public string GetChoice()
        {
            return Console.ReadLine().Trim().ToLower();
        }
    }
}