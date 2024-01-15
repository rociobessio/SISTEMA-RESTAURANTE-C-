using Aplicacion;
using Entidades.DB;
using System.Text;
using Entidades;
using Excepciones;
using Aplicacion.Socio;

namespace Login
{
    public partial class FrmLogin : Form
    {
        #region ATRIBUTOS
        private FrmRegistro _frmRegistro;
        private UsuarioDAO usuarioDAO;
        private FrmPanelControlSocio _frmPanelControlSocio;
        private Usuario _usuarioIngresado;
        #endregion

        #region CONSTRUCTOR
        public FrmLogin()
        {
            InitializeComponent();
            this.usuarioDAO = new UsuarioDAO();//-->Inicializo
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Al presionar click me permitira continuar con la aplicacion
        /// dependiendo de que perfil sea el usuario ingresado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string esCliente;
            try
            {
                if (this.ValidarCampos()){
                    bool usuarioValido = this.usuarioDAO.VerificarUsuario(this.txtUsuario.Text, this.txtClave.Text, out esCliente);

                    if (!usuarioValido)//-->Valido el ingreso de usuario
                    {
                        throw new IngresoUsuarioException("Usuario ingresado NO valido, reintente!");
                    }

                    if (esCliente == Rol.Cliente.ToString())//-->Si es true es CLIENTE
                    {
                        MessageBox.Show("Es CLIENTE", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(esCliente == Rol.Socio.ToString())//-->Es Socio.
                    {
                        MessageBox.Show("ES SOCIO", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._frmPanelControlSocio = new FrmPanelControlSocio(new Usuario(this.txtUsuario.Text,this.txtClave.Text));
                        this._frmPanelControlSocio.Show();
                    }
                    
                }
            }
            catch (IngresoUsuarioException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Me permitira registrar un Empleado de cero,
        /// llevandome a otro formulario de registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._frmRegistro = new FrmRegistro();//-->Instancio el formulario.


            //-->Debo de ir al formulario de registro
            this._frmRegistro.Show();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Valido el ingreso de datos y que no
        /// haya campos vacios.
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            bool puede = true;
            StringBuilder sb = new StringBuilder();
            //Chequeo que complete los campos
            if (string.IsNullOrEmpty(this.txtUsuario.Text) ||
                string.IsNullOrEmpty(this.txtClave.Text))
            {
                sb.Append("FALTO COMPLETAR ALGUN CAMPO.");
                puede = false;
            }

            //Si no es true debo mostrar un MessageBox
            if (!puede)
            {
                MessageBox.Show(sb.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return puede;
        }

        /// <summary>
        /// Me permitira ingresar unicamente numeros
        /// en el control deseado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Chequea que solo se introduzcan letras y el espacio.
        /// Es un validador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}