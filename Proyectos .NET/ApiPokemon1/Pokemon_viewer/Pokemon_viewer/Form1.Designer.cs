namespace Pokemon_viewer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.ListBox lstHabilidades;
        private System.Windows.Forms.ListBox lstEstadisticas;
        private System.Windows.Forms.ListView lstMovimientos; // CAMBIO A ListView
        private System.Windows.Forms.PictureBox picSprite;
        private System.Windows.Forms.Label lblTipos;
        private System.Windows.Forms.Label lblHabilidades;
        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.PictureBox picTipo1;
        private System.Windows.Forms.PictureBox picTipo2;

        // Nuevo Label para mostrar "Cargando..."
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.Button button1; // botón para shiny

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            btnBuscar = new Button();
            lblDatos = new Label();
            lstHabilidades = new ListBox();
            lstEstadisticas = new ListBox();
            lstMovimientos = new ListView();
            picSprite = new PictureBox();
            lblTipos = new Label();
            lblHabilidades = new Label();
            lblEstadisticas = new Label();
            lblMovimientos = new Label();
            lblCargando = new Label();
            button1 = new Button();
            picTipo1 = new PictureBox();
            picTipo2 = new PictureBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)picSprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTipo1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTipo2).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(230, 18);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 25);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblDatos
            // 
            lblDatos.Location = new Point(20, 60);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(350, 60);
            lblDatos.TabIndex = 2;
            // 
            // lstHabilidades
            // 
            lstHabilidades.ItemHeight = 15;
            lstHabilidades.Location = new Point(150, 150);
            lstHabilidades.Name = "lstHabilidades";
            lstHabilidades.Size = new Size(120, 79);
            lstHabilidades.TabIndex = 6;
            // 
            // lstEstadisticas
            // 
            lstEstadisticas.ItemHeight = 15;
            lstEstadisticas.Location = new Point(280, 150);
            lstEstadisticas.Name = "lstEstadisticas";
            lstEstadisticas.Size = new Size(220, 94);
            lstEstadisticas.TabIndex = 8;
            // 
            // lstMovimientos
            // 
            lstMovimientos.Location = new Point(20, 260);
            lstMovimientos.MultiSelect = false;
            lstMovimientos.Name = "lstMovimientos";
            lstMovimientos.Size = new Size(480, 139);
            lstMovimientos.TabIndex = 10;
            lstMovimientos.UseCompatibleStateImageBehavior = false;
            // 
            // picSprite
            // 
            picSprite.Location = new Point(550, 60);
            picSprite.Name = "picSprite";
            picSprite.Size = new Size(120, 120);
            picSprite.SizeMode = PictureBoxSizeMode.StretchImage;
            picSprite.TabIndex = 11;
            picSprite.TabStop = false;
            // 
            // lblTipos
            // 
            lblTipos.AutoSize = true;
            lblTipos.Location = new Point(20, 130);
            lblTipos.Name = "lblTipos";
            lblTipos.Size = new Size(35, 15);
            lblTipos.TabIndex = 3;
            lblTipos.Text = "Tipos";
            // 
            // lblHabilidades
            // 
            lblHabilidades.AutoSize = true;
            lblHabilidades.Location = new Point(150, 130);
            lblHabilidades.Name = "lblHabilidades";
            lblHabilidades.Size = new Size(69, 15);
            lblHabilidades.TabIndex = 5;
            lblHabilidades.Text = "Habilidades";
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.AutoSize = true;
            lblEstadisticas.Location = new Point(280, 130);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(67, 15);
            lblEstadisticas.TabIndex = 7;
            lblEstadisticas.Text = "Estadísticas";
            // 
            // lblMovimientos
            // 
            lblMovimientos.AutoSize = true;
            lblMovimientos.Location = new Point(20, 240);
            lblMovimientos.Name = "lblMovimientos";
            lblMovimientos.Size = new Size(77, 15);
            lblMovimientos.TabIndex = 9;
            lblMovimientos.Text = "Movimientos";
            // 
            // lblCargando
            // 
            lblCargando.AutoSize = true;
            lblCargando.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCargando.Location = new Point(300, 200);
            lblCargando.Name = "lblCargando";
            lblCargando.Size = new Size(115, 25);
            lblCargando.TabIndex = 12;
            lblCargando.Text = "Cargando...";
            lblCargando.Visible = false;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.Location = new Point(640, 195);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 13;
            button1.Text = "\r\n\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // picTipo1
            // 
            picTipo1.Location = new Point(20, 150);
            picTipo1.Name = "picTipo1";
            picTipo1.Size = new Size(100, 20);
            picTipo1.SizeMode = PictureBoxSizeMode.StretchImage;
            picTipo1.TabIndex = 0;
            picTipo1.TabStop = false;
            // 
            // picTipo2
            // 
            picTipo2.Location = new Point(20, 176);
            picTipo2.Name = "picTipo2";
            picTipo2.Size = new Size(100, 20);
            picTipo2.SizeMode = PictureBoxSizeMode.StretchImage;
            picTipo2.TabIndex = 1;
            picTipo2.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(550, 195);
            button2.Name = "button2";
            button2.Size = new Size(70, 30);
            button2.TabIndex = 14;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(picTipo1);
            Controls.Add(picTipo2);
            Controls.Add(button1);
            Controls.Add(txtNombre);
            Controls.Add(btnBuscar);
            Controls.Add(lblDatos);
            Controls.Add(lblTipos);
            Controls.Add(lblHabilidades);
            Controls.Add(lstHabilidades);
            Controls.Add(lblEstadisticas);
            Controls.Add(lstEstadisticas);
            Controls.Add(lblMovimientos);
            Controls.Add(lstMovimientos);
            Controls.Add(picSprite);
            Controls.Add(lblCargando);
            Name = "Form1";
            Text = "Pokémon Viewer";
            ((System.ComponentModel.ISupportInitialize)picSprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTipo1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTipo2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
    }
}
