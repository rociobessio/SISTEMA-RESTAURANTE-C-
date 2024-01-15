namespace Aplicacion.Socio
{
    partial class FrmControlUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlUsuarios));
            dtgvEmpleados = new DataGridView();
            label1 = new Label();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnRegistrar = new Button();
            btnRefrescar = new Button();
            groupBox1 = new GroupBox();
            btnLimpiar = new Button();
            label11 = new Label();
            cbRol = new ComboBox();
            txtEmail = new TextBox();
            label10 = new Label();
            dtpIngresoEmpleado = new DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            dtpNacimiento = new DateTimePicker();
            cbGenero = new ComboBox();
            label7 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtDNI = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label4 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            lblUsuario = new Label();
            label12 = new Label();
            lblHorarioIngreso = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgvEmpleados).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dtgvEmpleados
            // 
            dtgvEmpleados.AllowUserToAddRows = false;
            dtgvEmpleados.AllowUserToDeleteRows = false;
            dtgvEmpleados.AllowUserToResizeColumns = false;
            dtgvEmpleados.AllowUserToResizeRows = false;
            dtgvEmpleados.Anchor = AnchorStyles.Bottom;
            dtgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgvEmpleados.BackgroundColor = Color.Bisque;
            dtgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEmpleados.GridColor = Color.Tan;
            dtgvEmpleados.Location = new Point(10, 292);
            dtgvEmpleados.Name = "dtgvEmpleados";
            dtgvEmpleados.ReadOnly = true;
            dtgvEmpleados.RowHeadersWidth = 62;
            dtgvEmpleados.RowTemplate.Height = 33;
            dtgvEmpleados.Size = new Size(1120, 223);
            dtgvEmpleados.TabIndex = 13;
            dtgvEmpleados.CellClick += dtgvEmpleados_CellClick;
            dtgvEmpleados.CellContentClick += dtgvEmpleados_CellContentClick;
            dtgvEmpleados.CellContentDoubleClick += dtgvEmpleados_CellContentDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Linen;
            label1.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 254);
            label1.Name = "label1";
            label1.Size = new Size(324, 35);
            label1.TabIndex = 14;
            label1.Text = "Empleados Registrados";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom;
            btnEliminar.BackColor = Color.Tan;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.ButtonHighlight;
            btnEliminar.Image = Properties.Resources.delete_icon;
            btnEliminar.ImageAlign = ContentAlignment.MiddleRight;
            btnEliminar.Location = new Point(551, 521);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(169, 62);
            btnEliminar.TabIndex = 46;
            btnEliminar.Text = "   Eliminar";
            btnEliminar.TextAlign = ContentAlignment.MiddleLeft;
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom;
            btnModificar.BackColor = Color.Tan;
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.FlatStyle = FlatStyle.Popup;
            btnModificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.ForeColor = SystemColors.ButtonHighlight;
            btnModificar.Image = Properties.Resources.modificar_icono;
            btnModificar.ImageAlign = ContentAlignment.MiddleRight;
            btnModificar.Location = new Point(756, 521);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(169, 62);
            btnModificar.TabIndex = 47;
            btnModificar.Text = "   Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleLeft;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom;
            btnRegistrar.BackColor = Color.Tan;
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = SystemColors.ButtonHighlight;
            btnRegistrar.Image = Properties.Resources.agregar_icon1;
            btnRegistrar.ImageAlign = ContentAlignment.MiddleRight;
            btnRegistrar.Location = new Point(961, 521);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(169, 62);
            btnRegistrar.TabIndex = 48;
            btnRegistrar.Text = "   Registrar";
            btnRegistrar.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Bottom;
            btnRefrescar.BackColor = Color.Tan;
            btnRefrescar.Cursor = Cursors.Hand;
            btnRefrescar.FlatStyle = FlatStyle.Popup;
            btnRefrescar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefrescar.ForeColor = SystemColors.ButtonHighlight;
            btnRefrescar.Image = Properties.Resources.refrescar_icono;
            btnRefrescar.ImageAlign = ContentAlignment.MiddleRight;
            btnRefrescar.Location = new Point(361, 521);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(169, 62);
            btnRefrescar.TabIndex = 49;
            btnRefrescar.Text = "   Refrescar";
            btnRefrescar.TextAlign = ContentAlignment.MiddleLeft;
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cbRol);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(dtpIngresoEmpleado);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dtpNacimiento);
            groupBox1.Controls.Add(cbGenero);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtDNI);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1130, 251);
            groupBox1.TabIndex = 50;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Personales";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom;
            btnLimpiar.BackColor = Color.Tan;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatStyle = FlatStyle.Popup;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.ForeColor = SystemColors.ButtonHighlight;
            btnLimpiar.Image = Properties.Resources.limpiar_icono;
            btnLimpiar.ImageAlign = ContentAlignment.MiddleRight;
            btnLimpiar.Location = new Point(955, 142);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(169, 62);
            btnLimpiar.TabIndex = 71;
            btnLimpiar.Text = "   Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(921, 33);
            label11.Name = "label11";
            label11.Size = new Size(41, 25);
            label11.TabIndex = 70;
            label11.Text = "Rol:";
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(974, 30);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(150, 33);
            cbRol.TabIndex = 69;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(693, 173);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(188, 31);
            txtEmail.TabIndex = 68;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(575, 177);
            label10.Name = "label10";
            label10.Size = new Size(58, 25);
            label10.TabIndex = 67;
            label10.Text = "Email:";
            // 
            // dtpIngresoEmpleado
            // 
            dtpIngresoEmpleado.Location = new Point(693, 109);
            dtpIngresoEmpleado.Name = "dtpIngresoEmpleado";
            dtpIngresoEmpleado.Size = new Size(188, 31);
            dtpIngresoEmpleado.TabIndex = 66;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(575, 111);
            label9.Name = "label9";
            label9.Size = new Size(76, 25);
            label9.TabIndex = 65;
            label9.Text = "Ingreso:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(575, 33);
            label8.Name = "label8";
            label8.Size = new Size(106, 25);
            label8.TabIndex = 64;
            label8.Text = "Nacimiento:";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Location = new Point(693, 32);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(188, 31);
            dtpNacimiento.TabIndex = 63;
            // 
            // cbGenero
            // 
            cbGenero.FormattingEnabled = true;
            cbGenero.Location = new Point(370, 174);
            cbGenero.Name = "cbGenero";
            cbGenero.Size = new Size(150, 33);
            cbGenero.TabIndex = 62;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(289, 176);
            label7.Name = "label7";
            label7.Size = new Size(73, 25);
            label7.TabIndex = 61;
            label7.Text = "Género:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(370, 108);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 31);
            txtTelefono.TabIndex = 60;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(282, 114);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 59;
            label6.Text = "Telefono:";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(370, 30);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(150, 31);
            txtDNI.TabIndex = 58;
            txtDNI.TextChanged += txtDNI_TextChanged;
            txtDNI.KeyPress += txtDNI_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(289, 38);
            label5.Name = "label5";
            label5.Size = new Size(47, 25);
            label5.TabIndex = 57;
            label5.Text = "DNI:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(94, 176);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(150, 31);
            txtDireccion.TabIndex = 56;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 182);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 55;
            label4.Text = "Direccion:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(94, 108);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(150, 31);
            txtApellido.TabIndex = 54;
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 114);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 53;
            label3.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(94, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 52;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 44);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 51;
            label2.Text = "Nombre:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Constantia", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(117, 533);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(42, 19);
            lblUsuario.TabIndex = 52;
            lblUsuario.Text = "XXX";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(12, 531);
            label12.Name = "label12";
            label12.Size = new Size(99, 22);
            label12.TabIndex = 51;
            label12.Text = "USUARIO:";
            // 
            // lblHorarioIngreso
            // 
            lblHorarioIngreso.AutoSize = true;
            lblHorarioIngreso.Font = new Font("Constantia", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHorarioIngreso.Location = new Point(197, 567);
            lblHorarioIngreso.Name = "lblHorarioIngreso";
            lblHorarioIngreso.Size = new Size(42, 19);
            lblHorarioIngreso.TabIndex = 54;
            lblHorarioIngreso.Text = "XXX";
            lblHorarioIngreso.Click += lblHorarioIngreso_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Constantia", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(12, 562);
            label13.Name = "label13";
            label13.Size = new Size(179, 22);
            label13.TabIndex = 53;
            label13.Text = "Horario de Ingreso:";
            // 
            // FrmControlUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1142, 595);
            Controls.Add(lblHorarioIngreso);
            Controls.Add(label13);
            Controls.Add(lblUsuario);
            Controls.Add(label12);
            Controls.Add(groupBox1);
            Controls.Add(btnRefrescar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(label1);
            Controls.Add(dtgvEmpleados);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmControlUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control De Usuarios";
            FormClosing += FrmControlUsuarios_FormClosing;
            Load += FrmControlUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvEmpleados).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvEmpleados;
        private Label label1;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnRegistrar;
        private Button btnRefrescar;
        private GroupBox groupBox1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtDNI;
        private Label label5;
        private TextBox txtDireccion;
        private Label label4;
        private TextBox txtApellido;
        private Label label3;
        private TextBox txtTelefono;
        private Label label6;
        private Label label10;
        private DateTimePicker dtpIngresoEmpleado;
        private Label label9;
        private Label label8;
        private DateTimePicker dtpNacimiento;
        private ComboBox cbGenero;
        private Label label7;
        private TextBox txtEmail;
        private Label label11;
        private ComboBox cbRol;
        private Label lblUsuario;
        private Label label12;
        private Label lblHorarioIngreso;
        private Label label13;
        private Button btnLimpiar;
    }
}