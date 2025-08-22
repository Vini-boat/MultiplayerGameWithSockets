using System.Threading.Tasks;

namespace Client
{
    public partial class MainForm : Form
    {
        private readonly NetworkClient _networkClient;
        public MainForm()
        {
            InitializeComponent();

            _networkClient = new NetworkClient();

            _networkClient.MessageReceived += OnMessageReceived;
            _networkClient.ServerConnected += OnServerConnected;
            _networkClient.ServerDisconnected += OnServerDisconnected;
        }

        private async Task SendChatMessage()
        {
            string message = messageTextBox.Text;
            if (!string.IsNullOrEmpty(message))
            {
                await _networkClient.SendMessageAsync(message);
                messageTextBox.Clear();
            }
        }

        private async void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await SendChatMessage();
            }
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            await SendChatMessage();
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                int port;
                int.TryParse(portTextBox.Text, out port);
                await _networkClient.ConnectAsync(ipTextBox.Text,port,nicknameTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível conectar ao servidor: {ex.Message}");
            }
        }

        private void OnServerConnected()
        {
            Console.WriteLine($"[INFO] Servidor desconectado");
            Invoke(new Action(() =>
            {
                connectButton.Enabled = false;
                nicknameTextBox.Enabled = false;
                ipTextBox.Enabled = false;
                portTextBox.Enabled = false;
                sendButton.Enabled = true;
                messageTextBox.Enabled = true;
                
            }));
        }

        private void OnMessageReceived(string message)
        {
            ChatRichTextBox.AppendText(message + Environment.NewLine);
            ChatRichTextBox.SelectionStart = ChatRichTextBox.TextLength;
            ChatRichTextBox.ScrollToCaret();
        }

        private void OnServerDisconnected()
        {
            Invoke(new Action(() =>
            {
                connectButton.Enabled = true;
                nicknameTextBox.Enabled = true;
                ipTextBox.Enabled = true;
                portTextBox.Enabled = true;
                sendButton.Enabled = false;
                messageTextBox.Enabled = false;
            }));
        }


    }
}
