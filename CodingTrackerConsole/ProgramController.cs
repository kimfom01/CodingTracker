namespace CodingTrackerConsole
{
    public static class ProgramController
    {
        private static readonly DatabaseManager DbManager = new();
        private static readonly UserInput Input = new();
        private static readonly TableVisualizationEngine DisplayRecords = new();

        private static void DisplayMenu()
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

        public static void StartProgram()
        {
            DbManager.CreateDatabase();

            DisplayMenu();
            string choice = Console.ReadLine();
            while (choice != "c")
            {
                switch (choice)
                {
                    case "v":
                        ViewRecords();
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

        private static void GetRecordsToInsert()
        {
            Console.Clear();

            string date = Input.GetDate();

            string startTime = Input.GetStartTime();

            string endTime = Input.GetEndTime();

            string duration = Input.GetDuration();

            DbManager.InsertRecord(date, startTime, endTime, duration);

            ViewRecords();
        }

        private static void DisplayDeleteContextMenu()
        {
            Console.WriteLine("b to Go Back");
            Console.WriteLine("d to Delete Record: ");
        }

        private static void GetRecordsToDelete()
        {
            Console.Clear();
            ViewRecords();

            DisplayDeleteContextMenu();
            string choice = Console.ReadLine();
            while (choice != "b")
            {
                switch (choice)
                {
                    case "d":
                        DbManager.DeleteRecord(Input.GetDate());
                        ViewRecords();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        ViewRecords();
                        break;
                }
                DisplayDeleteContextMenu();
                choice = Console.ReadLine();
            }
            ViewRecords();
        }

        private static void DisplayUpdateContextMenu()
        {
            Console.WriteLine("Choose what to update: ");
            Console.WriteLine("d to Update Date");
            Console.WriteLine("t to Update StartTime/EndTime");
            Console.WriteLine("a to Update All");
            Console.WriteLine("b to Go Back");

            Console.Write("Your choice? ");
        }

        private static void SelectRecordToUpdate()
        {
            Console.Clear();
            ViewAllRecords();

            string? newDate, startTime, endTime, duration;
            DbManager.ReadFromDb();

            string oldDate = Input.GetDate();

            DisplayUpdateContextMenu();
            string choice = Console.ReadLine();
            while (choice != "b")
            {
                switch (choice)
                {
                    case "d":
                        newDate = Input.GetDate();
                        DbManager.UpdateRecord(oldDate, newDate, null, null, null);
                        break;
                    case "t":
                        startTime = Input.GetStartTime();
                        endTime = Input.GetEndTime();
                        duration = Input.GetDuration();
                        DbManager.UpdateRecord(oldDate, null, startTime, endTime, duration);
                        break;
                    case "a":
                        newDate = Input.GetDate();
                        startTime = Input.GetStartTime();
                        endTime = Input.GetEndTime();
                        duration = Input.GetDuration();
                        DbManager.UpdateRecord(oldDate, newDate, startTime, endTime, duration);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
                ViewAllRecords();
                DisplayUpdateContextMenu();
                choice = Console.ReadLine();
            }

            Console.Clear();
        }

        private static void ViewRecords()
        {
            DisplayRecords.View();
        }

        private static void ViewAllRecords()
        {
            DisplayRecords.ViewAll();
        }
    }
}
