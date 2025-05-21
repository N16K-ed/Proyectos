using System.Net.Sockets;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;



namespace VentanaCliente
{
    public class BotonRedondeado : Button
    {
        private int radio = 20;
        private GraphicsPath path;

        private Color bordeColor = Color.Green;
        private int bordeGrosor = 2;

        private Color colorNormal = Color.FromArgb(40, 167, 69);
        private Color colorHover = Color.FromArgb(32, 136, 56);
        private Color colorDeshabilitado = Color.DarkGray;

        private bool estaHover = false;

        public Color BordeColor
        {
            get => bordeColor;
            set { bordeColor = value; Invalidate(); }
        }

        public int BordeGrosor
        {
            get => bordeGrosor;
            set { bordeGrosor = value; Invalidate(); }
        }

        public Color ColorNormal
        {
            get => colorNormal;
            set { colorNormal = value; Invalidate(); }
        }

        public Color ColorHover
        {
            get => colorHover;
            set { colorHover = value; Invalidate(); }
        }

        public Color ColorDeshabilitado
        {
            get => colorDeshabilitado;
            set { colorDeshabilitado = value; Invalidate(); }
        }

        public BotonRedondeado()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            ForeColor = Color.White;

            this.Resize += (s, e) => CrearRegion();

            this.MouseEnter += (s, e) => { estaHover = true; Invalidate(); };
            this.MouseLeave += (s, e) => { estaHover = false; Invalidate(); };

            CrearRegion();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CrearRegion();
            Invalidate();
        }

