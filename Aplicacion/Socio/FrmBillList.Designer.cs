namespace Aplicacion.Socio
{
    partial class FrmBillList
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            dtgvBillList = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgvEditar = new DataGridViewImageColumn();
            dtgvEliminar = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvBillList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Size = new Size(114, 38);
            label1.Text = "Pedidos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bill__1_;
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
            btnCerrar.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.DialogResult = DialogResult.None;
            btnGuardar.DisabledState.BorderColor = Color.DarkGray;
            btnGuardar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGuardar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGuardar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGuardar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGuardar.TabStop = false;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(guna2ControlBox1);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Panel1.Size = new Size(1127, 125);
            guna2Panel1.Controls.SetChildIndex(pictureBox1, 0);
            guna2Panel1.Controls.SetChildIndex(label1, 0);
            guna2Panel1.Controls.SetChildIndex(guna2ControlBox1, 0);
            // 
            // guna2Panel2
            // 
            guna2Panel2.Location = new Point(0, 675);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel2.Size = new Size(1127, 10);
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges3;
            guna2ControlBox1.FillColor = Color.IndianRed;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1047, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ControlBox1.Size = new Size(68, 44);
            guna2ControlBox1.TabIndex = 4;
            guna2ControlBox1.Click += guna2ControlBox1_Click;
            // 
            // dtgvBillList
            // 
            dtgvBillList.AllowUserToAddRows = false;
            dtgvBillList.AllowUserToDeleteRows = false;
            dtgvBillList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgvBillList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.RosyBrown;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgvBillList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgvBillList.ColumnHeadersHeight = 60;
            dtgvBillList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvBillList.Columns.AddRange(new DataGridViewColumn[] { dtgvEditar, dtgvEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgvBillList.DefaultCellStyle = dataGridViewCellStyle3;
            dtgvBillList.GridColor = Color.FromArgb(231, 229, 255);
            dtgvBillList.Location = new Point(24, 210);
            dtgvBillList.Name = "dtgvBillList";
            dtgvBillList.ReadOnly = true;
            dtgvBillList.RowHeadersVisible = false;
            dtgvBillList.RowHeadersWidth = 62;
            dtgvBillList.RowTemplate.Height = 33;
            dtgvBillList.Size = new Size(1069, 459);
            dtgvBillList.TabIndex = 8;
            dtgvBillList.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgvBillList.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgvBillList.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgvBillList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgvBillList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgvBillList.ThemeStyle.BackColor = Color.White;
            dtgvBillList.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgvBillList.ThemeStyle.HeaderStyle.BackColor = Color.RosyBrown;
            dtgvBillList.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgvBillList.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvBillList.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgvBillList.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvBillList.ThemeStyle.HeaderStyle.Height = 60;
            dtgvBillList.ThemeStyle.ReadOnly = true;
            dtgvBillList.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgvBillList.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgvBillList.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvBillList.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgvBillList.ThemeStyle.RowsStyle.Height = 33;
            dtgvBillList.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgvBillList.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgvBillList.CellContentClick += dtgvProductos_CellContentClick;
            // 
            // dtgvEditar
            // 
            dtgvEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgvEditar.FillWeight = 127.840912F;
            dtgvEditar.HeaderText = "";
            dtgvEditar.Image = Properties.Resources.edit_tool;
            dtgvEditar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dtgvEditar.MinimumWidth = 50;
            dtgvEditar.Name = "dtgvEditar";
            dtgvEditar.ReadOnly = true;
            dtgvEditar.Width = 50;
            // 
            // dtgvEliminar
            // 
            dtgvEliminar.FillWeight = 80.53977F;
            dtgvEliminar.HeaderText = "";
            dtgvEliminar.Image = Properties.Resources.trash_bin;
            dtgvEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dtgvEliminar.MinimumWidth = 8;
            dtgvEliminar.Name = "dtgvEliminar";
            dtgvEliminar.ReadOnly = true;
            dtgvEliminar.Visible = false;
            // 
            // FrmBillList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 685);
            Controls.Add(dtgvBillList);
            Name = "FrmBillList";
            Text = "FrmBillList";
            Load += FrmBillList_Load;
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2Panel2, 0);
            Controls.SetChildIndex(dtgvBillList, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvBillList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgvBillList;
        private DataGridViewImageColumn dtgvEditar;
        private DataGridViewImageColumn dtgvEliminar;
    }
}