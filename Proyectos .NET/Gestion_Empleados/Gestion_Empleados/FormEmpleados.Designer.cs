namespace Gestion_Empleados
{
    partial class FormEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            button3 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(58, 329);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(683, 246);
            dataGridView1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(58, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 85);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(166, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(141, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(517, 58);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 3;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "JEFE", "CARGO1", "CARGO2", "CARGO3" });
            comboBox1.Location = new Point(517, 103);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(224, 23);
            comboBox1.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Enabled = false;
            dataGridView2.Location = new Point(58, 156);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(683, 141);
            dataGridView2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(517, 85);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 7;
            label1.Text = "Cargo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 41);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 8;
            label2.Text = "Salario:";
            // 
            // button2
            // 
            button2.Location = new Point(155, 602);
            button2.Name = "button2";
            button2.Size = new Size(273, 38);
            button2.TabIndex = 9;
            button2.Text = "Volver al Dashboard";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(352, 60);
            numericUpDown1.Maximum = new decimal(new int[] { 9999999, 0, 0, 131072 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(141, 23);
            numericUpDown1.TabIndex = 10;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(653, 58);
            button3.Name = "button3";
            button3.Size = new Size(88, 23);
            button3.TabIndex = 11;
            button3.Text = "Borrar Filtros";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.IndianRed;
            button4.ForeColor = Color.Maroon;
            button4.Location = new Point(454, 602);
            button4.Name = "button4";
            button4.Size = new Size(208, 38);
            button4.TabIndex = 12;
            button4.Text = "ELIMINAR EMPLEADO";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(166, 103);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(141, 23);
            textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(352, 103);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(141, 23);
            textBox3.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 85);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 15;
            label3.Text = "Apellidos:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 41);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 16;
            label4.Text = "Nombre:";
            // 
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 661);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Name = "FormEmpleados";
            Text = "Ver Empleados";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Button button1;
        private ComboBox comboBox1;
        private DataGridView dataGridView2;
        private Label label1;
        private Label label2;
        private Button button2;
        private NumericUpDown numericUpDown1;
        private Button button3;
        private Button button4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
    }
}