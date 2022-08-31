namespace CodingTrackerConsole
{
    public class ProgramController
    {
        static DatabaseManager dbManager = new();
        static UserInput input = new();
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

            string date = input.GetDate();

            string startTime = input.GetStartTime();

            string endTime = input.GetEndTime();

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
                        dbManager.DeleteRecord(input.GetDate());
                        ViewListOfRecords();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        ViewListOfRecords();
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

            string? newDate, startTime, endTime, duration;
            dbManager.ReadFromDB();

            string oldDate = input.GetDate();

            DisplayUpdateContextMenu();
            string choice = Console.ReadLine();
            while (choice != "b")
            {
                switch (choice)
                {
                    case "d":
                        newDate = input.GetDate();
                        dbManager.UpdateRecord(oldDate, newDate, null, null, null);
                        break;
                    case "t":
                        startTime = input.GetStartTime();
                        endTime = input.GetEndTime();
                        duration = input.GetDuration();
                        dbManager.UpdateRecord(oldDate, null, startTime, endTime, duration);
                        break;
                    case "a":
                        newDate = input.GetDate();
                        startTime = input.GetStartTime();
                        endTime = input.GetEndTime();
                        duration = input.GetDuration();
                        dbManager.UpdateRecord(oldDate, newDate, startTime, endTime, duration);
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
    }
}
