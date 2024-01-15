using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Controllers;

namespace Aplicacion
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();

            //-->Debo de cargar el ComboBox
        }

        #region EVENTOS
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //-->Al hacer click deberia de ver si el usuario esta o no registrado
            if (this.PudoValidar())
            {
                //-->Llamo al controller que valide si no existe el cliente.
                //Solo se podrá dar de alta en el login Clientes, los empleados los dará de alta SOLO el socio.
            }
            else
            {
                MessageBox.Show("Datos ingresados NO VALIDOS.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            //-->Cargo los Combobox
            foreach (Genero genero in Enum.GetValues(typeof(Genero)))
            {
                this.cbGenero.Items.Add(genero);
            }
            foreach (Rol rol in Enum.GetValues(typeof(Rol)))
            {
                this.cbRol.Items.Add(rol);
            }
            //-->Fecha Nacimiento
            this.dtpNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpNacimiento.Format = DateTimePickerFormat.Custom;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira validar el ingreso de datos.
        /// </summary>
        /// <returns>true si los datos son validos, false caso contrario.</returns>
        private bool PudoValidar()
        {
            bool validar = true;

            if (this.cbGenero.SelectedIndex < 0 || this.cbRol.SelectedIndex < 0)
            {
                validar = false;//--->Quiere decir que no selecciono alguna opcion.
            }

            //-->Valido que no ingrese una fecha invalida.
            if (this.dtpNacimiento.Value <= DateTime.Now)
            {
                validar = false;//-->Nacimiento NO valido
            }

            if(string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtClave.Text) ||
                string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtDNI.Text) ||
                string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtNombre.Text) ||
                string.IsNullOrEmpty(this.txtTelefono.Text))
            {
                validar = false;//--->Falto completar algun dato.
            }
            return validar;
        }
        #endregion
    }
}
