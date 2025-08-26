using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Server
{
    internal class Database
    {
        private readonly string _connectionString;

        public Database(string dbFilePath)
        {
            _connectionString = $"Data source={dbFilePath}";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                    @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nickname TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL
                        )
                    ";
                command.ExecuteNonQuery();
            }
        }
    }
}
