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

    public void Filter(List<CodingTrackerModel> dataList, string filter)
    {
        ShowFilterMenu();
        var choice = _input.GetChoice();
        while (choice != "b")
        {
            switch (choice)
            {
                case "d":
                    FilterByDays(dataList, filter);
                    break;
                case "m":
                    FilterByMonths(dataList, filter);
                    break;
                case "y":
                    FilterByYears(dataList, filter);
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }

            ShowFilterMenu();
            choice = _input.GetChoice();
        }
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