namespace Aplicacion.Controles
{
    partial class ucPago
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            numericUpDownCantidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            lblPrecio = new Label();
            pcEliminar = new PictureBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcEliminar).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.BackColor = Color.Transparent;
            numericUpDownCantidad.BorderColor = Color.RosyBrown;
            numericUpDownCantidad.CustomizableEdges = customizableEdges3;
            numericUpDownCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownCantidad.Location = new Point(320, 24);
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numericUpDownCantidad.Size = new Size(117, 44);
            numericUpDownCantidad.TabIndex = 0;
            numericUpDownCantidad.UpDownButtonFillColor = Color.RosyBrown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 13);
            label1.Name = "label1";
            label1.Size = new Size(157, 25);
            label1.TabIndex = 1;
            label1.Text = "Nombre producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(69, 53);
            label2.Name = "label2";
            label2.Size = new Size(57, 19);
            label2.TabIndex = 2;
            label2.Text = "@22:00";
            label2.Click += label2_Click;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecio.Location = new Point(467, 36);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(52, 25);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "2300";
            // 
            // pcEliminar
            // 
            pcEliminar.Image = Properties.Resources.trash_7874233;
            pcEliminar.Location = new Point(6, 13);
            pcEliminar.Name = "pcEliminar";
            pcEliminar.Size = new Size(57, 59);
            pcEliminar.SizeMode = PictureBoxSizeMode.Zoom;
            pcEliminar.TabIndex = 4;
            pcEliminar.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 2;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ucPago
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pcEliminar);
            Controls.Add(lblPrecio);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownCantidad);
            Name = "ucPago";
            Size = new Size(586, 92);
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcEliminar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown numericUpDownCantidad;
        private Label label1;
        private Label label2;
        private Label lblPrecio;
        private PictureBox pcEliminar;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
