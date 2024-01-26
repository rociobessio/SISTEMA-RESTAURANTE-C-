namespace Aplicacion
{
    partial class FrmLogin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtClave = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            btnIngresar = new Guna.UI2.WinForms.Guna2Button();
            btnSalir = new Guna.UI2.WinForms.Guna2Button();
            guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.FillColor = Color.Brown;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(430, 270);
            guna2Panel1.TabIndex = 4;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.PikPng_com_restaurant_icon_png_2013813;
            pictureBox1.Location = new Point(91, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 216);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 309);
            label1.Name = "label1";
            label1.Size = new Size(59, 28);
            label1.TabIndex = 5;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // txtEmail
            // 
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(12, 340);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(406, 49);
            txtEmail.TabIndex = 0;
            // 
            // txtClave
            // 
            txtClave.CustomizableEdges = customizableEdges5;
            txtClave.DefaultText = "";
            txtClave.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtClave.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtClave.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtClave.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtClave.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtClave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtClave.Location = new Point(12, 428);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '●';
            txtClave.PlaceholderText = "";
            txtClave.SelectedText = "";
            txtClave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtClave.Size = new Size(406, 49);
            txtClave.TabIndex = 1;
            txtClave.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 397);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 6;
            label2.Text = "Clave";
            // 
            // btnIngresar
            // 
            btnIngresar.Animated = true;
            btnIngresar.AutoRoundedCorners = true;
            btnIngresar.BorderRadius = 25;
            btnIngresar.CustomizableEdges = customizableEdges7;
            btnIngresar.DisabledState.BorderColor = Color.DarkGray;
            btnIngresar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnIngresar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnIngresar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnIngresar.FillColor = Color.IndianRed;
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(262, 499);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnIngresar.Size = new Size(156, 52);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.AutoRoundedCorners = true;
            btnSalir.BorderRadius = 25;
            btnSalir.CustomizableEdges = customizableEdges9;
            btnSalir.DisabledState.BorderColor = Color.DarkGray;
            btnSalir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSalir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSalir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSalir.FillColor = Color.FromArgb(128, 128, 255);
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(12, 499);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSalir.Size = new Size(156, 52);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // guna2MessageDialog1
            // 
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = null;
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            guna2MessageDialog1.Text = null;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 561);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(guna2Panel1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtClave;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnIngresar;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}