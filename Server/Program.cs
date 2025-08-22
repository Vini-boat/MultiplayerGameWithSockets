using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        string ip = "127.0.0.1";
        int port = 8888;
        Server server = new Server(ip,port);

        Console.WriteLine($"[INFO] {ip}/{port}");

        await server.StartAsync();
    }
}
