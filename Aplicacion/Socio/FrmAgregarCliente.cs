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
    public partial class FrmAgregarCliente : Form
    {
        #region ATRIBUTOS
        public string codigoPedido;
        private string tipoOrden;
        private List<Empleado> listaEmpleados;
        public int _idConductor;
        public string nombreCliente;
        #endregion

        #region CONSTRUCTOR
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        public FrmAgregarCliente(string tipoOrden)
            : this()
        {
            this.tipoOrden = tipoOrden;
        }
        #endregion

        #region OTRO
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbConductor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region EVENTOS
        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            //-->Obtengo los conductores
            this.listaEmpleados = new EmpleadoDAO().ObtenerEmpleadoPorRol(Rol.Conductor.ToString());


            if (this.tipoOrden == TiposPedidos.Para_Llevar.ToString().Replace("_", " "))
            {
                this.lblConductor.Visible = false;
                this.cbConductor.Visible = false;
            }

            //-->Cargo a los conductores por nombre.
            foreach (Empleado empleado in this.listaEmpleados)
            {
                this.cbConductor.Items.Add(empleado.Nombre + " " + empleado.Apellido);
            }
        }


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (this.ValidarInput())
            {
                this._idConductor = Convert.ToInt32(this.cbConductor.SelectedValue);
            }
            else
            { 
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Se deben de ingresar TODOS los datos!");
            }
        }
        #endregion

        #region VALIDACIONES
        /// <summary>
        /// Me permitira validar si
        /// todos los input estan llenos
        /// </summary>
        /// <returns></returns>
        private bool ValidarInput()
        {

            if (string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtCiudad.Text) ||
                string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtNombre.Text) ||
                string.IsNullOrEmpty(this.txtTelefono.Text))
                return false;
            else
                return true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }
        #endregion
    }
}
