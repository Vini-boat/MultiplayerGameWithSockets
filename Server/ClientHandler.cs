using Serilog;
using System.Net.Sockets;
using System.Text;

public class ClientHandler
{
    private readonly TcpClient _client;
    private readonly Server _server;
    private readonly NetworkStream _stream;

    public string ClientId { get; }
    public string Nickname { get; private set; }

    public ClientHandler(TcpClient client, string clientId, Server server)
    {
        _client = client;
        ClientId = clientId;
        _server = server;
        _stream = _client.GetStream();
        Nickname = "NOT INITIALIZED";
    }

    public async Task HandleClientAsync()
    {
        try
        {
            var buffer = new byte[1024];

            var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

            if (bytesRead == 0) return;

            Nickname = Encoding.UTF8.GetString(buffer,0,bytesRead).Trim();

            Log.Information($"setando nickname {Nickname} para client {ClientId}");

            Console.WriteLine($"Nickname: {Nickname}");

            while ((bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                Console.WriteLine($"[INFO] cliente {Nickname} mandou a mensagem: {message}");
                await _server.BroadcastMessageAsync(ClientId, $"[{Nickname}]: {message}");
            }


        }
        catch (Exception e)
        {
            Console.WriteLine($"[ERROR] {ClientId} {e.Message}");
        }
        finally
        {
            _server.UnregisterClient(ClientId);
            _client.Close();
        }
    }

    public async Task SendMessageAsync(string message)
    {
        try
        {
            Console.WriteLine($"[INFO] mandando mensagem: {message} para {Nickname}");
            var messageBytes = Encoding.UTF8.GetBytes(message + Environment.NewLine);
            await _stream.WriteAsync(messageBytes, 0, messageBytes.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[ERROR] {ClientId} {e.Message}");
        }
    }
}