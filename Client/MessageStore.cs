using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class PrivateMessageInStore
    {
        public string? Contact { get; set; }
        public string? Sender { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
    internal class GroupMessageInStore
    {
        public string? Group { get; set; }
        public string? Sender { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
    internal class MessageStore
    {
        private List<PrivateMessageInStore> _privateMessages = new List<PrivateMessageInStore>();
        private List<GroupMessageInStore> _groupMessages = new List<GroupMessageInStore>();

        public void AddPrivateMessage(string contact, string sender, string content)
        {
            _privateMessages.Add(new PrivateMessageInStore
            {
                Contact = contact,
                Sender = sender,
                Content = content,
            });
        }

        public void AddGroupMessage(string group, string sender, string content)
        {
            _groupMessages.Add(new GroupMessageInStore
            {
                Group = group,
                Sender = sender,
                Content = content,
            });
        }

        public List<PrivateMessageInStore> GetContactMessages(string contact)
        {
            return _privateMessages.Where(message => message.Contact == contact).ToList();
        }

        public List<GroupMessageInStore> GetGroupMessages(string group)
        {
            return _groupMessages.Where(message => message.Group == group).ToList();
        }
    }
}
