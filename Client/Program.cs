using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

string serverIp = "127.0.0.1";
int port = 8888;

try
{
    TcpClient client = new TcpClient();

    await client.ConnectAsync(serverIp, port);
    Console.WriteLine("[INFO] Conectado ao servidor");

    NetworkStream stream = client.GetStream();

    string? messageToSend;
    while (true)
    {
        Console.Write("Mensagem: ");
        messageToSend = Console.ReadLine();
        if (messageToSend is null)
        {
            Console.WriteLine("Mensagem inválida tente novamente.");
            continue;
        }
        break;
    }

    byte[] messageBytes = Encoding.UTF8.GetBytes(messageToSend);

    await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
    Console.WriteLine($"Mensagem enviada: {messageToSend}");

    byte[] buffer = new byte[1024];
    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

    string responseMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

    Console.WriteLine($"Resposta recebida: {responseMessage}");

    client.Close();
    Console.WriteLine("[INFO] Conexão fechada.");

}
catch (Exception e)
{
    Console.WriteLine($"[ERROR] {e.Message}");
}