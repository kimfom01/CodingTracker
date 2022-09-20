using ConsoleTableExt;

namespace CodingTrackerConsole
{
    internal class TableVisualizationEngine
    {
        readonly DatabaseManager _dbManager = new();

        public void View()
        {
            SelectDataToView();
        }
        public void ViewAll()
        {
            Console.Clear();
            ConsoleTableBuilder
                .From(_dbManager.ReadFromDb())
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

            while (choice != "b")
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
