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
using Entidades.DB;


namespace Aplicacion.Socio
{
    public partial class FrmElegirMesa : Form
    {
        #region ATRIBUTOS
        private List<Mesa> listaMesasDisponibles;
        private DataTable tabla;
        public string nombreTabla;
        #endregion

        #region CONSTRUCTOR
        public FrmElegirMesa()
        {
            InitializeComponent();
            this.tabla = new DataTable();
        }
        #endregion

        #region EVENTOS
        private void FrmElegirMesa_Load(object sender, EventArgs e)
        {
            this.listaMesasDisponibles = new MesaDAO().ObtenerMesasPorEstado(Estados.Cerrada.ToString());


            //-->Cargo los botones con las mesas:
            foreach (Mesa mesa in this.listaMesasDisponibles)
            {
                if (mesa.Estado != Estados.Cerrada.ToString())//-->Se podra seleccionar si la mesa no esta en uso.
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.Text = mesa.IDMesa.ToString();//-->Le asigno el ID de la Mesa
                    b.Width = 510;
                    b.Height = 50;
                    b.FillColor = Color.RosyBrown;
                    b.HoverState.FillColor = Color.IndianRed;

                    //-->Adjunto el EVENTO
                    b.Click += new EventHandler(b_Click);
                    //-->Muestro
                    this.flowLayoutPanel1.Controls.Add(b);
                }
            }
        }

        private void b_Click(object? sender, EventArgs e)
        {
            this.nombreTabla = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();//-->Cierro una vez que tengo el ID/Nombre
        }
        #endregion
    }
}
