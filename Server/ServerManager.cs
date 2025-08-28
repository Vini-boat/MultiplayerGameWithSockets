using System;
using System.Net;
using System.Collections.Concurrent;
using System.Net.Sockets;

using Serilog;

namespace Server
{
    public class ServerManager
    {
        private readonly TcpListener _listener;
        private readonly Database _database;
        private ConcurrentDictionary<string, ClientHandler> _clients = new();

        public ServerManager(string ip, int port)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
            _database = new Database("chat.db");

            Log.Information("Servidor iniciado");
        }

        public async Task StartAsync()
        {
            _listener.Start();
            Log.Information("Aguardando conexões");
            while (true)
            {
                TcpClient connectedClient = await _listener.AcceptTcpClientAsync();
                string clientId = Guid.NewGuid().ToString();

                Log.Information($"client conectado. GUID: {clientId}");

                ClientHandler handler = new ClientHandler(connectedClient, clientId, this,_database);

                _clients.TryAdd(clientId, handler);

                _ = Task.Run(() => handler.HandleClientAsync());
            }

        }

        public void UnregisterClient(string ClientId)
        {
            if (_clients.TryRemove(ClientId, out ClientHandler? removedClient))
            {
                Log.Information($"Cliente {removedClient.ClientId} {ClientId} removido");
            }
        }

        public async Task BroadcastMessageAsync(string ClientId, string message)
        {
            Log.Information($"Broadcast: {message}");
            foreach (ClientHandler client in _clients.Values)
            {
                await client.SendMessageAsync(message);
            }
        }

    }
}