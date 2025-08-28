using Serilog;
using System.Net.Sockets;
using System.Text;
using Protocolo;
using Server.Services;
using Server;


public class ClientHandler
{
    private readonly TcpClient _client;
    private readonly ServerManager _server;

    private readonly StreamReader? _reader;
    private readonly StreamWriter? _writer;

    private readonly UserService _userservice;

    public string ClientId { get; }
    public string Nickname { get; private set; }

    public ClientHandler(TcpClient client, string clientId, ServerManager server, Database database)
    {
        Nickname = "NOT INITIALIZED";
        _client = client;
        ClientId = clientId;
        _server = server;

        NetworkStream stream = _client.GetStream();
        UTF8Encoding utf8WithoutBom = new UTF8Encoding(false);
        _reader = new StreamReader(stream,utf8WithoutBom);
        _writer = new StreamWriter(stream,utf8WithoutBom) { AutoFlush = true };

        _userservice = new UserService(database);
    }

    public async Task HandleClientAsync()
    {
        if ((_client == null) || (_reader == null)) { throw new InvalidOperationException(); }
        try
        {
            while (_client.Connected)
            {
                string? message = await _reader.ReadLineAsync();
                if (message == null) break;
                Log.Information($"Recebendo mensagem: {message} de {ClientId}");
                string[] segments = message.Split(Mensagens.DELIM);
                string[] args = segments[1..];

                string commandString = segments[0];
                var command = Mensagens.Client.ParseCommand(commandString);

                string? err = null;
                switch (command)
                {
                    case Mensagens.Client.Commands.USER_LOGIN:
                        err = _userservice.Login(args[0], args[1]);
                        if (err != null) { await SendMessageAsync(Mensagens.Server.User.Login.Error(err)); }
                                    else { await SendMessageAsync(Mensagens.Server.User.Login.Ok()); }
                        break;
                    case Mensagens.Client.Commands.USER_LOGOUT:
                        break;
                    case Mensagens.Client.Commands.USER_CREATE:
                        err = _userservice.CreateUser(args[0], args[1]);
                        if (err != null) { await SendMessageAsync(Mensagens.Server.User.Create.Error(err)); }
                                    else { await SendMessageAsync(Mensagens.Server.User.Create.Ok()); }
                        break;
                    case Mensagens.Client.Commands.USER_DELETE:
                        err = _userservice.DeleteUser(args[0], args[1]);
                        if (err != null) { await SendMessageAsync(Mensagens.Server.User.Delete.Error(err)); }
                                    else { await SendMessageAsync(Mensagens.Server.User.Delete.Ok()); }
                        break;
                    case Mensagens.Client.Commands.LIST_CONTACTS:
                        List<string> contacts = _userservice.GetAllUsers();
                        await SendMessageAsync(Mensagens.Server.Contacts.List(contacts));
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Log.Error($"{ClientId} {e.Message}");
        }
        finally
        {
            _server.UnregisterClient(ClientId);
            _client.Close();
        }
    }

    public async Task SendMessageAsync(string message)
    {
        if (_writer == null) { throw new InvalidOperationException(); }
        try
        {
            Log.Information($"mandando mensagem: {message} para {ClientId}");

            if (!string.IsNullOrEmpty(message))
            {
                await _writer.WriteLineAsync(message);
            }
        }
        catch (Exception e)
        {
            Log.Information($"{ClientId} {e.Message}");
        }
    }
}