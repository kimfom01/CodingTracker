using ConsoleTableExt;

namespace CodingTrackerConsole
{
    internal class TableVisualizationEngine
    {
        private static readonly DatabaseManager DbManager = new();
        private static readonly UserInput Input = new();

        public void View<TTableData>(List<TTableData> dataList)
        {
            SelectDataToView(dataList);
        }

        public void BuildTable<TTableData>(List<TTableData> dataList) where TTableData : class
        {
            Console.Clear();
            ConsoleTableBuilder
                // .From(DbManager.ReadFromDb())
                .From(dataList)
                .ExportAndWriteLine();

            Console.WriteLine();
        }

        private void ViewContextMenu()
        {
            Console.WriteLine("a to View All");
            Console.WriteLine("b to Go Back");

            Console.Write("Your choice? ");
        }

        private void SelectDataToView<TTableData>(List<TTableData> dataList)
        {
            ViewContextMenu();
            string choice = Input.GetChoice();

            while (choice != "b")
            {
                switch (choice)
                {
                    case "a":
                        View(dataList);
                        break;
                    case "":
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