using Protocolo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class NewGroupForm : Form
    {
        public string GroupName => GroupNameTextBox.Text;
        public List<string> SelectedContacts => ContactsListBox.CheckedItems.Cast<string>().ToList();

        private NetworkClient _networkClient;
        public NewGroupForm(NetworkClient networkClient ,List<string> contacts)
        {

            InitializeComponent();
            _networkClient = networkClient;
            _networkClient.MessageReceived += OnMessageReceived;
            ContactsListBox.Items.AddRange(contacts.ToArray());
        }

        private void AcceptButton_Click(object sender, EventArgs e) 
        { 
            
            _networkClient.SendMessageAsync(Mensagens.Client.Groups.Create(GroupName)).Wait();
        }
        private void CancelButton_Click(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.Cancel; 
            this.Close(); 
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
            }
        }

        private void processOk(Mensagens.Client.Commands commandClient, string[] args)
        {
            switch (commandClient)
            {
                case Mensagens.Client.Commands.GROUP_CREATE:
                    foreach (string contact in SelectedContacts)
                    {
                        _networkClient.SendMessageAsync(Mensagens.Client.Groups.AddUser(GroupName, contact)).Wait();
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                    break;
            }
        }

        private void processError(Mensagens.Client.Commands commandClient, string[] args)
        {
            switch (commandClient)
            {
                case Mensagens.Client.Commands.GROUP_CREATE:
                    MessageBox.Show(args[1], "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _networkClient.MessageReceived -= OnMessageReceived;
        }
    }
}
