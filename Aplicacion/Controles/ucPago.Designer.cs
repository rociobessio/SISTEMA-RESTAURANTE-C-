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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            numericUpDownCantidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblNombreProducto = new Label();
            lblCategoria = new Label();
            lblPrecio = new Label();
            pictureBoxEliminar = new PictureBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEliminar).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.BackColor = Color.Transparent;
            numericUpDownCantidad.BorderColor = Color.RosyBrown;
            numericUpDownCantidad.CustomizableEdges = customizableEdges1;
            numericUpDownCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownCantidad.Location = new Point(335, 28);
            numericUpDownCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.ShadowDecoration.CustomizableEdges = customizableEdges2;
            numericUpDownCantidad.Size = new Size(117, 44);
            numericUpDownCantidad.TabIndex = 0;
            numericUpDownCantidad.UpDownButtonFillColor = Color.RosyBrown;
            numericUpDownCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(69, 13);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(157, 25);
            lblNombreProducto.TabIndex = 1;
            lblNombreProducto.Text = "Nombre producto";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategoria.ForeColor = Color.Gray;
            lblCategoria.Location = new Point(69, 40);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(57, 19);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "@22:00";
            lblCategoria.Click += label2_Click;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.Location = new Point(526, 47);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(52, 25);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "2300";
            // 
            // pictureBoxEliminar
            // 
            pictureBoxEliminar.Image = Properties.Resources.trash_7874233;
            pictureBoxEliminar.Location = new Point(6, 13);
            pictureBoxEliminar.Name = "pictureBoxEliminar";
            pictureBoxEliminar.Size = new Size(57, 59);
            pictureBoxEliminar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEliminar.TabIndex = 4;
            pictureBoxEliminar.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 2;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(509, 47);
            label1.Name = "label1";
            label1.Size = new Size(22, 25);
            label1.TabIndex = 5;
            label1.Text = "$";
            // 
            // ucPago
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(label1);
            Controls.Add(pictureBoxEliminar);
            Controls.Add(lblPrecio);
            Controls.Add(lblCategoria);
            Controls.Add(lblNombreProducto);
            Controls.Add(numericUpDownCantidad);
            Name = "ucPago";
            Size = new Size(612, 94);
            Load += ucPago_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEliminar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown numericUpDownCantidad;
        private Label lblNombreProducto;
        private Label lblCategoria;
        private Label lblPrecio;
        private PictureBox pictureBoxEliminar;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label1;
    }
}
