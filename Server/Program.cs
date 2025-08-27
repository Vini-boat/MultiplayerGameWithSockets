using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server;
using Serilog;
using Server.Services;

public class Program
{
    public static async Task Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console( 
                outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();


        string ip = "127.0.0.1";
        int port = 8888;

        ServerManager server = new ServerManager(ip,port);

        Log.Information($"{ip}/{port}");

        await server.StartAsync();
    }
}
