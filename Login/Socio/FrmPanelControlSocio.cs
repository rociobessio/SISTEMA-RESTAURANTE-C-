using Entidades;
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
    public partial class FrmPanelControlSocio : Form
    {
        #region ATRIBUTOS
        private FrmControlUsuarios frmControlUsuarios;
        #endregion

        #region CONSTRUCTORES
        public FrmPanelControlSocio()
        {
            InitializeComponent();
        }

        public FrmPanelControlSocio(Usuario usuario)
            : this()
        {
            this.lblUsuario.Text = usuario.Email;
            this.lblHorarioIngreso.Text = DateTime.Now.ToString();


            this.frmControlUsuarios = new FrmControlUsuarios(usuario);
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Me permitira ir al control
        /// de Usuarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.frmControlUsuarios.ShowDialog();
        }
        #endregion
    }
}
