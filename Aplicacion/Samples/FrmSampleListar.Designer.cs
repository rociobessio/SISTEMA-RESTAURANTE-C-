namespace Aplicacion.Samples
{
    partial class FrmSampleListar
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            btnAgregar = new Guna.UI2.WinForms.Guna2ImageButton();
            label2 = new Label();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.CustomizableEdges = customizableEdges1;
            txtBuscar.DefaultText = "Buscar aquí...";
            txtBuscar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBuscar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBuscar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBuscar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.IconLeft = Properties.Resources.find;
            txtBuscar.Location = new Point(843, 90);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PasswordChar = '\0';
            txtBuscar.PlaceholderText = "";
            txtBuscar.SelectedText = "";
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtBuscar.Size = new Size(300, 54);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(843, 57);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 1;
            label1.Text = "Buscar";
            label1.Click += label1_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.CheckedState.ImageSize = new Size(64, 64);
            btnAgregar.HoverState.ImageSize = new Size(64, 64);
            btnAgregar.Image = Properties.Resources.add_button;
            btnAgregar.ImageOffset = new Point(0, 0);
            btnAgregar.ImageRotate = 0F;
            btnAgregar.Location = new Point(35, 63);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.PressedState.ImageSize = new Size(64, 64);
            btnAgregar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnAgregar.Size = new Size(96, 81);
            btnAgregar.TabIndex = 2;
            btnAgregar.Click += guna2ImageButton1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(35, 23);
            label2.Name = "label2";
            label2.Size = new Size(164, 38);
            label2.TabIndex = 3;
            label2.Text = "Header Text";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(35, 170);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1108, 15);
            guna2Separator1.TabIndex = 4;
            // 
            // FrmSampleListar
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1155, 614);
            Controls.Add(guna2Separator1);
            Controls.Add(label2);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSampleListar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSampleListar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        public Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        public Label label1;
        public Guna.UI2.WinForms.Guna2ImageButton btnAgregar;
        public Label label2;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}