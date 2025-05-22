using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_Empleados
{
    public partial class DetallesReporte : Form
    {
        private int reporteId;

        public DetallesReporte(int id)
        {
            InitializeComponent();
            reporteId = id;
            CargarReporte();
        }

        private void CargarReporte()
        {
            string connectionString = "Server=PMPW1364\\SQLEXPRESS;Database=bdGestionEmpleados;Trusted_Connection=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Asunto, Descripcion, Urgente FROM Reportes WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", reporteId);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader.GetString(0); // Asunto
                                textBox4.Text = reader.GetString(1); // Descripción
                                bool urgente = reader.GetBoolean(2);
                                textBox3.Text = urgente ? "✔" : "X"; // Urgente
                            }
                            else
                            {
                                MessageBox.Show("Reporte no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerReportes verDashboard = new()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDashboard formDashboard = new()
            {
                Visible = true
            };
            Visible = false;
        }
    }
}
