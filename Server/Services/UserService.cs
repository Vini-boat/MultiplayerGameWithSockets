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
                if (_database.IsUserOnline(username))
                {
                    return "Usuário já conectado";
                }
                return "Username ou senha inválidos";
            }
            bool statusChanged = _database.ChangeUserStatus(username, true);
            if (!statusChanged)
            {
                return "Erro ao logar usuário";
            }
            return null;
        }

        public string? Logout(string username)
        {   
            bool ok = _database.ChangeUserStatus(username, false);
            if (!ok)
            {
                return "Erro ao deslogar usuário";
            }
            return null;
        }

        public List<string> GetAllUsers()
        {
            return _database.GetAllUsers();
        }

        public bool GetUserStatus(string username)
        {
            bool isOnline = _database.IsUserOnline(username);
            return isOnline;
        }
    }
}
