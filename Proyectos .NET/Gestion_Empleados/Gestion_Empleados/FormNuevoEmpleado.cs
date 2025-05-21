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
    public partial class FormNuevoEmpleado : Form
    {
        private string filePath = Path.Combine(Application.StartupPath, "Datos", "Empleados.txt");
        public FormNuevoEmpleado()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Hay campos vacíos.");
            }
            else
            {                
                if (decimal.TryParse(numericUpDown1.Text, out decimal resultado))
                {
                    try
                    {
                        string directoryPath = Path.Combine(Application.StartupPath, "Datos");
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {
                            writer.Write("***********\nNombre: " +textBox1.Text +
                                "\nApellido 1: " + textBox2.Text + "\nApellido 2: " + textBox3.Text + 
                                "\nSalario: " + numericUpDown1.Value + "\nCargo: " + comboBox1.SelectedItem.ToString() + 
                                "\nEmail: " + textBox5.Text + "\n");
                        }

                        FormDashboard formDashboard = new()
                        {
                            Visible = true
                        };
                        Visible = false;

                        MessageBox.Show("Usuario creado con éxito.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar el archivo: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("El salario no es válido.");
                }
            }
            
        }
    }
}
