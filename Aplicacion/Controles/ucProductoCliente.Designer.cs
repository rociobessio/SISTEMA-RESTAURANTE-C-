namespace Aplicacion.Controles
{
    partial class ucProductoCliente
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnSelected = new Guna.UI2.WinForms.Guna2GradientButton();
            lblNombreProducto = new Label();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pcProducto = new PictureBox();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcProducto).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(btnSelected);
            guna2ShadowPanel1.Controls.Add(lblNombreProducto);
            guna2ShadowPanel1.Controls.Add(guna2Separator1);
            guna2ShadowPanel1.Controls.Add(guna2Panel1);
            guna2ShadowPanel1.Controls.Add(pcProducto);
            guna2ShadowPanel1.FillColor = Color.RosyBrown;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(295, 330);
            guna2ShadowPanel1.TabIndex = 1;
            // 
            // btnSelected
            // 
            btnSelected.Animated = true;
            customizableEdges1.BottomLeft = false;
            customizableEdges1.TopLeft = false;
            btnSelected.CustomizableEdges = customizableEdges1;
            btnSelected.DisabledState.BorderColor = Color.DarkGray;
            btnSelected.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSelected.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSelected.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnSelected.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSelected.FillColor = Color.IndianRed;
            btnSelected.FillColor2 = Color.RosyBrown;
            btnSelected.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSelected.ForeColor = Color.White;
            btnSelected.Image = Properties.Resources.check_7084177;
            btnSelected.ImageSize = new Size(40, 40);
            btnSelected.Location = new Point(220, 190);
            btnSelected.Name = "btnSelected";
            btnSelected.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSelected.Size = new Size(72, 70);
            btnSelected.TabIndex = 2;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.BackColor = Color.IndianRed;
            lblNombreProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreProducto.ForeColor = Color.White;
            lblNombreProducto.Location = new Point(4, 190);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(289, 69);
            lblNombreProducto.TabIndex = 0;
            lblNombreProducto.Text = "nombre producto";
            lblNombreProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(-8, 172);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(300, 15);
            guna2Separator1.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.FillColor = Color.Transparent;
            guna2Panel1.Location = new Point(0, 249);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(295, 81);
            guna2Panel1.TabIndex = 1;
            // 
            // pcProducto
            // 
            pcProducto.Dock = DockStyle.Top;
            pcProducto.Image = Properties.Resources.hamburguesa_parrilla_tomate_cebolla_papas_fritas_generada_ia_188544_43039;
            pcProducto.Location = new Point(0, 0);
            pcProducto.Name = "pcProducto";
            pcProducto.Size = new Size(295, 166);
            pcProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pcProducto.TabIndex = 0;
            pcProducto.TabStop = false;
            // 
            // ucProductoCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel1);
            Cursor = Cursors.Hand;
            Name = "ucProductoCliente";
            Size = new Size(295, 263);
            Click += ucProductoCliente_Click;
            guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcProducto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label lblNombreProducto;
        private PictureBox pcProducto;
        private Guna.UI2.WinForms.Guna2GradientButton btnSelected;
    }
}
