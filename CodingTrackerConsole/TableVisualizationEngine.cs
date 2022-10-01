using ConsoleTableExt;

namespace CodingTrackerConsole
{
    internal class TableVisualizationEngine
    {
        private static readonly DatabaseManager DbManager = new();
        private static readonly UserInput Input = new();

        public void View()
        {
            SelectDataToView();
        }

        public void ViewAll()
        {
            Console.Clear();
            ConsoleTableBuilder
                .From(DbManager.ReadFromDb())
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
            string choice = Input.GetChoice();

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
                choice = Input.GetChoice();
            }

            Console.Clear();
        }
    }
}