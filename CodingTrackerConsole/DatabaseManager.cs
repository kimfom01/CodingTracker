using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTrackerConsole
{
    internal class DatabaseManager
    {
        private string? _connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        List<CodingTrackerModel> codingTrackerModels;

        public void CreateDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = @"CREATE TABLE IF NOT EXISTS codingTracker(
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Date TXT,
                                            StartTime TXT,
                                            EndTime TXT)";

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertRecord()
        {
            string date = "25-07-1999", startTime = "05:45", endTime = "06:25";

            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = @$"INSERT INTO codingTracker (Date, StartTime, EndTime)
                                            VALUES ({date}, {startTime}, {endTime})";

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRecord()
        {
            string date = "25-07-1999";

            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = @$"DELETE FROM codingTracker
                                            WHERE Date = '{date}'";

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRecord()
        {
            string date = "25-07-1999", startTime = "05:45", endTime = "06:25";

            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = $@"UPATE codingTracker
                                            SET Date = {date}, StartTime = {startTime}, EndTime = {endTime}";

                    command.ExecuteNonQuery();
                }
            }
        }

        public void View()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = $@"SELECT * FROM codingTracker";

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            codingTrackerModels.Add(new CodingTrackerModel(reader["Date"].ToString(), reader["StartTime"].ToString(), reader["EndTime"].ToString()));
                        }
                    }
                }
            }
        }
    }
}
