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
    public partial class FrmSampleAdd : Form
    {
        public FrmSampleAdd()
        {
            InitializeComponent();
        }

        #region BOTONES
        /// <summary>
        /// Podre hacer un override
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FrmSampleAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
