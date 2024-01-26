namespace Aplicacion.Socio
{
    partial class FrmAgregarCategoria
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label2 = new Label();
            txtCategoria = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Size = new Size(236, 38);
            label1.Text = "Añadir Categorias";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.category;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // btnCerrar
            // 
            btnCerrar.DialogResult = DialogResult.None;
            btnCerrar.DisabledState.BorderColor = Color.DarkGray;
            btnCerrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCerrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCerrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            // 
            // btnGuardar
            // 
            btnGuardar.DialogResult = DialogResult.None;
            btnGuardar.DisabledState.BorderColor = Color.DarkGray;
            btnGuardar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGuardar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGuardar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGuardar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // guna2Panel1
            // 
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2Panel1.Size = new Size(472, 125);
            // 
            // guna2Panel2
            // 
            guna2Panel2.Location = new Point(0, 317);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(472, 107);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 171);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // txtCategoria
            // 
            txtCategoria.CustomizableEdges = customizableEdges5;
            txtCategoria.DefaultText = "";
            txtCategoria.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCategoria.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCategoria.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCategoria.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCategoria.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoria.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCategoria.Location = new Point(63, 199);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.PasswordChar = '\0';
            txtCategoria.PlaceholderText = "";
            txtCategoria.SelectedText = "";
            txtCategoria.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtCategoria.Size = new Size(300, 54);
            txtCategoria.TabIndex = 3;
            // 
            // FrmAgregarCategoria
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 424);
            Controls.Add(txtCategoria);
            Controls.Add(label2);
            Name = "FrmAgregarCategoria";
            Text = "FrmAgregarCategoria";
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2Panel2, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(txtCategoria, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtCategoria;
    }
}