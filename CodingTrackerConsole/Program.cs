namespace CodingTrackerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string date, startTime, endTime, duration = "";

            UserInput input = new();
            Validation dateTimeValidation = new();
            while (!dateTimeValidation.IsValidDate(input.GetDate()))
            {
                Console.WriteLine("Wrong date!");
            }
            date = input.Date;

            while (!dateTimeValidation.IsValidStartTime(input.GetStartTime()))
            {
                Console.WriteLine("Wrong start time");
            }
            startTime = input.StartTime;

            while (!dateTimeValidation.IsValidEndTime(input.GetEndTime()))
            {
                Console.WriteLine("Wrong end time");
            }
            endTime = input.EndTime;

            CodingTrackerModel trackerModel = new(date, startTime, endTime);
            while (!dateTimeValidation.IsValidDuration())
            {
                Console.WriteLine("Start time and End time in wrong order");
            }
            duration = trackerModel.GetDuration();

            Console.WriteLine(duration);

            //DatabaseManager dbManager = new DatabaseManager();

            //dbManager.CreateDatabase();

            //dbManager.InsertRecord();
        }
    }
}