using Entidades.DB;
using Excepciones;
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

namespace Aplicacion.Socio
{
    public partial class FrmAgregarEmpleado : FrmSampleAdd
    {
        #region ATRIBUTOS
        private int id;
        private EmpleadoDAO empleadoDAO;
        private UsuarioDAO usuarioDAO;

        #endregion

        #region CONSTRUCTORES
        public FrmAgregarEmpleado()
        {
            InitializeComponent();
            this.id = 0;
            this.empleadoDAO = new EmpleadoDAO();
            this.usuarioDAO = new UsuarioDAO();

        }

        public FrmAgregarEmpleado(Empleado empleado)
            : this()
        {
            this.id = empleado.IDEmpleado;

            this.txtClave.Enabled = false;//-->La clave no se modificara, por ahora.
            this.label1.Text = "Modificar Empleado";//-->Cambio el titulo

            //-->Cargo los datos en los controles
            this.CargarDatosControles(empleado);
        }

        #endregion

        #region VALIDACIONES
        /// <summary>
        /// Me permtira chequear el ingreso
        /// de datos por parte del usuario.
        /// </summary>
        /// <returns></returns>
        private bool ValidarIngresoDatos()
        {
            bool validacionCorrecta = true;
            DateTime fechaValida = new DateTime(1970, 01, 01);

            if (string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtClave.Text)
                || string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtDNI.Text)
                || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtNombre.Text)
                || string.IsNullOrEmpty(this.txtTelefono.Text))
                validacionCorrecta = false;

            if (this.cbGenero.SelectedIndex < 0 || this.cbRol.SelectedIndex < 0)
                validacionCorrecta = false;

            if (this.dtpFechaNacimiento.Value <= fechaValida || this.dtpFechaNacimiento.Value > DateTime.Now)
                validacionCorrecta = false;

            return validacionCorrecta;
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

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }
        #endregion

        #region EVENTOS
        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            #region CARGA COMBO-BOXES
            foreach (Genero genero in Enum.GetValues(typeof(Genero)))
            {
                this.cbGenero.Items.Add(genero);
            }
            foreach (Rol rol in Enum.GetValues(typeof(Rol)))
            {
                this.cbRol.Items.Add(rol);
            }
            #endregion

            //-->Modifico DateTimePicker
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            //this.dtpIngresoEmpleado.Enabled = false;
        }
        #endregion

        #region METODO
        /// <summary>
        /// Me permitira imprimir los valores
        /// del empleado correspondiente en los
        /// controles del formulario.
        /// </summary>
        /// <param name="empleado"></param>
        private void CargarDatosControles(Empleado empleado)
        {

            this.txtApellido.Text = empleado.Apellido;
            this.txtClave.Text = empleado.Usuario.Contrasenia;
            this.txtDireccion.Text = empleado.Direccion;
            this.txtDNI.Text = empleado.DNI;
            this.txtEmail.Text = empleado.Usuario.Email;
            this.txtTelefono.Text = empleado.Telefono;
            this.txtNombre.Text = empleado.Nombre;
            this.dtpFechaNacimiento.Value = empleado.FechaNacimeinto.Date;
            //-->Cambiar
            this.cbGenero.SelectedItem = 0;
            this.cbRol.SelectedItem = 0;
        }
        #endregion

        #region BOTONES
        public override void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.id > 0)//-->Se modifica
            {
                try
                {
                    if (this.ValidarIngresoDatos())//-->Valido el ingreso de datos.
                    {
                        if (!this.empleadoDAO.UpdateDato(new Empleado(this.id, Enum.Parse<Rol>(this.cbRol.SelectedItem.ToString()), DateTime.Now,
                             this.txtNombre.Text, this.txtApellido.Text, this.txtDireccion.Text, this.txtDNI.Text, this.txtTelefono.Text,
                            this.dtpFechaNacimiento.Value, Enum.Parse<Genero>(this.cbGenero.SelectedItem.ToString()), new Usuario(this.txtEmail.Text, this.txtClave.Text))))
                            throw new UpdateSQLException("No se ha podido modificar al empleado, reintente!");

                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Show("Se ha modificado al empleado correctamente!", "Información");

                        this.DialogResult = DialogResult.OK;//-->Todo OK
                        this.Close();//-->Cierro el form
                    }
                    else
                        this.guna2MessageDialog1.Show("Error en el ingreso de datos, verifique.", "Error");
                }
                catch (UpdateSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer modificar al empleado.", "Error");
                }
            }
            else//-->Alta de Empleado.
            {
                try
                {
                    if (this.ValidarIngresoDatos())//-->Valido el ingreso De Datos.
                    {
                        if (this.usuarioDAO.VerificarUsuario(this.txtEmail.Text, this.txtClave.Text))
                            throw new IngresoUsuarioException("El usuario generado ya existe, pruebe con otro.");

                        if (!this.empleadoDAO.AgregarDato(new Empleado(Enum.Parse<Rol>(this.cbRol.SelectedItem.ToString()), DateTime.Now,
                             this.txtNombre.Text, this.txtApellido.Text, this.txtDireccion.Text, this.txtDNI.Text, this.txtTelefono.Text,
                            this.dtpFechaNacimiento.Value, Enum.Parse<Genero>(this.cbGenero.SelectedItem.ToString()), new Usuario(this.txtEmail.Text, this.txtClave.Text))))
                            throw new AgregarDatoSQLException("No se ha podido guardar al nuevo empleado, reintente!");

                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Show("Se ha guardado al empleado correctamente!", "Información");

                        this.DialogResult = DialogResult.OK;//-->Todo OK
                        this.Close();//-->Cierro el form
                    }
                    else
                        this.guna2MessageDialog1.Show("Todos los datos deben de ser ingresados para generar el alta.", "Error");
                }
                catch (IngresoUsuarioException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (AgregarDatoSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer agregar al nuevo empleado.", "Error");
                }
            }
        }
        #endregion
    }
}
