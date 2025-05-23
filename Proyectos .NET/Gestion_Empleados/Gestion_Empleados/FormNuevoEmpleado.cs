﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Gestion_Empleados
{
    public partial class FormNuevoEmpleado : Form
    {
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
        private void button1_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Hay campos vacíos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar salario (aunque NumericUpDown ya limita esto)
            decimal salario = numericUpDown1.Value;
            if (salario <= 0)
            {
                MessageBox.Show("El salario debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "Server=PMPW1364\\SQLEXPRESS;Database=bdGestionEmpleados;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Empleados 
                     (Nombre, Apellido1, Apellido2, Cargo, Email, Salario, FotoPerfil) 
                     VALUES 
                     (@Nombre, @Apellido1, @Apellido2, @Cargo, @Email, @Salario, @FotoPerfil)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", textBox1.Text.Trim());
                        command.Parameters.AddWithValue("@Apellido1", textBox2.Text.Trim());
                        command.Parameters.AddWithValue("@Apellido2", textBox3.Text.Trim());
                        command.Parameters.AddWithValue("@Cargo", comboBox1.SelectedItem?.ToString() ?? "");
                        command.Parameters.AddWithValue("@Email", textBox5.Text.Trim());
                        command.Parameters.AddWithValue("@Salario", salario);

                        // Imagen de perfil
                        if (pictureBox1.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] imageBytes = ms.ToArray();
                                command.Parameters.AddWithValue("@FotoPerfil", imageBytes);
                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@FotoPerfil", DBNull.Value);
                        }

                        int filasAfectadas = command.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se insertó ningún registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                FormDashboard formDashboard = new()
                {
                    Visible = true
                };
                Visible = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción UNIQUE
                {
                    MessageBox.Show("Ya existe un empleado con esos apellidos o correo. No se puede duplicar.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen de perfil";
                ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste para que encaje bien
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
