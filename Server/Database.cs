using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Server
{
    public class Database
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

        public bool AddUser(string nickname, string password)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO Users (Nickname, Password) VALUES (@nickname, @password)";
                command.Parameters.AddWithValue("@nickname",nickname);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqliteException)
                {
                    return false;
                }

            }
        }

        public List<string> GetAllUsers()
        {
            var users = new List<string>();
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT Nickname FROM Users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(reader.GetString(0));
                    }
                }
            }
            return users;
        }

        public bool Autenticate(string nickname, string password)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT COUNT(1) FROM Users WHERE Nickname = @nickname AND Password = @password";
                command.Parameters.AddWithValue("@nickname", nickname);
                command.Parameters.AddWithValue("@password", password);

                using (var reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