        private void CrearRegion()
        {
            path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(Width - radio, Height - radio, radio, radio, 0, 90);
            path.AddArc(0, Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width, Height);
            int grosorMitad = bordeGrosor / 2;

            // Usamos un nuevo path para dibujar el borde con márgenes internos
            GraphicsPath bordePath = new GraphicsPath();
            bordePath.AddArc(grosorMitad, grosorMitad, radio, radio, 180, 90);
            bordePath.AddArc(Width - radio - grosorMitad, grosorMitad, radio, radio, 270, 90);
            bordePath.AddArc(Width - radio - grosorMitad, Height - radio - grosorMitad, radio, radio, 0, 90);
            bordePath.AddArc(grosorMitad, Height - radio - grosorMitad, radio, radio, 90, 90);
            bordePath.CloseFigure();

            // Fondo
            Color fondo = !Enabled ? colorDeshabilitado : (estaHover ? colorHover : colorNormal);
            using (SolidBrush fondoBrush = new SolidBrush(fondo))
            {
                g.FillPath(fondoBrush, bordePath);
            }

            // Texto
            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle,
                this.Enabled ? this.ForeColor : Color.LightGray,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Borde
            if (bordeGrosor > 0)
            {
                using (Pen bordePen = new Pen(bordeColor, bordeGrosor))
                {
                    bordePen.Alignment = PenAlignment.Center;
                    g.DrawPath(bordePen, bordePath);
                }
            }

            bordePath.Dispose();
        }

    }


    public partial class Form1 : Form
    {
        private volatile bool continuarRecibiendo = false;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            textBox2.KeyDown += textBox2_KeyDown;

            this.BackColor = Color.FromArgb(24, 26, 27); // Gris oscuro neutro
            this.ForeColor = Color.WhiteSmoke;

            button2.Enabled = false;

            // Configurar botón 1
            button1.BackColor = Color.FromArgb(40, 167, 69);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Text = "CONECTARSE";
            button1.Size = new Size(120, 40);
            button1.Location = new Point(62, 380);
            button1.Click += button1_Click;  // Agrega el evento click

            // Configurar botón 2
            button2.BackColor = Color.FromArgb(220, 53, 69);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Text = "DESCONECTARSE";
            button2.Size = new Size(120, 40);
            button2.Location = new Point(626, 380);
            button2.Enabled = false;
            button2.Click += button2_Click;  // Agrega el evento click
            button2.BordeColor = Color.Red;

            // Configurar label1
            label1.BackColor = Color.FromArgb(24, 26, 27); // Igual que el fondo
            label1.ForeColor = Color.WhiteSmoke;
            label1.Font = new Font("Segoe UI Semibold", 18, FontStyle.Bold);

            // Configurar textBox1
            textBox1.Font = new Font("Consolas", 10);
            textBox1.BackColor = Color.FromArgb(30, 30, 30); // Muy oscuro
            textBox1.ForeColor = Color.FromArgb(135, 206, 250); // Azul cielo claro
            textBox1.BorderStyle = BorderStyle.None;

            // Configurar textBox2
            textBox2.Font = new Font("Consolas", 10);
            textBox2.BackColor = Color.FromArgb(30, 30, 30); // Muy oscuro
            textBox2.ForeColor = Color.FromArgb(135, 206, 250); // Azul cielo claro
            textBox2.BorderStyle = BorderStyle.None;

            // Redondear paneles
            RedondearPanel(panel1, 20);
            RedondearPanel(panel2, 20);
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel2.BackColor = Color.FromArgb(30, 30, 30);
            HacerPanelRedondeadoConHover(panel2, 15, Color.Gray, Color.DeepSkyBlue, 2);
            HacerPanelRedondeado(panel1, 20, Color.Gray, 2);
        }


        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5000);
                stream = client.GetStream();

                string userName = Environment.UserName;
                byte[] userNameData = Encoding.UTF8.GetBytes(userName);
                stream.Write(userNameData, 0, userNameData.Length);

                // Limpia antes de mostrar el mensaje
                textBox1.Clear();

                AppendTextSafe($"Conectado como {userName}. Escribe mensajes para enviar.\n");
                AppendTextSafe("Escribe 'salir' para desconectarte.\n");

                // Alternar botones
                button1.Enabled = false; // Desactivar botón conectar
                button2.Enabled = true;  // Activar botón desconectar

                continuarRecibiendo = true;
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                AppendTextSafe("Error: " + ex.Message + "\n");
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while (continuarRecibiendo && stream != null && (bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendTextSafe("Servidor:" + mensaje);
                }
            }
            catch (Exception ex)
            {
                AppendTextSafe("Desconectado del servidor.\n");
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EnviarMensaje();
            }
        }

        private void EnviarMensaje()
        {
            if (client == null || !client.Connected || stream == null || !stream.CanWrite)
                return;

            string mensaje = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(mensaje))
                return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(mensaje);
                stream.Write(data, 0, data.Length);
                AppendTextSafe("> " + mensaje);
            }
            catch (Exception ex)
            {
                AppendTextSafe("Error al enviar mensaje: " + ex.Message + "\n");
            }

            textBox2.Clear();

            if (mensaje.ToLower() == "salir")
            {
                continuarRecibiendo = false;
                CerrarConexion();
            }
        }



        private void AppendTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new Action(() =>
                {
                    textBox1.AppendText(text + "\r\n");
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();

                }));
            }
            else
            {
                textBox1.AppendText(text + "\r\n");
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
        }



        private void CerrarConexion()
        {
            try
            {
                stream?.Close();
                client?.Close();

                textBox1.Clear();
                AppendTextSafe("Conexión cerrada.");

                button1.Enabled = true;
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                AppendTextSafe("Error al cerrar conexión: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            continuarRecibiendo = false;
            CerrarConexion();
        }
        private void RedondearPanel(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radio, panel.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        private void HacerPanelRedondeadoConHover(Panel panel, int radio, Color colorNormal, Color colorHover, int grosor)
        {
            Color colorActual = colorNormal;

            void Redibujar(Color nuevoColor)
            {
                colorActual = nuevoColor;
                panel.Invalidate();
            }

            panel.MouseEnter += (s, e) => Redibujar(colorHover);
            panel.MouseLeave += (s, e) =>
            {
                if (!panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                    Redibujar(colorNormal);
            };

            foreach (Control child in panel.Controls)
            {
                child.MouseEnter += (s, e) => Redibujar(colorHover);
                child.MouseLeave += (s, e) =>
                {
                    if (!panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                        Redibujar(colorNormal);
                };
            }

            // Método para crear el path redondeado
            GraphicsPath CrearPathRedondeado(Rectangle rect, int radius)
            {
                int d = radius * 2;
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                return path;
            }

            // Asignar la región solo cuando se redimensiona
            panel.Resize += (s, e) =>
            {
                using (GraphicsPath path = CrearPathRedondeado(panel.ClientRectangle, radio))
                {
                    panel.Region?.Dispose();  // Liberar región anterior
                    panel.Region = new Region(path);
                }
                panel.Invalidate();
            };

            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Descontar la mitad del grosor para que la línea quede dentro
                int offset = grosor / 2;
                Rectangle rect = new Rectangle(offset, offset, panel.Width - grosor, panel.Height - grosor);

                using (GraphicsPath path = CrearPathRedondeado(rect, radio))
                {
                    using (Pen pen = new Pen(colorActual, grosor))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        private void HacerPanelRedondeado(Panel panel, int radio, Color colorBorde, int grosor)
        {
            // Método para crear el path redondeado
            GraphicsPath CrearPathRedondeado(Rectangle rect, int radius)
            {
                int d = radius * 2;
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                return path;
            }

            panel.Resize += (s, e) =>
            {
                int offset = grosor / 2;
                Rectangle rect = new Rectangle(offset, offset, panel.Width - grosor, panel.Height - grosor);

                using (GraphicsPath path = CrearPathRedondeado(rect, radio))
                {
                    panel.Region?.Dispose();
                    panel.Region = new Region(path);
                }
                panel.Invalidate();
            };

            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int offset = grosor / 2;
                Rectangle rect = new Rectangle(offset, offset, panel.Width - grosor, panel.Height - grosor);

                using (GraphicsPath path = CrearPathRedondeado(rect, radio))
                {
                    using (Pen pen = new Pen(colorBorde, grosor))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }        
    }
}
