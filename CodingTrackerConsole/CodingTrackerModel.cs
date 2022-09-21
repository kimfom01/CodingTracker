namespace CodingTrackerConsole
{
    internal class CodingTrackerModel
    {
        // Question: What is the purpose of initialising these properties? I'm not sure it is necessary.
        
        public string Date { get; set; } = String.Empty;

        public string StartTime { get; set; } = String.Empty;

        public string EndTime { get; set; } = String.Empty;

        public string Duration { get; set; } = String.Empty;
    }
}
