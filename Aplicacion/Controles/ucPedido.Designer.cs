namespace Aplicacion.Controles
{
    partial class ucPedido
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
            lblDiaPedido = new Label();
            lbl = new Label();
            lblCodPedido = new Label();
            label1 = new Label();
            lblTotal = new Label();
            lblEstado = new Label();
            SuspendLayout();
            // 
            // lblDiaPedido
            // 
            lblDiaPedido.AutoSize = true;
            lblDiaPedido.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lblDiaPedido.ForeColor = Color.Gray;
            lblDiaPedido.Location = new Point(22, 44);
            lblDiaPedido.Name = "lblDiaPedido";
            lblDiaPedido.Size = new Size(32, 19);
            lblDiaPedido.TabIndex = 4;
            lblDiaPedido.Text = "DIA";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl.ForeColor = Color.IndianRed;
            lbl.Location = new Point(22, 17);
            lbl.Name = "lbl";
            lbl.Size = new Size(139, 25);
            lbl.TabIndex = 3;
            lbl.Text = "Código Pedido:";
            // 
            // lblCodPedido
            // 
            lblCodPedido.AutoSize = true;
            lblCodPedido.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodPedido.ForeColor = Color.IndianRed;
            lblCodPedido.Location = new Point(167, 17);
            lblCodPedido.Name = "lblCodPedido";
            lblCodPedido.Size = new Size(26, 25);
            lblCodPedido.TabIndex = 5;
            lblCodPedido.Text = "--";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(354, 66);
            label1.Name = "label1";
            label1.Size = new Size(22, 25);
            label1.TabIndex = 6;
            label1.Text = "$";
            label1.Click += label1_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.IndianRed;
            lblTotal.Location = new Point(368, 66);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(46, 25);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "0.00";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold, GraphicsUnit.Point);
            lblEstado.ForeColor = Color.Gray;
            lblEstado.Location = new Point(22, 72);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(63, 19);
            lblEstado.TabIndex = 8;
            lblEstado.Text = "@Estado";
            // 
            // ucPedido
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEstado);
            Controls.Add(lblTotal);
            Controls.Add(label1);
            Controls.Add(lblCodPedido);
            Controls.Add(lblDiaPedido);
            Controls.Add(lbl);
            Cursor = Cursors.Hand;
            Name = "ucPedido";
            Size = new Size(454, 102);
            Click += ucPedido_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDiaPedido;
        private Label lbl;
        private Label lblCodPedido;
        private Label label1;
        private Label lblTotal;
        private Label lblEstado;
    }
}
