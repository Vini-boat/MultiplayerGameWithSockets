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
        public ChatForm(NetworkClient networkClient)
        {
            _networkClient = networkClient;
            _networkClient.MessageReceived += OnMessageReceived;

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
                        AddContactGroupBox(contactName);
                    }
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
                    Text = "temp",
                };
                label_last_message.Click += label_groupBox_MouseClick;
                contactGroupBox.Controls.Add(label_last_message);
                contactGroupBox.MouseClick += groupBox_MouseClick;
                ContactsflowLayoutPanel.Controls.Add(contactGroupBox);
            }));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AddContactGroupBox("teste");
        }

        private void groupBox_MouseClick(object sender, EventArgs e)
        {
            var gb = (GroupBox)sender;
            LoadMessagesOnScreen(gb.Text);
        }

        private void label_groupBox_MouseClick(object sender, EventArgs e)
        {
            var label = (Label)sender;
            LoadMessagesOnScreen(label.Parent?.Text);
        }
        
        private async void LoadMessagesOnScreen(string contact)
        {
            ChatRichTextBox.Clear();
            await _networkClient.SendMessageAsync(Mensagens.Client.Chat.Private.ListMessages(contact));
        }
    }
}
