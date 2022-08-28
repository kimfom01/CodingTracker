namespace CodingTrackerConsole
{
    public class ProgramController
    {
        static DatabaseManager dbManager = new();
        static UserInput input = new();
        static Validation dateTimeValidation = new();
        static TableVisualizationEngine displayRecords = new();

        static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("---------------------------\n");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("c to Close Application");
            Console.WriteLine("v to View All Records");
            Console.WriteLine("i to Insert a Record");
            Console.WriteLine("d to Delete a Record");
            Console.WriteLine("u to Update a Record\n");

            Console.WriteLine("Enter choice and hit Enter");
            Console.Write("Your choice? ");
        }

        static public void StartProgram()
        {
            dbManager.CreateDatabase();

            DisplayMenu();
            string choice = Console.ReadLine();
            while (choice != "c")
            {
                switch (choice)
                {
                    case "v":
                        ViewListOfRecords();
                        break;
                    case "i":
                        GetRecordsToInsert();
                        break;
                    case "d":
                        GetRecordsToDelete();
                        break;
                    case "u":
                        SelectRecordToUpdate();
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
                DisplayMenu();
                choice = Console.ReadLine();
            }
        }

        static void GetRecordsToInsert()
        {
            Console.Clear();

            string date = GetValidDate();

            string startTime = GetValidStartTime();

            string endTime = GetValidEndTime();

            string duration = input.GetDuration();

            dbManager.InsertRecord(date, startTime, endTime, duration);

            ViewListOfRecords();
        }

        static void DisplayDeleteContextMenu()
        {
            Console.WriteLine("b to Go Back");
            Console.WriteLine("d to Delete Record: ");
        }

        static void GetRecordsToDelete()
        {
            Console.Clear();
            ViewListOfRecords();

            DisplayDeleteContextMenu();
            string choice = Console.ReadLine();
            while (choice != "b")
            {
                switch (choice)
                {
                    case "d":
                        dbManager.DeleteRecord(GetId());
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
                DisplayDeleteContextMenu();
                choice = Console.ReadLine();
            }
            ViewListOfRecords();
        }

        static void DisplayUpdateContextMenu()
        {
            Console.WriteLine("Choose what to update: ");
            Console.WriteLine("d to Update Date");
            Console.WriteLine("t to Update StartTime/EndTime");
            Console.WriteLine("a to Update All");
            Console.WriteLine("b to Go Back");

            Console.Write("Your choice? ");
        }

        static void SelectRecordToUpdate()
        {
            Console.Clear();
            ViewListOfRecords();

            string? date, startTime, endTime, duration;
            dbManager.ReadFromDB();

            Console.Write("Enter Id to update: ");
            int id = Int32.Parse(Console.ReadLine());

            DisplayUpdateContextMenu();
            string choice = Console.ReadLine();
            while (choice != "b")
            {
                switch (choice)
                {
                    case "d":
                        date = GetValidDate();
                        dbManager.UpdateRecord(id, date, null, null, null);
                        break;
                    case "t":
                        startTime = GetValidStartTime();
                        endTime = GetValidEndTime();
                        duration = input.GetDuration();
                        dbManager.UpdateRecord(id, null, startTime, endTime, duration);
                        break;
                    case "a":
                        date = GetValidDate();
                        startTime = GetValidStartTime();
                        endTime = GetValidEndTime();
                        duration = input.GetDuration();
                        dbManager.UpdateRecord(id, date, startTime, endTime, duration);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
                ViewListOfRecords();
                DisplayUpdateContextMenu();
                choice = Console.ReadLine();
            }
        }

        static void ViewListOfRecords()
        {
            displayRecords.View();
        }

        static int GetId()
        {
            return Int32.Parse(Console.ReadLine());
        }

        static string GetValidDate()
        {
            while (!dateTimeValidation.IsValidDate(input.GetDate()))
            {
                Console.WriteLine("Invalid date! Expected format (mm-dd-yyyy)");
            }

            return input.Date;
        }

        static string GetValidStartTime()
        {
            while (!dateTimeValidation.IsValidStartTime(input.GetStartTime()))
            {
                Console.WriteLine("Invalid time! Expected format (hh:mm)");
            }

            return input.StartTime;
        }

        static string GetValidEndTime()
        {
            while (!dateTimeValidation.IsValidEndTime(input.GetEndTime()))
            {
                Console.WriteLine("Invalid time! Expected format (hh:mm)");
            }

            return input.EndTime;
        }
    }
}
