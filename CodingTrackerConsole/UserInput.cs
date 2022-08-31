using System.Globalization;

namespace CodingTrackerConsole
{
    internal class UserInput
    {
        Validation dateTimeValidation = new();
        public string Date { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;

        public string EndTime { get; set; } = string.Empty;

        public string GetDate()
        {
            Console.Write("Enter date (mm-dd-yyyy): ");
            this.Date = Console.ReadLine();

            while (!dateTimeValidation.IsValidDate(this.Date))
            {
                Console.WriteLine("Invalid date! Expected format (mm-dd-yyyy)");
                this.Date = Console.ReadLine();
            }

            return this.Date;
        }

        public string GetStartTime()
        {
            Console.Write("Enter start time (hh:mm): ");
            this.StartTime = Console.ReadLine();

            while (!dateTimeValidation.IsValidStartTime(this.StartTime))
            {
                Console.Write("Invalid time! Expected format (hh:mm): ");
                this.StartTime = Console.ReadLine();
            }

            return this.StartTime;
        }

        public string GetEndTime()
        {
            Console.Write("Enter start time (hh:mm): ");
            this.EndTime = Console.ReadLine();

            while (!dateTimeValidation.IsValidStartTime(this.EndTime))
            {
                Console.Write("Invalid time! Expected format (hh:mm): ");
                this.EndTime = Console.ReadLine();
            }

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
