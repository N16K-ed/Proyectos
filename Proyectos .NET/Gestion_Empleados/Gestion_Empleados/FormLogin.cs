namespace Gestion_Empleados
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Admin") && textBox2.Text.Equals("ADMIN"))
            {
                this.Visible = false;
                FormDashboard formDashboard = new()
                {
                    Visible = true
                };
            }
            else
            {
                label4.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}
