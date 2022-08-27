using Microsoft.Data.Sqlite;
using System.Configuration;
using ConsoleTableExt;

namespace CodingTrackerConsole
{
    internal class DatabaseManager
    {
        private string? _connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        

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

        public void InsertRecord(string date, string startTime, string endTime)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = @$"INSERT INTO codingTracker (Date, StartTime, EndTime)
                                            VALUES ('{date}', '{startTime}', '{endTime}')";

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
        }

        public void UpdateRecord(string date, string? startTime, string? endTime)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    if (startTime is null)
                    {
                        command.CommandText = $@"UPATE codingTracker
                                                SET Date = '{date}', EndTime = '{endTime}'
                                                WHERE Date = '{date}'";
                    }
                    else if (endTime is null)
                    {
                        command.CommandText = $@"UPATE codingTracker
                                                SET Date = '{date}', StartTime = '{startTime}'
                                                WHERE Date = '{date}'";
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<CodingTrackerModel> ReadFromDB()
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

                            codingTrackerModels.Add(models);
                        }

                        //foreach (var item in codingTrackerModels)
                        //{
                        //    Console.WriteLine(item.Date + " - " + item.StartTime + " | " + item.EndTime);
                        //}
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