using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocolo;

namespace Client
{
    public partial class ChatForm : Form
    {
        private readonly NetworkClient _networkClient;
        private readonly MessageStore _messageStore = new MessageStore();
        public string Nickname { get; private set; }
        private string _currentContact = string.Empty;
        private string _currentGroup = string.Empty;
        public ChatForm(NetworkClient networkClient, string Nickname)
        {
            _networkClient = networkClient;
            _networkClient.MessageReceived += OnMessageReceived;
            this.Nickname = Nickname;

            Text = $"Chat - {Nickname}";
 

            InitializeComponent();
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            await _networkClient.SendMessageAsync(Mensagens.Client.Contacts.ListAll());
        }

        private void OnMessageReceived(string message)
        {
            string[] segments = message.Split(Mensagens.DELIM);
            string commandString = segments[0];
            string[] args = segments[1..];
            var command = Mensagens.Server.ParseCommand(commandString);
            switch (command)
            {
                case Mensagens.Server.Commands.OK:
                    processOk(Mensagens.Client.ParseCommand(args[0]), args);
                    break;
                case Mensagens.Server.Commands.ERROR:
                    processError(Mensagens.Client.ParseCommand(args[0]), args);
                    break;
                case Mensagens.Server.Commands.CONTACTS_LIST:
                    foreach (string contactName in args[0].Split(','))
                    {
                        if (contactName == Nickname) continue;
                        AddContactGroupBox(contactName);
                        _networkClient.SendMessageAsync(Mensagens.Client.Contacts.Status(contactName)).Wait();
                    }
                    break;
                case Mensagens.Server.Commands.CONTACT_CREATED:
                    AddContactGroupBox(args[0]);
                    break;
                case Mensagens.Server.Commands.CONTACT_ONLINE:
                    ChangeContactStatus(args[0], true);
                    break;
                case Mensagens.Server.Commands.CONTACT_OFFLINE:
                    ChangeContactStatus(args[0], false);
                    break;
                case Mensagens.Server.Commands.CHAT_PRIVATE_MESSAGE:
                    ReceivePrivateMessage(args[0],args[0], args[1]);
                    break;
                case Mensagens.Server.Commands.CHAT_GROUP_MESSAGE:
                    ReceiveGroupMessage(args[0], args[1], args[2]);
                    break;
                case Mensagens.Server.Commands.CHAT_PRIVATE_MESSAGE_LIST:
                    foreach (string m in args[0].Split(','))
                    {
                        ChatRichTextBox.AppendText(m + Environment.NewLine);
                    }
                    break;
            }
        }

        private void processOk(Mensagens.Client.Commands commandClient, string[] args)
        {
            switch (commandClient)
            {

            }
        }

        private void processError(Mensagens.Client.Commands commandClient, string[] args)
        {
            switch (commandClient)
            {

            }
        }

        private void AddMessageOnScreen(string sender, string message)
        {
            Invoke(new Action(() =>
            {
                ChatRichTextBox.AppendText($"[{sender}]:\t{message}{Environment.NewLine}");
            }));
        }
        private void ReceivePrivateMessage(string contact,string sender, string message)
        {
            _messageStore.AddPrivateMessage(contact,sender, message);
            if (sender != Nickname) ChangeContactLastMessage(contact, message);
            if (_currentContact == contact)
            {
                AddMessageOnScreen(sender, message);
            }
        }

        private void ReceiveGroupMessage(string group, string sender, string message)
        {
            _messageStore.AddGroupMessage(group, sender, message);
            if(_currentGroup == group)
            {
                AddMessageOnScreen(sender,message);
            }
        }

        private void AddContactGroupBox(string name)
        {
            Invoke(new Action(() =>
            {

                GroupBox contactGroupBox = new GroupBox();
                contactGroupBox.Location = new Point(3, 3);
                contactGroupBox.Size = new Size(228, 47);
                contactGroupBox.TabIndex = 0;
                contactGroupBox.TabStop = false;
                contactGroupBox.Text = name;
                var label_status = new Label()
                {
                    Name = $"Status_{name}",
                    AutoSize = true,
                    BackColor = Color.FromArgb(249, 249, 249),
                    ForeColor = Color.Red,
                    Location = new Point(180, 0),
                    Size = new Size(43, 15),
                    TabIndex = 1,
                    Text = "Offline"
                };
                label_status.Click += label_groupBox_MouseClick;

                contactGroupBox.Controls.Add(label_status);

                var label_last_message = new Label()
                {
                    Name = $"lastMessage_{name}",
                    AutoEllipsis = true,
                    AutoSize = true,
                    Location = new Point(6, 19),
                    MaximumSize = new Size(220, 20),
                    Size = new Size(216, 20),
                    TabIndex = 0,
                    Text = "",
                };
                label_last_message.Click += label_groupBox_MouseClick;
                contactGroupBox.Controls.Add(label_last_message);
                contactGroupBox.MouseClick += groupBox_MouseClick;
                ContactsflowLayoutPanel.Controls.Add(contactGroupBox);
            }));
        }

        private void ChangeContactStatus(string name, bool online)
        {
            Invoke(new Action(() =>
            {
                var label = ContactsflowLayoutPanel.Controls.Find($"Status_{name}", true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = online ? "Online" : "Offline";
                    label.ForeColor = online ? Color.Green : Color.Red;
                }
            }));
        }

        private void ChangeContactLastMessage(string contact, string message)
        {
            Invoke(new Action(() =>
            {
                var label = ContactsflowLayoutPanel.Controls.Find($"lastMessage_{contact}", true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = message;
                }
            }));
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            _networkClient.SendMessageAsync(Mensagens.Client.Chat.Private.SendMessage(_currentContact, messageTextBox.Text)).Wait();
            ReceivePrivateMessage(_currentContact, Nickname, messageTextBox.Text);
            messageTextBox.Clear(); 
        }

        private void groupBox_MouseClick(object sender, EventArgs e)
        {
            var gb = (GroupBox)sender;
            LoadMessagesOnScreen(gb.Text);
            _currentContact = gb.Text;
        }

        private void label_groupBox_MouseClick(object sender, EventArgs e)
        {
            var label = (Label)sender;
            LoadMessagesOnScreen(label.Parent?.Text);
            _currentContact = label.Parent?.Text ?? string.Empty;
        }

        private void LoadMessagesOnScreen(string contact)
        {
            ChatRichTextBox.Clear();
            foreach (var message in _messageStore.GetContactMessages(contact))
            {
                AddMessageOnScreen(message.Sender, message.Content);
            }
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
