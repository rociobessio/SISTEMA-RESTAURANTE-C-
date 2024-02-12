namespace Aplicacion.View
{
    partial class FrmCocina
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
            guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // guna2MessageDialog1
            // 
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = null;
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            guna2MessageDialog1.Parent = null;
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            guna2MessageDialog1.Text = null;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(91, 105);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1546, 1051);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // FrmCocina
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1644, 1231);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCocina";
            Text = "FrmCocina";
            Load += FrmCocina_Load;
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        public FlowLayoutPanel flowLayoutPanel1;
    }
}