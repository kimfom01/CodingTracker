namespace CodingTrackerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager dbManager = new DatabaseManager();

            dbManager.CreateDatabase();

            dbManager.InsertRecord();
        }
    }
}