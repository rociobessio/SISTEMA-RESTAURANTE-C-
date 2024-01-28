namespace Aplicacion.View
{
    partial class FrmCategoriasView
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
            dtgvCategorias = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgvEditar = new DataGridViewImageColumn();
            dtgvEliminar = new DataGridViewImageColumn();
            guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            ((System.ComponentModel.ISupportInitialize)dtgvCategorias).BeginInit();
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
            txtBuscar.Location = new Point(1072, 144);
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            txtBuscar.Size = new Size(392, 54);
            // 
            // label1
            // 
            label1.Location = new Point(1072, 111);
            // 
            // btnAgregar
            // 
            btnAgregar.CheckedState.ImageSize = new Size(64, 64);
            btnAgregar.DialogResult = DialogResult.None;
            btnAgregar.HoverState.ImageSize = new Size(64, 64);
            btnAgregar.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            btnAgregar.Location = new Point(97, 117);
            btnAgregar.PressedState.ImageSize = new Size(64, 64);
            btnAgregar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label2
            // 
            label2.Location = new Point(97, 77);
            label2.Size = new Size(220, 38);
            label2.Text = "Listar Categorias";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(44, 224);
            guna2Separator1.Size = new Size(1420, 15);
            // 
            // dtgvCategorias
            // 
            dtgvCategorias.AllowUserToAddRows = false;
            dtgvCategorias.AllowUserToDeleteRows = false;
            dtgvCategorias.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgvCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.RosyBrown;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgvCategorias.ColumnHeadersHeight = 40;
            dtgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvCategorias.Columns.AddRange(new DataGridViewColumn[] { dtgvEditar, dtgvEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgvCategorias.DefaultCellStyle = dataGridViewCellStyle3;
            dtgvCategorias.GridColor = Color.FromArgb(231, 229, 255);
            dtgvCategorias.Location = new Point(44, 245);
            dtgvCategorias.Name = "dtgvCategorias";
            dtgvCategorias.ReadOnly = true;
            dtgvCategorias.RowHeadersVisible = false;
            dtgvCategorias.RowHeadersWidth = 62;
            dtgvCategorias.RowTemplate.Height = 33;
            dtgvCategorias.Size = new Size(1420, 463);
            dtgvCategorias.TabIndex = 5;
            dtgvCategorias.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgvCategorias.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgvCategorias.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgvCategorias.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgvCategorias.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgvCategorias.ThemeStyle.BackColor = Color.White;
            dtgvCategorias.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgvCategorias.ThemeStyle.HeaderStyle.BackColor = Color.RosyBrown;
            dtgvCategorias.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgvCategorias.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvCategorias.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgvCategorias.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvCategorias.ThemeStyle.HeaderStyle.Height = 40;
            dtgvCategorias.ThemeStyle.ReadOnly = true;
            dtgvCategorias.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgvCategorias.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgvCategorias.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvCategorias.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgvCategorias.ThemeStyle.RowsStyle.Height = 33;
            dtgvCategorias.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgvCategorias.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgvCategorias.CellClick += dtgvCategorias_CellClick;
            dtgvCategorias.CellContentClick += guna2DataGridView1_CellContentClick;
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
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            guna2MessageDialog1.Parent = null;
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            guna2MessageDialog1.Text = null;
            // 
            // FrmCategoriasView
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1510, 730);
            Controls.Add(dtgvCategorias);
            Name = "FrmCategoriasView";
            Text = "FrmCategoriasView";
            Load += FrmCategoriasView_Load;
            Controls.SetChildIndex(guna2Separator1, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnAgregar, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(dtgvCategorias, 0);
            ((System.ComponentModel.ISupportInitialize)dtgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgvCategorias;
        private DataGridViewImageColumn dtgvEditar;
        private DataGridViewImageColumn dtgvEliminar;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}