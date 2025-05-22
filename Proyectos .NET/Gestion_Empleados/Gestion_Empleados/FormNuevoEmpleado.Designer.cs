namespace Gestion_Empleados
{
    partial class FormNuevoEmpleado
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(259, 54);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 108);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Apellido 1:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(384, 108);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Apellido 2:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(259, 163);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Salario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(384, 163);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 4;
            label5.Text = "Cargo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(259, 221);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 5;
            label6.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(539, 54);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 6;
            label7.Text = "Foto de perfil:";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(539, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(259, 298);
            button1.Name = "button1";
            button1.Size = new Size(237, 42);
            button1.TabIndex = 8;
            button1.Text = "Agregar Empleado";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(259, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(237, 23);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(259, 126);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(112, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(384, 126);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(112, 23);
            textBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(259, 239);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(237, 23);
            textBox5.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "JEFE", "CARGO1", "CARGO2", "CARGO3" });
            comboBox1.Location = new Point(384, 181);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 23);
            comboBox1.TabIndex = 14;
            // 
            // button2
            // 
            button2.Location = new Point(259, 356);
            button2.Name = "button2";
            button2.Size = new Size(237, 42);
            button2.TabIndex = 15;
            button2.Text = "Volver al Dashboard";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(259, 181);
            numericUpDown1.Maximum = new decimal(new int[] { 9999999, 0, 0, 131072 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(112, 23);
            numericUpDown1.TabIndex = 16;
            // 
            // button3
            // 
            button3.Location = new Point(539, 239);
            button3.Name = "button3";
            button3.Size = new Size(150, 42);
            button3.TabIndex = 17;
            button3.Text = "Añadir Foto de Perfil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FormNuevoEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormNuevoEmpleado";
            Text = "Nuevo Empleado";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox5;
        private ComboBox comboBox1;
        private Button button2;
        private NumericUpDown numericUpDown1;
        private Button button3;
    }
}