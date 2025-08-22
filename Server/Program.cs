using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Serilog;

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
        Server server = new Server(ip,port);

        Log.Information($"{ip}/{port}");

        await server.StartAsync();
    }
}
