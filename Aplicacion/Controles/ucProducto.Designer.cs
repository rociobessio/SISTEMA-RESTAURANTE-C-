namespace Aplicacion.Socio
{
    partial class ucProducto
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblNombreProducto = new Label();
            pcProducto = new PictureBox();
            guna2ShadowPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcProducto).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(guna2Separator1);
            guna2ShadowPanel1.Controls.Add(guna2Panel1);
            guna2ShadowPanel1.Controls.Add(pcProducto);
            guna2ShadowPanel1.FillColor = Color.RosyBrown;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(271, 238);
            guna2ShadowPanel1.TabIndex = 0;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(-17, 157);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(300, 15);
            guna2Separator1.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(lblNombreProducto);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.FillColor = Color.Transparent;
            guna2Panel1.Location = new Point(0, 157);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(271, 81);
            guna2Panel1.TabIndex = 1;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.BackColor = Color.IndianRed;
            lblNombreProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreProducto.ForeColor = Color.White;
            lblNombreProducto.Location = new Point(3, 3);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(265, 78);
            lblNombreProducto.TabIndex = 0;
            lblNombreProducto.Text = "nombre producto";
            lblNombreProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pcProducto
            // 
            pcProducto.Image = Properties.Resources.hamburguesa_parrilla_tomate_cebolla_papas_fritas_generada_ia_188544_43039;
            pcProducto.Location = new Point(23, 14);
            pcProducto.Name = "pcProducto";
            pcProducto.Size = new Size(231, 143);
            pcProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pcProducto.TabIndex = 0;
            pcProducto.TabStop = false;
            pcProducto.Click += pcProducto_Click;
            // 
            // ucProducto
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(guna2ShadowPanel1);
            Name = "ucProducto";
            Size = new Size(271, 241);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcProducto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label lblNombreProducto;
        private PictureBox pcProducto;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}
