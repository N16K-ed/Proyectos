namespace VentanaCliente
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new BotonRedondeado();
            button2 = new BotonRedondeado();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(344, 3);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "ÑISCORD";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 8);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ShortcutsEnabled = false;
            textBox1.Size = new Size(658, 284);
            textBox1.TabIndex = 1;
            textBox1.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(658, 23);
            textBox2.TabIndex = 2;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // button1
            // 
            button1.Location = new Point(74, 407);
            button1.Name = "button1";
            button1.Size = new Size(186, 31);
            button1.TabIndex = 3;
            button1.Text = "CONECTARSE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(546, 406);
            button2.Name = "button2";
            button2.Size = new Size(186, 31);
            button2.TabIndex = 4;
            button2.Text = "DESCONECTARSE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(60, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(687, 298);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(60, 344);
            panel2.Name = "panel2";
            panel2.Size = new Size(687, 32);
            panel2.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private BotonRedondeado button1;
        private BotonRedondeado button2;
        private Panel panel1;
        private Panel panel2;
    }
}
