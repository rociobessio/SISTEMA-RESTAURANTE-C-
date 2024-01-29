namespace Aplicacion.View
{
    partial class FrmEmpleadosView
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
            dtgvEmpleados = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgvEditar = new DataGridViewImageColumn();
            dtgvEliminar = new DataGridViewImageColumn();
            guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            ((System.ComponentModel.ISupportInitialize)dtgvEmpleados).BeginInit();
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
            txtBuscar.Location = new Point(1142, 131);
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            // 
            // label1
            // 
            label1.Location = new Point(1142, 98);
            // 
            // btnAgregar
            // 
            btnAgregar.CheckedState.ImageSize = new Size(64, 64);
            btnAgregar.DialogResult = DialogResult.None;
            btnAgregar.HoverState.ImageSize = new Size(64, 64);
            btnAgregar.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            btnAgregar.Location = new Point(35, 105);
            btnAgregar.PressedState.ImageSize = new Size(64, 64);
            btnAgregar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label2
            // 
            label2.Location = new Point(35, 64);
            label2.Size = new Size(250, 38);
            label2.Text = "Control Empleados";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(22, 191);
            guna2Separator1.Size = new Size(1420, 15);
            // 
            // dtgvEmpleados
            // 
            dtgvEmpleados.AllowUserToAddRows = false;
            dtgvEmpleados.AllowUserToDeleteRows = false;
            dtgvEmpleados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgvEmpleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.RosyBrown;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgvEmpleados.ColumnHeadersHeight = 40;
            dtgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { dtgvEditar, dtgvEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgvEmpleados.DefaultCellStyle = dataGridViewCellStyle3;
            dtgvEmpleados.GridColor = Color.FromArgb(231, 229, 255);
            dtgvEmpleados.Location = new Point(22, 210);
            dtgvEmpleados.Name = "dtgvEmpleados";
            dtgvEmpleados.ReadOnly = true;
            dtgvEmpleados.RowHeadersVisible = false;
            dtgvEmpleados.RowHeadersWidth = 62;
            dtgvEmpleados.RowTemplate.Height = 33;
            dtgvEmpleados.Size = new Size(1420, 463);
            dtgvEmpleados.TabIndex = 6;
            dtgvEmpleados.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgvEmpleados.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgvEmpleados.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgvEmpleados.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgvEmpleados.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgvEmpleados.ThemeStyle.BackColor = Color.White;
            dtgvEmpleados.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgvEmpleados.ThemeStyle.HeaderStyle.BackColor = Color.RosyBrown;
            dtgvEmpleados.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgvEmpleados.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvEmpleados.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgvEmpleados.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvEmpleados.ThemeStyle.HeaderStyle.Height = 40;
            dtgvEmpleados.ThemeStyle.ReadOnly = true;
            dtgvEmpleados.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgvEmpleados.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgvEmpleados.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvEmpleados.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgvEmpleados.ThemeStyle.RowsStyle.Height = 33;
            dtgvEmpleados.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgvEmpleados.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgvEmpleados.CellContentClick += dtgvEmpleados_CellContentClick;
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
            // FrmEmpleadosView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1460, 702);
            Controls.Add(dtgvEmpleados);
            Name = "FrmEmpleadosView";
            Text = "FrmEmpleadosView";
            Load += FrmEmpleadosView_Load;
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnAgregar, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(guna2Separator1, 0);
            Controls.SetChildIndex(dtgvEmpleados, 0);
            ((System.ComponentModel.ISupportInitialize)dtgvEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgvEmpleados;
        private DataGridViewImageColumn dtgvEditar;
        private DataGridViewImageColumn dtgvEliminar;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}