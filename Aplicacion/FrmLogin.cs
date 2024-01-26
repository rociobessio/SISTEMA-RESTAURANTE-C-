using System.Text;
using Aplicacion.Socio;
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
        #endregion

        #region CONSTRUCTOR
        public FrmLogin()
        {
            InitializeComponent();
            this.usuarioDAO = new UsuarioDAO();
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

                    if (esCliente == Rol.Cliente.ToString())//-->Si es true es CLIENTE
                    {
                        this.guna2MessageDialog1.Show("Es Cliente", "Error");
                        //MessageBox.Show("Es CLIENTE", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (esCliente == Rol.Socio.ToString())//-->Es Socio abro el menu.
                    {
                        //MessageBox.Show("ES SOCIO", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.guna2MessageDialog1.Icon = MessageDialogIcon.None;
                        this.guna2MessageDialog1.Show("Es SOCIO", "OK");
                        this.Hide();
                        this.frmMenuSocio = new FrmMenuSocio(new Usuario(this.txtEmail.Text,this.txtClave.Text));
                        this.frmMenuSocio.Show();
                    }

                }
            }
            catch (IngresoUsuarioException ex)
            {
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.guna2MessageDialog1.Show(ex.Message, "Error");
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Algo salio mal!", "Error");
                //MessageBox.Show("Algo salio mal.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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