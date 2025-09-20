using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    internal class GroupService
    {
        private readonly Database _database;
        public GroupService(Database database)
        {
            _database = database;
        }

        public string? CreateGroup(string groupName)
        {
            bool ok = _database.CreateGroup(groupName);
            if (!ok)
            {
                return "Nome de grupo já está em uso";
            }
            return null;
        }

        public string? AddUserToGroup(string groupName, string username)
        {
            bool ok = _database.AddUserToGroup(groupName, username);
            if (!ok)
            {
                return "Erro ao adicionar usuário ao grupo. Verifique se o grupo e o usuário existem.";
            }
            return null;
        }

        public List<string> GetUserGroups(string userName)
        {
            return _database.GetUserGroups(userName);
        }

        public List<string> GetGroupUsers(string groupName)
        {
            return _database.GetGroupUsers(groupName);
        }
    }
}
