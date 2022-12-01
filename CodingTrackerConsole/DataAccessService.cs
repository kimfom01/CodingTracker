namespace CodingTrackerConsole;

public class DataAccessService
{
    public List<CodingTrackerModel> LoadData()
    {
        var databaseManager = new DatabaseManager();

        return databaseManager.ReadFromDb();
    }
}
