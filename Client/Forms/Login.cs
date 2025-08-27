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
    public partial class Login : Form
    {
        private readonly NetworkClient _networkClient;
        public Login(NetworkClient networkclient)
        {
            InitializeComponent();
            _networkClient = networkclient;

            _networkClient.ServerConnected += OnServerConnected;
            _networkClient.MessageReceived += OnMessageReceived;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                int port;
                int.TryParse(portTextBox.Text, out port);
                _networkClient.Connect(ipTextBox.Text, port);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível conectar ao servidor: {ex.Message}");
            }
        }

        private void OnServerConnected()
        {
            Invoke(new Action(() =>
            {
                connectButton.Enabled = false;
                nicknameTextBox.Enabled = false;
                ipTextBox.Enabled = false;
                portTextBox.Enabled = false;
                label4.Enabled = false;
                label3.Enabled = false;

                label2.Enabled = true;
                label1.Enabled = true;
                nicknameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                loginButton.Enabled = true;
                createNewAccountButton.Enabled = true;
            }));
        }

        private void OnMessageReceived(string message)
        {
            string[] segments = message.Split(Mensagens.DELIM);
            string commandString = segments[0];
            string[] args = segments[1..];
            var command = Mensagens.Server.ParseCommand(commandString);
            Mensagens.Client.Commands commandClient;
            switch (command)
            {
                case Mensagens.Server.Commands.OK:
                    commandClient = Mensagens.Client.ParseCommand(args[0]);
                    switch (commandClient)
                    {
                        case Mensagens.Client.Commands.USER_LOGIN:
                            break;
                    }
                    break;
                case Mensagens.Server.Commands.ERROR:
                    commandClient = Mensagens.Client.ParseCommand(args[0]);
                    switch (commandClient)
                    {
                        case Mensagens.Client.Commands.USER_LOGIN:
                            MessageBox.Show(args[1], "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case Mensagens.Client.Commands.USER_CREATE:
                            MessageBox.Show(args[1], "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                    break;
            }
        }

        private async void createNewAccountButton_Click(object sender, EventArgs e)
        {
            await _networkClient.SendMessageAsync(Mensagens.Client.User.Create(nicknameTextBox.Text,passwordTextBox.Text));
        }


    }
}
