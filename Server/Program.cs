using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

IPAddress ip = IPAddress.Parse("127.0.0.1");
int port = 8888;

TcpListener listener = new TcpListener(ip, port);

try
{
    listener.Start();
    Console.WriteLine($"[INFO] Servidor iniciado na porta {port}");

    while (true)
    {
        Console.WriteLine("[INFO] Aguardando conexão");
        TcpClient client = await listener.AcceptTcpClientAsync();
        Console.WriteLine("[INFO] Client conectado");

        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

        string messageFromCLient = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        Console.WriteLine($"[INFO] Mensagem recebida: {messageFromCLient}");

        string response = "Mensagem Recebida";
        byte[] responseBytes = Encoding.UTF8.GetBytes(response);

        await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
        Console.WriteLine("[INFO] Mensagem enviada");

        client.Close();
        Console.WriteLine("[INFO] Conexão com o client fechada. aguardando o próximo.");

    }
}
catch (Exception e)
{
    Console.WriteLine($"[ERROR] {e.Message}");
}
finally
{
    listener.Stop();
}
