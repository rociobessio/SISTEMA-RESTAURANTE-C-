using Entidades.DB;
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

namespace Aplicacion.Selection
{
    public partial class FrmElegirMozo : Form
    {
        #region ATRIBUTOS
        private List<Empleado> listaMozos;
        public string nombreMozo;
        #endregion

        #region CONSTRUCTOR
        public FrmElegirMozo()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTOS
        private void FrmElegirMozo_Load(object sender, EventArgs e)
        {
            this.listaMozos = new EmpleadoDAO().ObtenerEmpleadoPorRol(Rol.Mozo.ToString());//-->Obtengo los Mozos


            //-->Cargo los botones con las mesas:
            foreach (Empleado mozo in this.listaMozos)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = mozo.Nombre.ToString();//-->Le asigno el Nombre del Mozo
                b.Width = 150;
                b.Height = 50;
                b.FillColor = Color.RosyBrown;
                b.HoverState.FillColor = Color.IndianRed;

                //-->Adjunto el EVENTO
                b.Click += new EventHandler(b_Click);

                //-->Muestro
                this.flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void b_Click(object? sender, EventArgs e)
        {
            this.nombreMozo = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();//-->Cierro una vez que tengo el ID/Nombre
        }
        #endregion
    }
}
