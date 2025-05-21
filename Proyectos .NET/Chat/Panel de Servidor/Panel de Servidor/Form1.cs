using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Panel_de_Servidor
{
    public partial class Form1 : Form
    {
        static Dictionary<TcpClient, string> clients = new Dictionary<TcpClient, string>();

        static object lockObject = new();

        volatile bool servidorCorriendo = false;

        TcpListener server;
        public Form1()
        {
            InitializeComponent();
            server = new(IPAddress.Any, 5000);
            
            this.BackColor = Color.FromArgb(24, 26, 27); // Gris oscuro neutro
            this.ForeColor = Color.WhiteSmoke;
            
            button1.BackColor = Color.FromArgb(40, 167, 69);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            
            button2.BackColor = Color.FromArgb(220, 53, 69);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            label1.BackColor = Color.FromArgb(24, 26, 27); // Igual que el fondo
            label1.ForeColor = Color.WhiteSmoke;
            label1.Font = new Font("Segoe UI Semibold", 18, FontStyle.Bold);
            
            textBox1.Font = new Font("Consolas", 10);
            textBox1.BackColor = Color.FromArgb(30, 30, 30); // Muy oscuro
            textBox1.ForeColor = Color.FromArgb(135, 206, 250); // Azul cielo claro
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Start();
            servidorCorriendo = true;
            AppendTextSafe("Servidor de chat iniciado en puerto 5000...\r\n");
            button1.Enabled = false;
            button2.Enabled = true;
            button1.Visible = false;
            button2.Visible = true;

            Thread aceptarThread = new Thread(aceptarClientes);
            aceptarThread.IsBackground = true;
            aceptarThread.Start();
        }

        void aceptarClientes()
        {
            while (servidorCorriendo)
            {
                try
                {
                    if (server.Pending())
                    {
                        TcpClient client = server.AcceptTcpClient();

                        Thread clientThread = new Thread(HandleClient);
                        clientThread.Start(client);
                    }
                    else
                    {
                        Thread.Sleep(100); // Evita uso excesivo de CPU
                    }
                }
                catch (SocketException ex)
                {
                    // Ignorar si fue causado por server.Stop()
                    if (servidorCorriendo)
                        MessageBox.Show($"Error de socket: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }

        void HandleClient(object obj)
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

                AppendTextSafe($"[{userName}] se ha conectado.\r\n");

                BroadcastMessage($"*** {userName} se ha unido al chat ***", client);

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    AppendTextSafe($"[{userName}]: {mensaje}\r\n");

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

                        AppendTextSafe($"[{userName}] se ha desconectado.\r\n");

                        BroadcastMessage($"*** {userName} ha salido del chat ***", client);
                    }
                }
                client.Close();
            }
        }

        private void AppendTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() => textBox1.AppendText(text)));
            }
            else
            {
                textBox1.AppendText(text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que quieres detener el servidor?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                servidorCorriendo = false;
                server.Stop();
                AppendTextSafe("Servidor detenido.\r\n");
                button1.Enabled = true;
                button2.Enabled = false;
                button1.Visible = true;
                button2.Visible = false;
            }
        }       
    }
}
