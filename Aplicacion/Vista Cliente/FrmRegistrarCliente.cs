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
using Entidades.DB;
using Entidades;
using Excepciones;


namespace Aplicacion.Vista_Cliente
{
    public partial class FrmRegistrarCliente : FrmSampleAdd
    {
        #region ATRIBUTOS
        private Byte[] imagenArray;
        private string pathImagen;
        private Entidades.Cliente cliente;
        #endregion

        #region CONSTRUCTORES
        public FrmRegistrarCliente()
        {
            InitializeComponent();

            foreach (Genero genero in Enum.GetValues(typeof(Genero)))
            {
                this.cbGenero.Items.Add(genero);
            }
            this.cbGenero.SelectedIndex = 0;
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Me permitira buscar la image
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.jpg, *.png)|*.png;*.jpg;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pathImagen = ofd.FileName;
                pcImagenCliente.Image = new Bitmap(this.pathImagen);
            }
        }

        /// <summary>
        /// Me permtiria realizar las validaciones necesarias
        /// para dar de alta a un cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //-->Para la imagen:
                Image tempo = new Bitmap(this.pcImagenCliente.Image);
                MemoryStream memory = new MemoryStream();
                tempo.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                this.imagenArray = memory.ToArray();

                if (this.ValidarInput())
                {
                    if (!new UsuarioDAO().VerificarUsuario(this.txtEmail.Text, this.txtClave.Text))
                    {
                        int idCliente = 0;
                        this.cliente = new Entidades.Cliente(this.txtNombre.Text, this.txtApellido.Text,
                            Enum.Parse<Genero>(this.cbGenero.SelectedItem.ToString()), this.dtpFechaNacimiento.Value,
                            this.txtDNI.Text, this.txtDireccion.Text, this.txtTelefono.Text,
                            new Usuario(this.txtEmail.Text, this.txtClave.Text), 0, false, new Tarjeta());

                        this.cliente.Imagen = this.imagenArray;//-->Asigno la imagen al usuario.

                        if (!new ClienteDAO().AgregarDato(cliente, out idCliente))
                            throw new AgregarDatoSQLException("No se pudo generar el perfil, reintente!");

                        this.MostrarMensajeExito();
                    }
                    else
                        throw new IngresoUsuarioException("Usuario existente, reintente!");
                }
                else
                {
                    this.guna2MessageDialog1.Show("Se deben de ingresar todos los datos.", "Error");
                }
            }
            catch (AgregarDatoSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message, "Error");
            }
            catch (IngresoUsuarioException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message, "Error");
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error al querer generar el perfil.", "Error");
            }
        }
        #endregion

        #region METODOS
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

            if (this.cbGenero.SelectedIndex < 0)
                todoOk = false;

            return todoOk;
        }

        /// <summary>
        /// Me permitira mostrar 
        /// un mesaje de que se ha
        /// generado el perfil correctamente.
        /// </summary>
        private void MostrarMensajeExito()
        {
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.guna2MessageDialog1.Show("El perfil se ha generado correctamente!", "Información");

            this.DialogResult = DialogResult.OK;//-->Todo OK
            this.Close();//-->Cierro el form
        }
        #endregion

        #region OTROS EVENTOS
        private void guna2GroupBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion

    }
}
