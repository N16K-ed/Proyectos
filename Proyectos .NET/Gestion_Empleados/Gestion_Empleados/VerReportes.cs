using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_Empleados
{
    public partial class VerReportes : Form
    {
        private string connectionString = "Server=PMPW1364\\SQLEXPRESS;Database=bdGestionEmpleados;Trusted_Connection=True;";
        private List<Reporte> reportes = new List<Reporte>();

        public VerReportes()
        {
            InitializeComponent();
            this.Load += VerReportes_Load;
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
            button2.Click += Button2_Click;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void VerReportes_Load(object sender, EventArgs e)
        {
            CargarReportesDesdeBD();

            comboBox1.DataSource = reportes;
            comboBox1.DisplayMember = "Id"; // Puedes cambiar a "ToString" para mostrar Id y asunto juntos
            comboBox1.ValueMember = "Id";

            // Proyección para el DataGridView, incluyendo el símbolo para urgente
            var listaParaGrid = reportes.Select(r => new
            {
                r.Id,
                r.Asunto,
                Urgente = r.Urgente ? "✓" : "X"
            }).ToList();

            dataGridView1.DataSource = listaParaGrid;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Asunto";
            dataGridView1.Columns[2].HeaderText = "Urgente";

            dataGridView1.AutoResizeColumns();
        }

        private void CargarReportesDesdeBD()
        {
            reportes.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Asunto, Descripcion, Urgente FROM Reportes";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reportes.Add(new Reporte
                                {
                                    Id = reader.GetInt32(0),
                                    Asunto = reader.GetString(1),
                                    Descripcion = reader.GetString(2),
                                    Urgente = reader.GetBoolean(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reportes: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int idReporte))
            {
                DetallesReporte detallesReporte = new DetallesReporte(idReporte)
                {
                    Visible = true
                };
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormDashboard formDashboard = new()
                    {
                        Visible = true
                    };
                    Visible = false;
        }
    }

    public class Reporte
    {
        public int Id { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public bool Urgente { get; set; }

        public override string ToString()
        {
            return $"ID {Id} - {Asunto}";
        }
    }
}
