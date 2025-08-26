namespace Protocolo
{
    public static class Mensagens
    {
        private const char DELIM = ';';
        public static class Client
        {
            public enum Commands
            {
                USER_LOGIN,
                USER_LOGOUT,
                USER_CREATE,
                USER_DELETE,

                LIST_CONTACTS,
                LIST_GROUPS,
                
                GROUP_CREATE,
                GROUP_DELETE,
                GROUP_ADD_USER,
                GROUP_REMOVE_USER,
                
                CHAT_PRIVATE_MESSAGE,
                CHAT_PRIVATE_LIST_MESSAGES,
                CHAT_GROUP_MESSAGE,
                CHAT_GROUP_LIST_MESSAGES,

                // TODO: se der
                CHAT_PRIVATE_TYPING_START,
                CHAT_PRIVATE_TYPING_STOP,
                CHAT_GROUP_TYPING_START,
                CHAT_GROUP_TYPING_STOP,
            }
            public static class User
            {
                public static string Login(string nick, string pass) => $"{Commands.USER_LOGIN}{DELIM}{nick}{DELIM}{pass}";
                public static string Logout() => $"{Commands.USER_LOGOUT}";
                public static string Create(string nick, string pass) => $"{Commands.USER_CREATE}{DELIM}{nick}{DELIM}{pass}";
                public static string Delete(string nick, string pass) => $"{Commands.USER_DELETE}{DELIM}{nick}{DELIM}{pass}";
            }

            public static class Contacts
            {
                public static string ListAll() => $"{Commands.LIST_CONTACTS}";
            }

            public static class Groups
            {
                public static string ListAll() => $"{Commands.LIST_GROUPS}";
                public static string Create(string groupName) => $"{Commands.GROUP_CREATE}{DELIM}{groupName}";
                public static string Delete(string groupName) => $"{Commands.GROUP_DELETE}{DELIM}{groupName}";
                public static string AddUser(string groupName, string contact) => $"{Commands.GROUP_ADD_USER}{DELIM}{groupName}{DELIM}{contact}";
                public static string RemoveUser(string groupName, string contact) => $"{Commands.GROUP_REMOVE_USER}{DELIM}{groupName}{DELIM}{contact}";

            }

            public static class Chat
            {
                public static class Private
                {
                    public static string ListMessages(string contact) => $"{Commands.CHAT_PRIVATE_LIST_MESSAGES}{DELIM}{contact}";
                    public static string SendMessage(string contact, string message) => $"{Commands.CHAT_PRIVATE_MESSAGE}{DELIM}{contact}{DELIM}{message}";

                    public static class Typing
                    {
                        public static string Start(string contact) => $"{Commands.CHAT_PRIVATE_TYPING_START}{DELIM}{contact}";
                        public static string Stop(string contact) => $"{Commands.CHAT_PRIVATE_TYPING_STOP}{DELIM}{contact}";
                    }
                }
                public static class Group
                {
                    public static string ListMessages(string groupName) => $"{Commands.CHAT_GROUP_LIST_MESSAGES}{DELIM}{groupName}";
                    public static string SendMessage(string group, string message) => $"{Commands.CHAT_GROUP_MESSAGE}{DELIM}{group}{DELIM}{message}";

                    public static class Typing
                    {
                        public static string Start(string group) => $"{Commands.CHAT_GROUP_TYPING_START}{DELIM}{group}";
                        public static string Stop(string group) => $"{Commands.CHAT_GROUP_TYPING_STOP}{DELIM}{group}";
                    }
                }

            }
        }

        public static class Server
        {
            public enum Commands
            {
                OK,
                ERROR,
                
                CONTACTS_LIST,
                CONTACT_CREATED,
                CONTACT_DELETED,

                GROUP_LIST,
                GROUP_CREATED,
                GROUP_DELETED,

                CHAT_PRIVATE_MESSAGE,
                CHAT_PRIVATE_MESSAGE_LIST,
                CHAT_GROUP_MESSAGE,
                CHAT_GROUP_MESSAGE_LIST,

                CHAT_GROUP_USER_ENTER,
                CHAT_GROUP_USER_LEAVE,

                CHAT_PRIVATE_TYPING_START,
                CHAT_PRIVATE_TYPING_STOP,
                CHAT_GROUP_TYPING_START,
                CHAT_GROUP_TYPING_STOP,
            }

            public static class User
            {
                public static class Create
                {
                    public static string Ok() => $"{Commands.OK}{DELIM}{Client.Commands.USER_CREATE}";
                    public static string Error(string error) => $"{Commands.ERROR}{DELIM}{Client.Commands.USER_CREATE}{DELIM}{error}";
                }

                public static class Delete
                {
                    public static string Ok() => $"{Commands.OK}{DELIM}{Client.Commands.USER_DELETE}";
                    public static string Error(string error) => $"{Commands.ERROR}{DELIM}{Client.Commands.USER_DELETE}{DELIM}{error}";
                }

                public static class Login
                {
                    public static string Ok() => $"{Commands.OK}{DELIM}{Client.Commands.USER_LOGIN}";
                    public static string Error(string error) => $"{Commands.ERROR}{DELIM}{Client.Commands.USER_LOGIN}{DELIM}{error}";
                }
            }

            public static class Contacts
            {
                public static string List(List<string> contacts) => $"{Commands.CONTACTS_LIST}{DELIM}{string.Join(",",contacts)}";
                public static string Created(string contact) => $"{Commands.CONTACT_CREATED}{DELIM}{contact}";
                public static string Deleted(string contact) => $"{Commands.CONTACT_CREATED}{DELIM}{contact}";
            }

            public static class Group
            {
                public static string List(List<string> groups) => $"{Commands.GROUP_LIST}{DELIM}{string.Join(",", groups)}";
                public static string Created(string groupName) => $"{Commands.GROUP_CREATED}{DELIM}{groupName}";
                public static string Deleted(string groupName) => $"{Commands.GROUP_DELETED}{DELIM}{groupName}";

            }

            public static class Chat
            {
                public static class Private
                {
                    public static string ListMessages(string contact) => $"{Commands.CHAT_PRIVATE_MESSAGE_LIST}{DELIM}{contact}";
                    public static string SendMessage(string contact, string message) => $"{Commands.CHAT_PRIVATE_MESSAGE}{DELIM}{contact}{DELIM}{message}";
                    
                    public static class Typing
                    {
                        public static string Start(string group, string user) => $"{Commands.CHAT_PRIVATE_TYPING_START}{DELIM}{group}{DELIM}{user}";
                        public static string Stop(string group, string user) => $"{Commands.CHAT_PRIVATE_TYPING_STOP}{DELIM}{group}{DELIM}{user}";
                    }

                }
                public static class Group
                {
                    public static string ListMessages(string groupName) => $"{Commands.CHAT_GROUP_MESSAGE_LIST}{DELIM}{groupName}";
                    public static string SendMessage(string group, string message) => $"{Commands.CHAT_GROUP_MESSAGE}{DELIM}{group}{DELIM}{message}";

                    public static class User
                    {
                        public static string Enter(string contact) => $"{Commands.CHAT_GROUP_USER_ENTER}{DELIM}{contact}";
                        public static string Leave(string contact) => $"{Commands.CHAT_GROUP_USER_LEAVE}{DELIM}{contact}";
                    }

                    public static class Typing
                    {
                        public static string Start(string group, string user) => $"{Commands.CHAT_GROUP_TYPING_START}{DELIM}{group}{DELIM}{user}";
                        public static string Stop(string group, string user) => $"{Commands.CHAT_GROUP_TYPING_STOP}{DELIM}{group}{DELIM}{user}";
                    }
                }

            }
        }
    }
}
