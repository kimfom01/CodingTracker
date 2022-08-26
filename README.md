# CodingTracker

Console based CRUD application to keep track of coding hours. Developed using C# and SQLite.

# Given Requirements
- [x] Same requirements as [HabitTrackerApp](https://github.com/kimfom01/HabitTrackerApp), except that now you'll be logging your daily coding time.
- [x] To show the data on the console, you should use the ["ConsoleTableExt"](https://github.com/minhhungit/ConsoleTableExt) library.
- [x] You're required to have separate classes in different files (ex. UserInput.cs, Validation.cs, CodingController.cs)
- [x] You should tell the user the specific format you want the date and time to be logged and not allow any other format.
- [x] You'll need to create a configuration file that you'll contain your database path and connection strings.
- [x] You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration.
- [x] The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.
- [x] The user should be able to input the start and end times manually.
- [x] When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.

# Features
* SQLite database connection
    - The program uses a SQLite db connection to store and read information.
    - If no database exists, or the correct table does not exist they will be created.
* CRUD DB functions
    - From the main menu users can Create, Read, Update or Delete entries.

# In Other News
* [Buy Me A Coffee](https://www.buymeacoffee.com/kimfom01)
