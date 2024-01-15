namespace Login
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pictureBox1 = new PictureBox();
            lblUsuario = new Label();
            lblClave = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            lblRegistrarse = new LinkLabel();
            btnIngresar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(423, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(216, 216);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.Location = new Point(261, 288);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(99, 32);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblClave.Location = new Point(261, 357);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(77, 32);
            lblClave.TabIndex = 2;
            lblClave.Text = "Clave:";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.BurlyWood;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(398, 291);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingrese Usuario";
            txtUsuario.Size = new Size(268, 27);
            txtUsuario.TabIndex = 3;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.BurlyWood;
            txtClave.BorderStyle = BorderStyle.None;
            txtClave.Font = new Font("Leelawadee UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(398, 357);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese Clave";
            txtClave.Size = new Size(268, 27);
            txtClave.TabIndex = 4;
            txtClave.TextAlign = HorizontalAlignment.Center;
            // 
            // lblRegistrarse
            // 
            lblRegistrarse.AutoSize = true;
            lblRegistrarse.Location = new Point(398, 414);
            lblRegistrarse.Name = "lblRegistrarse";
            lblRegistrarse.Size = new Size(98, 25);
            lblRegistrarse.TabIndex = 5;
            lblRegistrarse.TabStop = true;
            lblRegistrarse.Text = "Registrarse";
            lblRegistrarse.LinkClicked += lblRegistrarse_LinkClicked;
            // 
            // btnIngresar
            // 
            btnIngresar.FlatStyle = FlatStyle.Popup;
            btnIngresar.Font = new Font("Leelawadee UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.DarkRed;
            btnIngresar.Location = new Point(554, 409);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(112, 34);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1111, 570);
            Controls.Add(btnIngresar);
            Controls.Add(lblRegistrarse);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblUsuario;
        private Label lblClave;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private LinkLabel lblRegistrarse;
        private Button btnIngresar;
    }
}