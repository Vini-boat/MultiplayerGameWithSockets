using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class UserService
    {
        private readonly Database _database;
        public UserService(Database database)
        {
            _database = database;
        }

        public string? CreateUser(string username, string password)
        {
            bool ok = _database.AddUser(username, password);
            if (!ok)
            {
                return "Username já está em uso";
            }
            return null;
        }
        public string? DeleteUser(string username, string password) => null;
        public string? Login(string username, string password)
        {
            bool ok = _database.Autenticate(username, password);
            if (!ok)
            {
                return "Username ou senha inválidos";
            }
            return null;
        }
    }
}
