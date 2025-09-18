using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using Serilog;

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
                            Password TEXT NOT NULL,
                            Online BOOLEAN DEFAULT FALSE
                        )
                    ";
                command.ExecuteNonQuery();
                command.CommandText =
                    @"
                        CREATE TABLE IF NOT EXISTS Groups (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE
                        )
                    ";
                command.ExecuteNonQuery();
                command.CommandText =
                    @"
                        CREATE TABLE IF NOT EXISTS GroupUsers (
                            UserId INTEGER NOT NULL,
                            GroupId INTEGER NOT NULL,   
                            PRIMARY KEY (UserId, GroupId),
                            FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
                            FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE CASCADE
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
        public bool ChangeUserStatus(string nickname, bool online)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = "UPDATE Users SET Online = @online WHERE Nickname = @nickname";
            command.Parameters.AddWithValue("@online", online);
            command.Parameters.AddWithValue("@nickname", nickname);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool IsUserOnline(string nickname)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT Online FROM Users WHERE Nickname = @nickname";
            command.Parameters.AddWithValue("@nickname", nickname);
            using var reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (!reader.Read()) return false;
            return reader.GetBoolean(0);
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
            using var conn = new SqliteConnection(_connectionString);
            
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT Password,Online FROM Users WHERE Nickname = @nickname";
            command.Parameters.AddWithValue("@nickname", nickname);

            using var reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (!reader.Read()) return false;

            if ((Int64)reader["Online"] == 1) return false;
            return (string)reader["Password"] == password;
        }
    }
}
