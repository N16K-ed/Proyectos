namespace Gestion_Empleados
{
    partial class DetallesReporte
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
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(198, 43);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(425, 23);
            textBox1.TabIndex = 10;
            textBox1.TabStop = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(272, 84);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(37, 23);
            textBox3.TabIndex = 11;
            textBox3.TabStop = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(198, 147);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(425, 217);
            textBox4.TabIndex = 12;
            textBox4.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(198, 380);
            button1.Name = "button1";
            button1.Size = new Size(166, 33);
            button1.TabIndex = 1;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(479, 87);
            button2.Name = "button2";
            button2.Size = new Size(144, 33);
            button2.TabIndex = 0;
            button2.Text = "Imprimir PDF";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(457, 380);
            button3.Name = "button3";
            button3.Size = new Size(166, 33);
            button3.TabIndex = 2;
            button3.Text = "Volver al Dashboard";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 87);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 7;
            label1.Text = "Urgente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 25);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 8;
            label2.Text = "Asunto del Reporte:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 129);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 9;
            label3.Text = "Descripción del Reporte:";
            // 
            // DetallesReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Name = "DetallesReporte";
            Text = "Detalles Reporte";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}