using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Empleados
{
    public partial class FormDashboard : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        public FormDashboard()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
            this.Load += new EventHandler(FormDashboard_Load);
        }
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=PMPW1364\\SQLEXPRESS;Database=bdGestionEmpleados;Trusted_Connection=True;";
            int contadorEmpleados = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Empleados";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        contadorEmpleados = (int)command.ExecuteScalar();
                    }
                }

                textBox1.Text = contadorEmpleados.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar empleados: " + ex.Message);
            }
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
            FormEmpleados formEmpleados = new()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormNuevoEmpleado formNuevoEmpleado = new()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VerReportes verReportes = new()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new()
            {
                Visible = true
            };
            Visible = false;
        }
    }
}
