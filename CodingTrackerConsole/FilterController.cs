namespace CodingTrackerConsole;

public class FilterController
{
    private UserInput _input = new();
    private void ShowFilterMenu()
    {
        Console.WriteLine("d to filter by days");
        Console.WriteLine("m to filter by months");
        Console.WriteLine("y to filter by years");
    }

    public List<CodingTrackerModel> Filter(List<CodingTrackerModel> dataList, string filter)
    {
        var output = new List<CodingTrackerModel>();
        ShowFilterMenu();
        var choice = _input.GetChoice();
        while (choice != "b")
        {
            switch (choice)
            {
                case "d":
                    output = FilterByDays(dataList, filter);
                    break;
                case "m":
                    output = FilterByMonths(dataList, filter);
                    break;
                case "y":
                    output = FilterByYears(dataList, filter);
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }

            ShowFilterMenu();
            choice = _input.GetChoice();
        }

        return output;
    }

    private List<CodingTrackerModel> FilterByDays(List<CodingTrackerModel> dataList, string filter)
    {
        var output = dataList.Where(x => x.Date!.Substring(3, 2) == filter).ToList();

        return output;
    }

    private List<CodingTrackerModel> FilterByMonths(List<CodingTrackerModel> dataList, string filter)
    {
        var output = dataList.Where(x => x.Date!.Substring(0, 2) == filter).ToList();

        return output;
    }

    private List<CodingTrackerModel> FilterByYears(List<CodingTrackerModel> dataList, string filter)
    {
        var output = dataList.Where(x => x.Date!.Substring(6, 4) == filter).ToList();

        return output;
    }
}