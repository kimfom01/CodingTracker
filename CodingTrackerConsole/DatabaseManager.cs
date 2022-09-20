using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTrackerConsole
{
    internal class DatabaseManager
    {
        private readonly string? _connectionString = ConfigurationManager.AppSettings.Get("connectionString");

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
                                            EndTime TXT,
                                            Duration TXT)";

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertRecord(string date, string startTime, string endTime, string duration)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = @$"INSERT INTO codingTracker (Date, StartTime, EndTime, Duration)
                                            VALUES ('{date}', '{startTime}', '{endTime}', '{duration}')";

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRecord(string date)
        {
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
            Console.Clear();
        }

        public void UpdateRecord(string oldDate, string? newDate, string? startTime, string? endTime, string? duration)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    if (startTime is null && endTime is null)
                    {
                        command.CommandText = $@"UPDATE codingTracker
                                                SET Date = '{newDate}'
                                                WHERE Date = '{oldDate}'";
                    }
                    else if (newDate is null)
                    {
                        command.CommandText = $@"UPDATE codingTracker
                                                SET StartTime = '{startTime}', EndTime = '{endTime}', Duration = '{duration}'
                                                WHERE Date = '{oldDate}'";
                    }
                    else
                    {
                        command.CommandText = $@"UPDATE codingTracker
                                                SET Date = '{newDate}', StartTime = '{startTime}', EndTime = '{endTime}', Duration = '{duration}'
                                                WHERE Date = '{oldDate}'";
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<CodingTrackerModel> ReadFromDb()
        {
            List<CodingTrackerModel> codingTrackerModels = new();

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
                            var models = new CodingTrackerModel();
                            models.Date = (string)reader["Date"];
                            models.StartTime = (string)reader["StartTime"];
                            models.EndTime = (string)reader["EndTime"];
                            models.Duration = (string)reader["Duration"];

                            codingTrackerModels.Add(models);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have any records!\n");
                    }
                }
            }

            return codingTrackerModels;
        }
    }
}