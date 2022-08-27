using ConsoleTableExt;

namespace CodingTrackerConsole
{
    internal class TableVisualizationEngine
    {
        DatabaseManager dbManager = new();
        public void View()
        {
            Console.Clear();
            ConsoleTableBuilder.From(dbManager.ReadFromDB())
                .ExportAndWriteLine();
        }
    }
}
