using System;
using System.Net;
using System.Collections.Concurrent;
using System.Net.Sockets;

public class Server
{
    private readonly TcpListener _listener;

    private ConcurrentDictionary<string, ClientHandler> _clients = new();

    public Server(string ip, int port)
    {
        _listener = new TcpListener(IPAddress.Parse(ip), port);
        Console.WriteLine("[INFO] Servidor iniciado");
    }

    public async Task StartAsync()
    {
        _listener.Start();
        Console.WriteLine("[INFO] Aguardando conex�es");
        while (true)
        {
            TcpClient connectedClient = await _listener.AcceptTcpClientAsync();
            string clientId = Guid.NewGuid().ToString();

            Console.WriteLine($"[INFO] client conectado. GUID: {clientId}");

            ClientHandler handler = new ClientHandler(connectedClient, clientId, this);

            _clients.TryAdd(clientId, handler);

            _ = Task.Run(() => handler.HandleClientAsync());
        }

    }

    public void UnregisterClient(string ClientId)
    {
        if (_clients.TryRemove(ClientId, out ClientHandler? removedClient))
        {
            Console.WriteLine($"[INFO] Cliente {removedClient.Nickname} {ClientId} removido");
        }
    }

    public async Task BroadcastMessageAsync(string ClientId,string message)
    {
        Console.WriteLine($"[INFO] Broadcast: {message}");
        foreach (ClientHandler client in _clients.Values)
        {
            await client.SendMessageAsync(message);
        }
    }

}