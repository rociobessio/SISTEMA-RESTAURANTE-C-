namespace Aplicacion.Socio
{
    partial class FrmAgregarMesa
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cbEstadoMesa = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            txtCodigoMesa = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Size = new Size(259, 38);
            label1.Text = "Añadir Nueva Mesa";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.lounge_table;
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
            guna2Panel1.Size = new Size(495, 125);
            // 
            // guna2Panel2
            // 
            guna2Panel2.Location = new Point(0, 343);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(495, 107);
            // 
            // cbEstadoMesa
            // 
            cbEstadoMesa.BackColor = Color.Transparent;
            cbEstadoMesa.CustomizableEdges = customizableEdges5;
            cbEstadoMesa.DrawMode = DrawMode.OwnerDrawFixed;
            cbEstadoMesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstadoMesa.Enabled = false;
            cbEstadoMesa.FocusedColor = Color.FromArgb(94, 148, 255);
            cbEstadoMesa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbEstadoMesa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbEstadoMesa.ForeColor = Color.FromArgb(68, 88, 112);
            cbEstadoMesa.ItemHeight = 30;
            cbEstadoMesa.Location = new Point(24, 183);
            cbEstadoMesa.Name = "cbEstadoMesa";
            cbEstadoMesa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbEstadoMesa.Size = new Size(446, 36);
            cbEstadoMesa.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 155);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 4;
            label2.Text = "Estado de la Mesa";
            label2.Click += label2_Click;
            // 
            // txtCodigoMesa
            // 
            txtCodigoMesa.CustomizableEdges = customizableEdges7;
            txtCodigoMesa.DefaultText = "";
            txtCodigoMesa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCodigoMesa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCodigoMesa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCodigoMesa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCodigoMesa.Enabled = false;
            txtCodigoMesa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCodigoMesa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMesa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCodigoMesa.Location = new Point(24, 276);
            txtCodigoMesa.Name = "txtCodigoMesa";
            txtCodigoMesa.PasswordChar = '\0';
            txtCodigoMesa.PlaceholderText = "";
            txtCodigoMesa.SelectedText = "";
            txtCodigoMesa.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtCodigoMesa.Size = new Size(446, 45);
            txtCodigoMesa.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 248);
            label3.Name = "label3";
            label3.Size = new Size(118, 25);
            label3.TabIndex = 6;
            label3.Text = "Codigo Mesa";
            label3.Click += label3_Click;
            // 
            // FrmAgregarMesa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 450);
            Controls.Add(label3);
            Controls.Add(txtCodigoMesa);
            Controls.Add(label2);
            Controls.Add(cbEstadoMesa);
            Name = "FrmAgregarMesa";
            Text = "FrmAgregarMesa";
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2Panel2, 0);
            Controls.SetChildIndex(cbEstadoMesa, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(txtCodigoMesa, 0);
            Controls.SetChildIndex(label3, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbEstadoMesa;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoMesa;
        private Label label3;
    }
}