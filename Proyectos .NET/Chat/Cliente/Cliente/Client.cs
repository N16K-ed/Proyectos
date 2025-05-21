// -----------------------------------------------
// Cliente de Chat TCP multicliente en C#
// Se conecta al servidor y envía nombre de usuario
// -----------------------------------------------

using System.Net.Sockets;
using System.Text;

class TcpChatClient
{
    static void Main()
    {
        try
        {
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();

            string userName = Environment.UserName;
            byte[] userNameData = Encoding.UTF8.GetBytes(userName);
            stream.Write(userNameData, 0, userNameData.Length);

            Console.WriteLine($"Conectado como {userName}. Escribe mensajes para enviar.");
            Console.WriteLine("Escribe 'salir' para desconectarte.");

            Thread receiveThread = new Thread(() =>
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                try
                {
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        Console.WriteLine("\n" + mensaje);
                        Console.Write("> ");
                    }
                }
                catch
                {
                    Console.WriteLine("\nDesconectado del servidor.");
                }
            });

            receiveThread.Start();

            while (true)
            {
                Console.Write("> ");
                string mensaje = Console.ReadLine();

                if (mensaje.ToLower() == "salir")
                    break;

                byte[] data = Encoding.UTF8.GetBytes(mensaje);
                stream.Write(data, 0, data.Length);
            }

            client.Close();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error: " + exception.Message);
        }
    }
}
