using Aplicacion.Socio;
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
using Entidades.DB;
using Excepciones;

namespace Aplicacion.Vista_Cliente
{
    public partial class FrmModCliente : FrmSampleAdd
    {
        #region ATRIBUTOS
        private Byte[] imagenArray;
        private Entidades.Cliente cliente;
        private bool tarjetaCargada;
        #endregion

        #region CONSTRUCTOR
        public FrmModCliente(Entidades.Cliente cliente)
        {
            InitializeComponent();
            this.tarjetaCargada = true;
            this.cliente = cliente;

            #region CARGAR COMBO-BOXES
            foreach (Genero genero in Enum.GetValues(typeof(Genero)))
            {
                this.cbGenero.Items.Add(genero);
            }
            this.cbGenero.SelectedIndex = 0;

            foreach (EntidadesBancarias entidad in Enum.GetValues(typeof(EntidadesBancarias)))
            {
                this.cbEntidad.Items.Add(entidad);
            }
            this.cbEntidad.SelectedIndex = 0;
            #endregion

            this.CargarDatosCliente();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira cargar la informacion del cliente
        /// en los controles del formulario.
        /// </summary>
        private void CargarDatosCliente()
        {
            #region INFORMACION PERSONAL
            this.txtApellido.Text = this.cliente.Apellido;
            this.dtpFechaNacimiento.Value = this.cliente.FechaNacimeinto;
            this.txtDireccion.Text = this.cliente.Direccion;
            this.txtDNI.Text = this.cliente.DNI;
            this.txtNombre.Text = this.cliente.Nombre;
            this.txtTelefono.Text = this.cliente.Telefono;
            #endregion

            #region USUARIO
            this.txtEmail.Text = this.cliente.Usuario.Email;
            this.txtClave.Text = this.cliente.Usuario.Contrasenia;
            this.CargarImagenCliente();
            #endregion

            #region TARJETA
            if (this.cliente.Tarjeta.Titular != "AAAA AAAA")//-->Tarjeta cargada
            {
                this.txtNroCVV.Text = this.cliente.Tarjeta.CVV;
                this.txtNroTarjeta.Text = this.cliente.Tarjeta.NumeroTarjeta;
                this.txtTitular.Text = this.cliente.Tarjeta.Titular;
                this.dtpVencimientoTarjeta.Value = this.cliente.Tarjeta.FechaVencimiento;
            }
            else
                this.tarjetaCargada = false;
            #endregion

        }

        private void CargarImagenCliente()
        {
            try
            {
                if (this.cliente.Imagen != null && this.cliente.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(this.cliente.Imagen))
                    {
                        this.pcImagenCliente.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    this.pcImagenCliente.Image = null;//-->Si no hay imagen que muestre la default
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Algo salio mal al querer mostrar la imagen de usuario!", "Error");
            }
        }

        /// <summary>
        /// Me servira para validar el input
        /// insertado por el usuario.
        /// </summary>
        /// <returns></returns>
        private bool ValidarInput()
        {
            bool todoOk = true;
            DateTime fechaValida = new DateTime(1940, 01, 01);

            if (string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtClave.Text) ||
                string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtDNI.Text) ||
                string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtNombre.Text) ||
                string.IsNullOrEmpty(this.txtTelefono.Text))
                todoOk = false;

            if (this.dtpFechaNacimiento.Value <= fechaValida)
                todoOk = false;

            if (this.cbGenero.SelectedIndex < 0 || this.cbEntidad.SelectedIndex < 0)
                todoOk = false;

            return todoOk;
        }

        #region VALIDACIONES
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtNroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtNroCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }
        #endregion

        #endregion

        #region EVENTOS
        private void FrmModCliente_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region BOTONES
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Al presionar el boton
        /// se realizaran las validaciones necesarias
        /// para poder realizar la modificacion
        /// del perfil.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarInput())
                {
                    //-->Para la imagen:
                    Image tempo = new Bitmap(this.pcImagenCliente.Image);
                    MemoryStream memory = new MemoryStream();
                    tempo.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    this.imagenArray = memory.ToArray();

                    if (this.tarjetaCargada)//-->Cargo la tarjeta nuevamente.
                    {
                        Tarjeta tarjeta = new Tarjeta(this.dtpVencimientoTarjeta.Value, this.txtTitular.Text,
                            this.txtNroCVV.Text, this.txtNroTarjeta.Text, this.cbEntidad.SelectedItem.ToString().Replace("_", " "), true);

                        if (Tarjeta.ValidarTarjeta(tarjeta))
                        {
                            this.cliente.Tarjeta = tarjeta;
                        }
                        else
                            this.guna2MessageDialog1.Show("No se pudo validar la tarjeta!", "Error");
                    }

                    if (!new ClienteDAO().UpdateDato(new Entidades.Cliente(
                        this.cliente.IDCliente, this.txtNombre.Text, this.txtApellido.Text, Enum.Parse<Genero>(this.cbGenero.SelectedItem.ToString()),
                        this.dtpFechaNacimiento.Value, this.txtDNI.Text, this.txtDireccion.Text, this.txtTelefono.Text,
                        new Usuario(this.txtEmail.Text, this.txtClave.Text), 0, true,
                        this.cliente.Tarjeta, this.imagenArray, this.cliente.IDPersona)))
                        throw new UpdateSQLException("No se ha podido modificar el perfil.");

                    this.guna2MessageDialog1.Show("Perfil modificado correctamente!", "Información");

                }
                else { this.guna2MessageDialog1.Show("Ocurrio un error en el ingreso de datos!", "Error"); }
            }
            catch (UpdateSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message, "Error");
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Algo salio mal!", "Error");
            }
        }
        #endregion
    }
}
