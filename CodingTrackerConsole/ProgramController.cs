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
            
            while (!dateTimeValidation.IsValidDate(input.GetDate()))
            {
                Console.WriteLine("Invalid date!");
            }
            string date = input.Date;

            dbManager.DeleteRecord(date);
        }

        static void UpdateContextMenu()
        {
            Console.WriteLine("Choose what to update: ");
            Console.WriteLine("s to Update StartTime");
            Console.WriteLine("e to Update EndTime");
            Console.WriteLine("b to Go Back");
        }

        static void SelectRecordToUpdate()
        {
            displayRecords.View();

            string? startTime, endTime;
            dbManager.ReadFromDB();
            while (!dateTimeValidation.IsValidDate(input.GetDate()))
            {
                Console.WriteLine("Invalid date!");
            }
            string date = input.Date;

            UpdateContextMenu();
            string choice = Console.ReadLine();
            while (choice != "c")
            {
                switch (choice)
                {
                    case "s":
                        while (!dateTimeValidation.IsValidStartTime(input.GetStartTime()))
                        {
                            Console.WriteLine("Invalid time");
                        }
                        startTime = input.StartTime;
                        dbManager.UpdateRecord(date, startTime, null);
                        break;
                    case "e":
                        while (!dateTimeValidation.IsValidEndTime(input.GetEndTime()))
                        {
                            Console.WriteLine("Invalid time");
                        }
                        endTime = input.EndTime;
                        dbManager.UpdateRecord(date, null, endTime);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                UpdateContextMenu();
                choice = Console.ReadLine();
            }
        }

        static void ViewListOfRecords()
        {
            displayRecords.View();
        }
    }
}
