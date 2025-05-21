using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Empleados
{

    public partial class FormEmpleados : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List<Empleado> buscar = new List<Empleado>();
        public FormEmpleados()
        {

            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
            this.Load += new EventHandler(FormEmpleados_Load);
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "Datos", "Empleados.txt");
            dataGridView2.DataSource = buscar;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string linea;
                    Empleado empleadoActual = null;

                    while ((linea = reader.ReadLine()) != null)
                    {
                        linea = linea.Trim();
                        if (linea.StartsWith("********"))
                        {
                            if (empleadoActual != null)
                            {
                                empleados.Add(empleadoActual);
                                empleadoActual = null;
                            }
                            continue;
                        }
                        string[] partes = linea.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (partes.Length == 2)
                        {
                            string campo = partes[0].Trim();
                            string valor = partes[1].Trim();
                            if (empleadoActual == null)
                            {
                                empleadoActual = new Empleado();
                            }
                            switch (campo)
                            {
                                case "Nombre":
                                    empleadoActual.Nombre = valor;
                                    break;
                                case "Apellido 1":
                                    empleadoActual.Apellido1 = valor;
                                    break;
                                case "Apellido 2":
                                    empleadoActual.Apellido2 = valor;
                                    break;
                                case "Salario":
                                    if (decimal.TryParse(valor, out decimal salario))
                                    {
                                        empleadoActual.Salario = salario;
                                    }
                                    break;
                                case "Cargo":
                                    empleadoActual.Cargo = valor;
                                    break;
                                case "Email":
                                    empleadoActual.Email = valor;
                                    break;
                            }
                        }
                    }
                    if (empleadoActual != null)
                    {
                        empleados.Add(empleadoActual);
                    }
                }
                dataGridView1.DataSource = empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}");
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
            buscar.Clear();

            string nombre = textBox1.Text.Trim();
            string cargo = comboBox1.SelectedItem?.ToString();
            decimal salario = numericUpDown1.Value;

            bool buscarPorNombre = !string.IsNullOrWhiteSpace(nombre) && !nombre.Equals("Nombre", StringComparison.OrdinalIgnoreCase);
            bool buscarPorCargo = !string.IsNullOrWhiteSpace(cargo);
            bool buscarPorSalario = salario > 0;

            foreach (Empleado emp in empleados)
            {
                bool coincide = true;

                if (buscarPorNombre && !emp.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    coincide = false;

                if (buscarPorCargo && !emp.Cargo.Equals(cargo, StringComparison.OrdinalIgnoreCase))
                    coincide = false;

                if (buscarPorSalario && emp.Salario != salario)
                    coincide = false;

                if (coincide)
                    buscar.Add(emp);
            }

            if (buscar.Count == 0)
            {
                MessageBox.Show("No se ha encontrado al empleado buscado.");
            }

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = buscar;
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
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string filePath = Path.Combine(Application.StartupPath, "Datos", "Empleados.txt");
                        if (File.Exists(filePath))
                        {
                            string[] lines = File.ReadAllLines(filePath);
                            List<string> updatedLines = new List<string>();
                            bool isEmpleadoBlock = false;
                            bool eliminarBloque = false;

                            foreach (string line in lines)
                            {
                                string trimmedLine = line.Trim();

                                if (trimmedLine.StartsWith("***********"))
                                {
                                    if (isEmpleadoBlock && eliminarBloque)
                                    {
                                        isEmpleadoBlock = false;
                                        eliminarBloque = false;
                                        continue;
                                    }
                                    isEmpleadoBlock = true;
                                    eliminarBloque = false;
                                    continue;
                                }

                                if (isEmpleadoBlock)
                                {
                                    if (trimmedLine.StartsWith("Nombre:") && trimmedLine.Contains(empleadoUnico.Nombre)) eliminarBloque = true;
                                    if (trimmedLine.StartsWith("Apellido 1:") && trimmedLine.Contains(empleadoUnico.Apellido1)) eliminarBloque = true;
                                    if (trimmedLine.StartsWith("Apellido 2:") && trimmedLine.Contains(empleadoUnico.Apellido2)) eliminarBloque = true;
                                    if (trimmedLine.StartsWith("Salario:") && trimmedLine.Contains(empleadoUnico.Salario.ToString("F2"))) eliminarBloque = true;
                                    if (trimmedLine.StartsWith("Cargo:") && trimmedLine.Contains(empleadoUnico.Cargo)) eliminarBloque = true;
                                    if (trimmedLine.StartsWith("Email:") && trimmedLine.Contains(empleadoUnico.Email)) eliminarBloque = true;

                                    if (eliminarBloque)
                                    {
                                       continue;
                                    }
                                }

                                updatedLines.Add(line);
                            }

                            File.WriteAllLines(filePath, updatedLines);

                            MessageBox.Show($"El empleado {empleadoUnico.Nombre} ha sido eliminado del sistema.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FormEmpleados newForm = new()
                            {
                                Visible = true
                            };
                            Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("El archivo de empleados no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
