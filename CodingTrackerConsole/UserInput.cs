using System.Globalization;

namespace CodingTrackerConsole
{
    internal class UserInput
    {
        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string GetDate()
        {
            Console.Write("Enter date (mm-dd-yyyy): ");

            this.Date = Console.ReadLine();

            return this.Date;
        }

        public string GetStartTime()
        {
            Console.Write("Enter start time (hh:mm): ");

            this.StartTime = Console.ReadLine();

            return this.StartTime;
        }

        public string GetEndTime()
        {
            Console.Write("Enter end time (hh:mm): ");

            this.EndTime = Console.ReadLine();

            return this.EndTime;
        }

        public string GetDuration()
        {
            DateTime parsedStartTime = DateTime.ParseExact(StartTime, "HH:mm", null, DateTimeStyles.None);
            DateTime parsedEndTime = DateTime.ParseExact(EndTime, "HH:mm", null, DateTimeStyles.None);

            return parsedEndTime.Subtract(parsedStartTime).ToString();
        }
    }
}
