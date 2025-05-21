// -----------------------------------------------
// Servidor de Chat TCP multicliente en C#
// Con identificación del usuario de Windows
// -----------------------------------------------

using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpChatServer
{
    static Dictionary<TcpClient, string> clients = new Dictionary<TcpClient, string>();

    static object lockObject = new object();

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Servidor de chat iniciado en puerto 5000...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();

            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(client);
        }
    }

    static void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string userName = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            lock (lockObject)
            {
                clients.Add(client, userName);
            }

            Console.WriteLine($"[{userName}] se ha conectado.");

            BroadcastMessage($"*** {userName} se ha unido al chat ***", client);

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"[{userName}]: {mensaje}");

                BroadcastMessage($"[{userName}]: {mensaje}", client);
            }
        }
        catch
        {

        }
        finally
        {
            lock (lockObject)
            {
                if (clients.ContainsKey(client))
                {
                    string userName = clients[client];
                    clients.Remove(client);

                    Console.WriteLine($"[{userName}] se ha desconectado.");

                    BroadcastMessage($"*** {userName} ha salido del chat ***", client);
                }
            }
            client.Close();
        }
    }

    static void BroadcastMessage(string message, TcpClient sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);

        lock (lockObject)
        {
            foreach (var client in clients.Keys)
            {
                if (client != sender)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}