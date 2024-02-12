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
    public partial class ucProductoCliente : UserControl
    {
        #region EVENTOS
        public event EventHandler onSelect = null;
        #endregion

        #region ATRIBUTOS
        private int id;
        #endregion

        #region CONSTRUCTOR
        public ucProductoCliente()
        {
            InitializeComponent();
            this.id = 0;
        }

        #endregion

        #region PROPIEDADES
        public int ID { get { return id; } set { this.id = value; } }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get { return this.lblNombreProducto.Text; } set { this.lblNombreProducto.Text = value; } }
        public Image Imagen { get { return this.pcProducto.Image; } set { this.pcProducto.Image = value; } }
        #endregion

        #region EVENTOS
        private void pcProducto_Click(object sender, EventArgs e)
        {
            this.onSelect?.Invoke(this, e);
        }
        #endregion

        private void ucProductoCliente_Click(object sender, EventArgs e)
        {
            this.onSelect?.Invoke(this, e);
            if (!this.btnSelected.Visible)
            {
                this.btnSelected.Visible = true;
            }
            else
            { this.btnSelected.Visible = false;}
        }
    }
}
