namespace CodingTrackerConsole
{
    internal class CodingTrackerModel
    {
        private string _date;
        private string _startTime;
        private string _endTime;

        public CodingTrackerModel(string date, string startTime, string endtime)
        {
            this.Date = date;
            this.StartTime = startTime;
            this.EndTime = endtime;
        }
        public string Date
        {
            get { return this._date; }
            set { this._date = value; }
        }
        public string StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }
        public string EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }
    }
}
