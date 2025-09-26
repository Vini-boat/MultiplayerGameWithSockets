using Protocolo;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class NetworkClient
{
    private TcpClient? _client;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    public event Action<string>? MessageReceived;
    public event Action? ServerConnected;
    public event Action? ServerDisconnected;
    public void Connect(string ip, int port)
    {
        try
        {
            _client = new TcpClient(ip,port);

            NetworkStream stream = _client.GetStream();
            UTF8Encoding utf8WithoutBom = new UTF8Encoding(false);
            _reader = new StreamReader(stream, utf8WithoutBom);
            _writer = new StreamWriter(stream, utf8WithoutBom) { AutoFlush = true };

            ServerConnected?.Invoke();

            _ = Task.Run(() => ListenForMessages());
        }
        catch (Exception)
        {
            ServerDisconnected?.Invoke();
            throw;
        }
    }

    private async Task ListenForMessages()
    {
        if ((_client == null) || (_reader == null)) { throw new InvalidOperationException(); }

        try
        {
            while (_client.Connected)
            {
                string? message = await _reader.ReadLineAsync();
                if (message != null)
                {
                    MessageReceived?.Invoke(message);
                }
                else
                {
                    MessageBox.Show("Desconectado");
                    ServerDisconnected?.Invoke();
                    break;
                }
            }


        }
        catch (Exception)
        {
            ServerDisconnected?.Invoke();
        }
    }

    public async Task SendMessageAsync(string message)
    {
        if (_writer == null) { throw new InvalidOperationException(); }
        if (!string.IsNullOrEmpty(message))
        {
            await _writer.WriteLineAsync(message);
        }
    }

    public void Close()
    {
        _reader?.Dispose();
        _writer?.Dispose();
        _client?.Dispose();
    }
}