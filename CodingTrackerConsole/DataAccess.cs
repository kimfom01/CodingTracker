namespace CodingTrackerConsole;

public class DataAccess
{
    public List<CodingTrackerModel> LoadData()
    {
        var databaseManager = new DatabaseManager();

        return databaseManager.ReadFromDb();
    }
}
