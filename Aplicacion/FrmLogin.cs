using System.Text;
using Aplicacion.Cliente;
using Aplicacion.Socio;
using Aplicacion.Vista_Cliente;
using Entidades;
using Entidades.DB;
using Excepciones;
using Guna.UI2.WinForms;

namespace Aplicacion
{
    public partial class FrmLogin : Form
    {
        #region ATRIBUTOS
        private UsuarioDAO usuarioDAO;
        private FrmMenuSocio frmMenuSocio;
        private bool mostrarClave;
        #endregion

        #region CONSTRUCTOR
        public FrmLogin()
        {
            InitializeComponent();
            this.usuarioDAO = new UsuarioDAO();
            this.mostrarClave = false;
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Me permitira cerrar la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string esCliente;
            try
            {
                if (this.ValidarCampos())
                {
                    bool usuarioValido = this.usuarioDAO.VerificarUsuario(this.txtEmail.Text, this.txtClave.Text, out esCliente);

                    if (!usuarioValido)//-->Valido el ingreso de usuario
                    {
                        throw new IngresoUsuarioException("Usuario ingresado NO valido, reintente!");
                    }

                    if (esCliente == Rol.Socio.ToString())//-->Es Socio abro el menu.
                    {
                        this.Hide();
                        this.frmMenuSocio = new FrmMenuSocio(new Usuario(this.txtEmail.Text, this.txtClave.Text));
                        this.frmMenuSocio.Show();
                    }
                    else if (esCliente == Rol.Cliente.ToString())
                    {
                        Entidades.Cliente cliente = new UsuarioDAO().ObtenerClientePorUsuario(this.txtEmail.Text, this.txtClave.Text);
                        this.Hide();
                        new FrmMenuCliente(cliente).Show();
                    }

                }
            }
            catch (IngresoUsuarioException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message, "Error");
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Algo salio mal!", "Error");
            }
        }

        /// <summary>
        /// Me permitira mostrar la clave sin
        /// ser ocultada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarClave_Click(object sender, EventArgs e)
        {
            if (!this.mostrarClave)
            {
                this.txtClave.PasswordChar = '\0';//-->Para que se muestren los caracteres
                this.mostrarClave = true;
            }
            else
            {
                this.txtClave.PasswordChar = '*';//-->Para NO mostrar los caracteres
                this.mostrarClave = false;
            }
        }

        /// <summary>
        /// Me permitira abrir un formulario
        /// para que un nuevo cliente 
        /// se registre en la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            new FrmRegistrarCliente().ShowDialog();
        }
        #endregion

        #region OTROS EVENTOS
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            if (string.IsNullOrEmpty(this.txtEmail.Text) ||
                string.IsNullOrEmpty(this.txtClave.Text))
            {
                sb.Append("FALTO COMPLETAR ALGUN CAMPO.");
                puede = false;
            }

            //Si no es true debo mostrar un MessageBox
            if (!puede)
            {
                this.guna2MessageDialog1.Show(sb.ToString(), "Error");
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

    }
}