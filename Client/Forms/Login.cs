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
            _networkClient.ServerDisconnected += OnServerDisconnected;
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
        private void OnServerDisconnected()
        {
            Invoke(new Action(() =>
            {
                connectButton.Enabled = true;
                nicknameTextBox.Enabled = true;
                ipTextBox.Enabled = true;
                portTextBox.Enabled = true;
                label4.Enabled = true;
                label3.Enabled = true;

                label2.Enabled = false;
                label1.Enabled = false;
                nicknameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                loginButton.Enabled = false;
                createNewAccountButton.Enabled = false;
            }));
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
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _networkClient.ServerConnected -= OnServerConnected;
            _networkClient.ServerDisconnected -= OnServerDisconnected;
            _networkClient.MessageReceived -= OnMessageReceived;
        }

        private void processOk(Mensagens.Client.Commands commandClient, string[] args)
        {
            switch (commandClient)
            {
                case Mensagens.Client.Commands.USER_LOGIN:
                    this.Invoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                    
                    break;
                case Mensagens.Client.Commands.USER_CREATE:
                    MessageBox.Show("Usuário criado com sucesso");
                    break;
            }
        }

        private void processError(Mensagens.Client.Commands commandClient, string[] args)
        {
            switch (commandClient)
            {
                case Mensagens.Client.Commands.USER_LOGIN:
                    MessageBox.Show(args[1], "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Mensagens.Client.Commands.USER_CREATE:
                    MessageBox.Show(args[1], "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private async void createNewAccountButton_Click(object sender, EventArgs e)
        {
            await _networkClient.SendMessageAsync(Mensagens.Client.User.Create(nicknameTextBox.Text, passwordTextBox.Text));
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            await _networkClient.SendMessageAsync(Mensagens.Client.User.Login(nicknameTextBox.Text, passwordTextBox.Text));
        }
    }
}
