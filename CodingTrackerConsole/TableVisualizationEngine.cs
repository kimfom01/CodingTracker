using ConsoleTableExt;

namespace CodingTrackerConsole
{
    internal class TableVisualizationEngine
    {
        readonly DatabaseManager dbManager = new();

        public void View()
        {
            SelectDataToView();
        }
        public void ViewAll()
        {
            Console.Clear();
            ConsoleTableBuilder
                .From(dbManager.ReadFromDB())
                .ExportAndWriteLine();

            Console.WriteLine();
        }

        private void ViewContextMenu()
        {
            Console.WriteLine("a to View All");
            Console.WriteLine("b to Go Back");

            Console.Write("Your choice? ");
        }

        private void SelectDataToView()
        {
            ViewContextMenu();
            string choice = Console.ReadLine();

            while (choice != "e")
            {

                switch (choice)
                {
                    case "a":
                        ViewAll();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Enter choice from menu...");
                        break;
                }

                ViewContextMenu();
                choice = Console.ReadLine();
            }
            Console.Clear();
        }
    }
}
