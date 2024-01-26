﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Socio
{
    public partial class FrmMenuSocio : Form
    {
        #region ATRIBUTOS

        #endregion

        #region CONSTRUCTOR
        public FrmMenuSocio()
        {
            InitializeComponent();
        }

        public FrmMenuSocio(Usuario usuario)
            : this()
        {
            this.lblUsuario.Text = usuario.Email;
        }
        #endregion


        #region EVENTOS
        private void FrmMenuSocio_Load(object sender, EventArgs e)
        {

        }

        #region BOTONES

        /// <summary>
        /// BOTON HOME!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //-->BOTON HOME
            this.AgregarControles(new FrmHome());
        }

        /// <summary>
        /// Me permitira cerrar la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #endregion

        #region METODOS
        public void AgregarControles(Form form)
        {
            try
            {
                CenterPanel.Controls.Clear();
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                CenterPanel.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar el form");
                //Console.WriteLine("Error al agregar el formulario: " + ex.Message);
            }
        }

        #endregion

        #region OTROS EVENTOS
        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}