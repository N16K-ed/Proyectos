using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_Empleados
{
    public partial class FormEmpleados : Form
    {
        private string connectionString = "Server=PMPW1364\\SQLEXPRESS;Database=bdGestionEmpleados;Trusted_Connection=True;";
        private List<Empleado> empleados = new List<Empleado>();
        private List<Empleado> buscar = new List<Empleado>();

        public FormEmpleados()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
            this.Load += new EventHandler(FormEmpleados_Load);
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            empleados.Clear();

            string query = "SELECT Id, Nombre, Apellido1, Apellido2, Salario, Cargo, Email FROM Empleados";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empleados.Add(new Empleado
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido1 = reader.GetString(2),
                                Apellido2 = reader.GetString(3),
                                Salario = reader.GetDecimal(4),
                                Cargo = reader.GetString(5),
                                Email = reader.GetString(6)
                            });
                        }
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = empleados;

                // Ocultar la columna Id para que no sea visible
                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }

                buscar.Clear();
                dataGridView2.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string apellido1 = textBox2.Text.Trim();
            string apellido2 = textBox3.Text.Trim();
            string cargo = comboBox1.SelectedItem?.ToString() ?? "";
            decimal salario = numericUpDown1.Value;

            bool filtrarNombre = !string.IsNullOrWhiteSpace(nombre);
            bool filtrarApellido1 = !string.IsNullOrWhiteSpace(apellido1);
            bool filtrarApellido2 = !string.IsNullOrWhiteSpace(apellido2);
            bool filtrarCargo = !string.IsNullOrWhiteSpace(cargo);
            bool filtrarSalario = salario > 0;

            buscar = empleados.FindAll(emp =>
                (!filtrarNombre || emp.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (!filtrarApellido1 || emp.Apellido1.Equals(apellido1, StringComparison.OrdinalIgnoreCase)) &&
                (!filtrarApellido2 || emp.Apellido2.Equals(apellido2, StringComparison.OrdinalIgnoreCase)) &&
                (!filtrarCargo || emp.Cargo.Equals(cargo, StringComparison.OrdinalIgnoreCase)) &&
                (!filtrarSalario || emp.Salario >= salario)
            );

            if (buscar.Count == 0)
            {
                MessageBox.Show("No se ha encontrado al empleado buscado.");
            }

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = buscar;
            if (dataGridView2.Columns["Id"] != null)
            {
                dataGridView2.Columns["Id"].Visible = false;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (buscar == null || buscar.Count == 0)
            {
                MessageBox.Show("No hay empleados en la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (buscar.Count == 1)
            {
                Empleado empleadoUnico = buscar[0];
                DialogResult result = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar al empleado {empleadoUnico.Nombre} {empleadoUnico.Apellido1} {empleadoUnico.Apellido2}?",
                    "Confirmación de Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Empleados WHERE Id = @Id", con))
                        {
                            cmd.Parameters.AddWithValue("@Id", empleadoUnico.Id);
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarEmpleados(); // Refresca la lista después de eliminar
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("La búsqueda no es lo suficientemente precisa, hay más de un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDashboard formDashboard = new()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Nombre";
            comboBox1.SelectedItem = null;
            numericUpDown1.Value = 0;
        }
        public class Empleado
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido1 { get; set; }
            public string Apellido2 { get; set; }
            public decimal Salario { get; set; }
            public string Cargo { get; set; }
            public string Email { get; set; }
        }
    }
}
