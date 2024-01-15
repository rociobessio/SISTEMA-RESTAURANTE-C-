namespace Aplicacion
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            btnRegistrar = new Button();
            txtClave = new TextBox();
            txtEmail = new TextBox();
            txtNombre = new TextBox();
            cbRol = new ComboBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            lblUsuario = new Label();
            txtDNI = new TextBox();
            cbGenero = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dtpNacimiento = new DateTimePicker();
            label9 = new Label();
            SuspendLayout();
            // 
            // btnRegistrar
            // 
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.Font = new Font("Leelawadee UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.DarkRed;
            btnRegistrar.Location = new Point(831, 290);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(112, 34);
            btnRegistrar.TabIndex = 9;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.BurlyWood;
            txtClave.BorderStyle = BorderStyle.None;
            txtClave.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(31, 212);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese Clave";
            txtClave.Size = new Size(268, 27);
            txtClave.TabIndex = 8;
            txtClave.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.BurlyWood;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(31, 149);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Ingrese Email";
            txtEmail.Size = new Size(268, 27);
            txtEmail.TabIndex = 7;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.BurlyWood;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(31, 82);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ingrese Nombre";
            txtNombre.Size = new Size(268, 27);
            txtNombre.TabIndex = 10;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // cbRol
            // 
            cbRol.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(31, 288);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(268, 36);
            cbRol.TabIndex = 11;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.BurlyWood;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(364, 82);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ingrese Apellido";
            txtApellido.Size = new Size(268, 27);
            txtApellido.TabIndex = 12;
            txtApellido.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.BurlyWood;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(675, 82);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ingrese Telefono";
            txtTelefono.Size = new Size(268, 27);
            txtTelefono.TabIndex = 13;
            txtTelefono.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.BurlyWood;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDireccion.Location = new Point(362, 149);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Ingrese Direccion";
            txtDireccion.Size = new Size(268, 27);
            txtDireccion.TabIndex = 14;
            txtDireccion.TextAlign = HorizontalAlignment.Center;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.Location = new Point(31, 121);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(58, 25);
            lblUsuario.TabIndex = 15;
            lblUsuario.Text = "Email:";
            // 
            // txtDNI
            // 
            txtDNI.BackColor = Color.BurlyWood;
            txtDNI.BorderStyle = BorderStyle.None;
            txtDNI.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDNI.Location = new Point(675, 148);
            txtDNI.Name = "txtDNI";
            txtDNI.PlaceholderText = "Ingrese DNI";
            txtDNI.Size = new Size(268, 27);
            txtDNI.TabIndex = 16;
            txtDNI.TextAlign = HorizontalAlignment.Center;
            // 
            // cbGenero
            // 
            cbGenero.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbGenero.FormattingEnabled = true;
            cbGenero.Location = new Point(675, 212);
            cbGenero.Name = "cbGenero";
            cbGenero.Size = new Size(268, 36);
            cbGenero.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 54);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 18;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(31, 184);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 19;
            label2.Text = "Clave:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(364, 54);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 20;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(675, 54);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 21;
            label4.Text = "Telefono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(364, 121);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 22;
            label5.Text = "Direccion:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(675, 121);
            label6.Name = "label6";
            label6.Size = new Size(47, 25);
            label6.TabIndex = 23;
            label6.Text = "DNI:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(31, 260);
            label7.Name = "label7";
            label7.Size = new Size(42, 25);
            label7.TabIndex = 24;
            label7.Text = "Rol:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(675, 184);
            label8.Name = "label8";
            label8.Size = new Size(73, 25);
            label8.TabIndex = 25;
            label8.Text = "Genero:";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Location = new Point(362, 212);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(270, 31);
            dtpNacimiento.TabIndex = 26;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(364, 184);
            label9.Name = "label9";
            label9.Size = new Size(181, 25);
            label9.TabIndex = 27;
            label9.Text = "Fecha de Nacimiento:";
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(962, 360);
            Controls.Add(label9);
            Controls.Add(dtpNacimiento);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbGenero);
            Controls.Add(txtDNI);
            Controls.Add(lblUsuario);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(cbRol);
            Controls.Add(txtNombre);
            Controls.Add(btnRegistrar);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRegistro";
            Load += FrmRegistro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrar;
        private TextBox txtClave;
        private TextBox txtEmail;
        private TextBox txtNombre;
        private ComboBox cbRol;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Label lblUsuario;
        private TextBox txtDNI;
        private ComboBox cbGenero;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DateTimePicker dtpNacimiento;
        private Label label9;
    }
}