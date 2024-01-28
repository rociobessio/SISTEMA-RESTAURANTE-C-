namespace Aplicacion.View
{
    partial class FrmMesasView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dtgvMesas = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgvEditar = new DataGridViewImageColumn();
            dtgvEliminar = new DataGridViewImageColumn();
            guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            ((System.ComponentModel.ISupportInitialize)dtgvMesas).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBuscar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBuscar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Location = new Point(1114, 172);
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            txtBuscar.Size = new Size(300, 39);
            // 
            // label1
            // 
            label1.Location = new Point(1114, 139);
            label1.Click += label1_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.CheckedState.ImageSize = new Size(64, 64);
            btnAgregar.DialogResult = DialogResult.None;
            btnAgregar.HoverState.ImageSize = new Size(64, 64);
            btnAgregar.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            btnAgregar.Location = new Point(35, 130);
            btnAgregar.PressedState.ImageSize = new Size(64, 64);
            btnAgregar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label2
            // 
            label2.Location = new Point(35, 90);
            label2.Size = new Size(168, 38);
            label2.Text = "Listar Mesas";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(26, 211);
            guna2Separator1.Size = new Size(1394, 15);
            guna2Separator1.Click += guna2Separator1_Click;
            // 
            // dtgvMesas
            // 
            dtgvMesas.AllowUserToAddRows = false;
            dtgvMesas.AllowUserToDeleteRows = false;
            dtgvMesas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgvMesas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.RosyBrown;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgvMesas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgvMesas.ColumnHeadersHeight = 40;
            dtgvMesas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvMesas.Columns.AddRange(new DataGridViewColumn[] { dtgvEditar, dtgvEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgvMesas.DefaultCellStyle = dataGridViewCellStyle3;
            dtgvMesas.GridColor = Color.FromArgb(231, 229, 255);
            dtgvMesas.Location = new Point(35, 232);
            dtgvMesas.Name = "dtgvMesas";
            dtgvMesas.ReadOnly = true;
            dtgvMesas.RowHeadersVisible = false;
            dtgvMesas.RowHeadersWidth = 62;
            dtgvMesas.RowTemplate.Height = 33;
            dtgvMesas.Size = new Size(1379, 463);
            dtgvMesas.TabIndex = 6;
            dtgvMesas.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgvMesas.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgvMesas.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgvMesas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgvMesas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgvMesas.ThemeStyle.BackColor = Color.White;
            dtgvMesas.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgvMesas.ThemeStyle.HeaderStyle.BackColor = Color.RosyBrown;
            dtgvMesas.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgvMesas.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvMesas.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgvMesas.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvMesas.ThemeStyle.HeaderStyle.Height = 40;
            dtgvMesas.ThemeStyle.ReadOnly = true;
            dtgvMesas.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgvMesas.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgvMesas.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvMesas.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgvMesas.ThemeStyle.RowsStyle.Height = 33;
            dtgvMesas.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgvMesas.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgvMesas.CellContentClick += dtgvCategorias_CellContentClick;
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
            // 
            // guna2MessageDialog1
            // 
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = null;
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            guna2MessageDialog1.Parent = null;
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            guna2MessageDialog1.Text = null;
            // 
            // FrmMesasView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 728);
            Controls.Add(dtgvMesas);
            Name = "FrmMesasView";
            Text = "FrmMesasView";
            Load += FrmMesasView_Load;
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnAgregar, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(guna2Separator1, 0);
            Controls.SetChildIndex(dtgvMesas, 0);
            ((System.ComponentModel.ISupportInitialize)dtgvMesas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgvMesas;
        private DataGridViewImageColumn dtgvEditar;
        private DataGridViewImageColumn dtgvEliminar;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}