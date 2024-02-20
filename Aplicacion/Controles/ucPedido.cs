using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Controles
{
    public partial class ucPedido : UserControl
    {
        #region ATRIBUTOS

        #endregion

        #region PROPIEDADES
        public string Total
        {
            get { return (this.lblTotal.Text); }
            set { this.lblTotal.Text = value; }
        }
        public string CodigoPedido { get { return this.lblCodPedido.Text; } set { this.lblCodPedido.Text = value; } }
        public string FechaPedido { get { return this.lblDiaPedido.Text; } set { this.lblDiaPedido.Text = value; } }
        public string Estado { get { return this.lblEstado.Text; } set { this.lblEstado.Text = value; } }
        #endregion

        #region CONTRUCTORES
        public ucPedido()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTOS
        public event EventHandler onSelect = null;

        private void ucPedido_Click(object sender, EventArgs e)
        {
            this.onSelect?.Invoke(this, e);
        }
        #endregion

        #region OTROS
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
