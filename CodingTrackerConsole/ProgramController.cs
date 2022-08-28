using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static public void GetUserInput()
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
            while (!dateTimeValidation.IsValidDate(input.GetDate()))
            {
                Console.WriteLine("Invalid date!");
            }
            string date = input.Date;

            while (!dateTimeValidation.IsValidStartTime(input.GetStartTime()))
            {
                Console.WriteLine("Invalid time");
            }
            string startTime = input.StartTime;

            while (!dateTimeValidation.IsValidEndTime(input.GetEndTime()))
            {
                Console.WriteLine("Invalid time");
            }
            string endTime = input.EndTime;

            string duration = input.GetDuration();

            dbManager.InsertRecord(date, startTime, endTime, duration);
        }

        // TODO: Work on the context menu

        static void DeleteContextMenu()
        {
            Console.WriteLine("b to Go Back");
            Console.WriteLine("Enter Id or record to delete: ");
        }

        static void GetRecordsToDelete()
        {
            Console.Write("Enter Id to update: ");
            int id = Int32.Parse(Console.ReadLine());

            dbManager.DeleteRecord(id);
        }

        static void DisplayUpdateContextMenu()
        {
            Console.WriteLine("Choose what to update: ");
            Console.WriteLine("d to Update Date");
            Console.WriteLine("s to Update StartTime");
            Console.WriteLine("e to Update EndTime");
            Console.WriteLine("a to Update All");
            Console.WriteLine("b to Go Back");

            Console.Write("Your choice? ");
        }

        static void SelectRecordToUpdate()
        {
            displayRecords.View();

            string? date, startTime, endTime;
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
                        dbManager.UpdateRecord(id, date, null, null);
                        break;
                    case "s":
                        startTime = GetValidStartTime();
                        dbManager.UpdateRecord(id, null, startTime, null);
                        break;
                    case "e":
                        endTime = GetValidEndTime();
                        dbManager.UpdateRecord(id, null, null, endTime);
                        break;
                    case "a":
                        date = GetValidDate();
                        startTime = GetValidStartTime();
                        endTime = GetValidEndTime();
                        dbManager.UpdateRecord(id, date, startTime, endTime);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                DisplayUpdateContextMenu();
                choice = Console.ReadLine();
            }
        }

        static void ViewListOfRecords()
        {
            displayRecords.View();
        }

        static string GetValidDate()
        {
            while (!dateTimeValidation.IsValidDate(input.GetDate()))
            {
                Console.WriteLine("Invalid date!");
            }

            return input.Date;
        }

        static string GetValidStartTime()
        {
            while (!dateTimeValidation.IsValidStartTime(input.GetStartTime()))
            {
                Console.WriteLine("Invalid time");
            }

            return input.StartTime;
        }

        static string GetValidEndTime()
        {
            while (!dateTimeValidation.IsValidEndTime(input.GetEndTime()))
            {
                Console.WriteLine("Invalid time");
            }

            return input.EndTime;
        }
    }
}
