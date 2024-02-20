using Aplicacion.Cliente;
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
    public partial class ucPago : UserControl
    {
        #region ATRIBUTOS
        private int id;
        #endregion

        #region EVENTOS
        public event EventHandler EliminarProductoClick;
        #endregion

        public ucPago()
        {
            InitializeComponent();
            this.id = 0;
            this.numericUpDownCantidad.Minimum = 1;
            pictureBoxEliminar.Click += pictureBoxEliminar_Click;
        }

        public int Cantidad
        {
            get { return Convert.ToInt32(this.numericUpDownCantidad.Value); }
            set { this.numericUpDownCantidad.Value = value; }
        }
        public int ID { get { return id; } set { this.id = value; } }
        public string Precio { get { return this.lblPrecio.Text; } set { this.lblPrecio.Text = value; } }
        public string Categoria { get { return this.lblCategoria.Text; } set { this.lblCategoria.Text = value; } }

        public string Nombre { get { return this.lblNombreProducto.Text; } set { this.lblNombreProducto.Text = value; } }


        private void pictureBoxEliminar_Click(object sender, EventArgs e)
        {
            EliminarProductoClick?.Invoke(this, EventArgs.Empty);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ucPago_Load(object sender, EventArgs e)
        {

        }
    }
}
