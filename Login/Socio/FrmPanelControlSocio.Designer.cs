namespace Aplicacion.Socio
{
    partial class FrmPanelControlSocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPanelControlSocio));
            groupBox1 = new GroupBox();
            button1 = new Button();
            btnMesa = new Button();
            btnProductos = new Button();
            btnUsuario = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblUsuario = new Label();
            lblHorarioIngreso = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.CadetBlue;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(btnMesa);
            groupBox1.Controls.Add(btnProductos);
            groupBox1.Controls.Add(btnUsuario);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(0, -16);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(305, 518);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Constantia", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Image = Properties.Resources.servir_pedido_icono1;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(0, 361);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(300, 55);
            button1.TabIndex = 4;
            button1.Text = "                   Pedidos";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnMesa
            // 
            btnMesa.FlatAppearance.BorderSize = 0;
            btnMesa.FlatStyle = FlatStyle.Popup;
            btnMesa.Font = new Font("Constantia", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnMesa.Image = Properties.Resources.mesa_icono;
            btnMesa.ImageAlign = ContentAlignment.MiddleRight;
            btnMesa.Location = new Point(0, 282);
            btnMesa.Margin = new Padding(3, 2, 3, 2);
            btnMesa.Name = "btnMesa";
            btnMesa.Size = new Size(300, 55);
            btnMesa.TabIndex = 3;
            btnMesa.Text = "                   Mesas";
            btnMesa.TextAlign = ContentAlignment.MiddleLeft;
            btnMesa.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Popup;
            btnProductos.Font = new Font("Constantia", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnProductos.Image = Properties.Resources.comida_icono;
            btnProductos.ImageAlign = ContentAlignment.MiddleRight;
            btnProductos.Location = new Point(0, 188);
            btnProductos.Margin = new Padding(3, 2, 3, 2);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(300, 55);
            btnProductos.TabIndex = 2;
            btnProductos.Text = "                   Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = true;
            // 
            // btnUsuario
            // 
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.FlatStyle = FlatStyle.Popup;
            btnUsuario.Font = new Font("Constantia", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsuario.Image = Properties.Resources.worker_icono;
            btnUsuario.ImageAlign = ContentAlignment.MiddleRight;
            btnUsuario.Location = new Point(0, 103);
            btnUsuario.Margin = new Padding(3, 2, 3, 2);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(300, 55);
            btnUsuario.TabIndex = 1;
            btnUsuario.Text = "                   Usuarios";
            btnUsuario.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuario.UseVisualStyleBackColor = true;
            btnUsuario.Click += btnUsuario_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.manager_icono;
            pictureBox1.Location = new Point(522, 32);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(295, 244);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Console", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(546, 278);
            label1.Name = "label1";
            label1.Size = new Size(250, 24);
            label1.TabIndex = 3;
            label1.Text = "PANEL DE CONTROL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Constantia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(311, 464);
            label2.Name = "label2";
            label2.Size = new Size(108, 24);
            label2.TabIndex = 4;
            label2.Text = "USUARIO:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Constantia", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(425, 469);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(42, 19);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "XXX";
            // 
            // lblHorarioIngreso
            // 
            lblHorarioIngreso.AutoSize = true;
            lblHorarioIngreso.Font = new Font("Constantia", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHorarioIngreso.Location = new Point(823, 468);
            lblHorarioIngreso.Name = "lblHorarioIngreso";
            lblHorarioIngreso.Size = new Size(42, 19);
            lblHorarioIngreso.TabIndex = 7;
            lblHorarioIngreso.Text = "XXX";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Constantia", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(618, 464);
            label4.Name = "label4";
            label4.Size = new Size(199, 24);
            label4.TabIndex = 6;
            label4.Text = "Horario de Ingreso:";
            // 
            // FrmPanelControlSocio
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(958, 496);
            Controls.Add(lblHorarioIngreso);
            Controls.Add(label4);
            Controls.Add(lblUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPanelControlSocio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Control";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnUsuario;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label lblUsuario;
        private Label lblHorarioIngreso;
        private Label label4;
        private Button button1;
        private Button btnMesa;
        private Button btnProductos;
    }
}