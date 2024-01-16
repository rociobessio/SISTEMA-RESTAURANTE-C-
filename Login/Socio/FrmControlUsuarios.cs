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
using Excepciones.DB;
using Login;

namespace Aplicacion.Socio
{
    public partial class FrmControlUsuarios : Form
    {
        #region ATRIBUTOS
        private EmpleadoDAO empleadoDAO;
        private List<Empleado> listaEmpleados;
        private Empleado empleadoSeleccionado;
        private UsuarioDAO usuarioDAO;

        #region DATAGRIDVIEW
        DataTable tablaEmpleados;
        DataRow auxFilaEmpleado;
        int indexTablaEmpleado;
        int idEmpleado;
        #endregion

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto del formulario.
        /// </summary>
        public FrmControlUsuarios()
        {
            InitializeComponent();
            this.tablaEmpleados = new DataTable();//-->Instancio la dataTable.
            this.empleadoDAO = new EmpleadoDAO();//-->Inicializo la conexion
            this.usuarioDAO = new UsuarioDAO();
        }

        /// <summary>
        /// Sobrecarga del constructor del form
        /// que me permitira recibir una instancia
        /// de la clase Usuario.
        /// </summary>
        /// <param name="usuario"></param>
        public FrmControlUsuarios(Usuario usuario)
            : this()
        {
            this.lblHorarioIngreso.Text = DateTime.Now.ToString();
            this.lblUsuario.Text = usuario.Email;

            this.listaEmpleados = this.empleadoDAO.ObtenerTodos();
        }
        #endregion

        #region EVENTOS METODOS
        /// <summary>
        /// En el load se asignara el nombre de las
        /// columnas del datagridview, los combo-boxes
        /// y se cambiara el formato de los datetimepicker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmControlUsuarios_Load(object sender, EventArgs e)
        {
            //-->Cargo las Columnas del DataGridView
            #region CARGA COLUMNAS DATAGRID
            this.tablaEmpleados.Columns.Add("ID", typeof(int));
            this.tablaEmpleados.Columns.Add("Nombre", typeof(string));
            this.tablaEmpleados.Columns.Add("Apellido", typeof(string));
            this.tablaEmpleados.Columns.Add("Telefóno", typeof(string));
            this.tablaEmpleados.Columns.Add("Dirección", typeof(string));
            this.tablaEmpleados.Columns.Add("D.N.I", typeof(string));
            this.tablaEmpleados.Columns.Add("Género");
            this.tablaEmpleados.Columns.Add("Fecha Nacimiento", typeof(DateTime));
            this.tablaEmpleados.Columns.Add("Fecha Incorporación", typeof(DateTime));
            this.tablaEmpleados.Columns.Add("Email", typeof(string));
            this.tablaEmpleados.Columns.Add("Rol");
            #endregion

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

            //-->Modifico el formato de los DateTimePicker.
            this.dtpIngresoEmpleado.CustomFormat = "dd/MM/yyyy";
            this.dtpIngresoEmpleado.Format = DateTimePickerFormat.Custom;
            this.dtpIngresoEmpleado.Enabled = false;

            this.dtpNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpNacimiento.Format = DateTimePickerFormat.Custom;

            //-->Llamo al metodo para Cargar El DataGrid.
            this.CargarEmpleadosDataGrid();
        }

        /// <summary>
        /// Me permitirá cargar los datos de la lista
        /// de empleados en el datagridview.
        /// </summary>
        private void CargarEmpleadosDataGrid()
        {
            this.tablaEmpleados.Rows.Clear();//-->Limpio las filas.

            foreach (Empleado empleado in this.listaEmpleados)
            { 
                this.auxFilaEmpleado = this.tablaEmpleados.NewRow();
                this.auxFilaEmpleado[0] = $"{empleado.IDEmpleado}";
                this.auxFilaEmpleado[1] = $"{empleado.Nombre}";
                this.auxFilaEmpleado[2] = $"{empleado.Apellido}";
                this.auxFilaEmpleado[3] = $"{empleado.Telefono}";
                this.auxFilaEmpleado[4] = $"{empleado.Direccion}";
                this.auxFilaEmpleado[5] = $"{empleado.DNI}";
                this.auxFilaEmpleado[6] = $"{empleado.Genero}";
                this.auxFilaEmpleado[7] = $"{empleado.FechaNacimeinto.ToShortDateString()}";
                this.auxFilaEmpleado[8] = $"{empleado.FechaAlta.ToShortDateString()}";
                this.auxFilaEmpleado[9] = $"{empleado.Usuario.Email}";
                this.auxFilaEmpleado[10] = $"{empleado.Rol}";

                this.tablaEmpleados.Rows.Add(this.auxFilaEmpleado);//-->Añado las Filas 
            }
            this.dtgvEmpleados.DataSource = this.tablaEmpleados;//-->Al dataGrid le paso la lista  
        }

        /// <summary>
        /// Al hacer click en una celda del datagrid
        /// se cargara la informacion en los text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnRegistrar.Enabled = false;//-->Al presionar una celda deshabilito el btnRegistrar.

            this.indexTablaEmpleado = e.RowIndex;//-->Obtengo el indice

            if (this.indexTablaEmpleado > -1)//-->Si es mayor a -1 obtengo el codigo, celda [0]
            {
                this.idEmpleado = int.Parse(this.dtgvEmpleados.Rows[this.indexTablaEmpleado].Cells[0].Value.ToString());//-->Obtengo el codigo
            }

            //-->Recorro la lista de empleados para encontrar al seleccionado e
            //imprimir la informacion en los textboxes.
            foreach (Empleado empleado in this.listaEmpleados)
            {
                if (empleado.IDEmpleado == this.idEmpleado)
                {
                    this.txtNombre.Text = empleado.Nombre;
                    this.txtApellido.Text = empleado.Apellido;
                    this.txtDireccion.Text = empleado.Direccion;
                    this.txtDNI.Text = empleado.DNI;
                    this.txtEmail.Text = empleado.Usuario.Email;
                    this.txtTelefono.Text = empleado.Telefono;
                    this.dtpIngresoEmpleado.Value = empleado.FechaAlta;
                    this.dtpNacimiento.Value = empleado.FechaNacimeinto;
                    this.cbRol.Text = empleado.Rol.ToString();
                    this.cbGenero.Text = empleado.Genero.ToString();
                    this.txtClave.Text = empleado.Usuario.Contrasenia;

                    this.empleadoSeleccionado = empleado;
                    break;
                }
            }
        }

        /// <summary>
        /// Al presionar doble click sobre una 
        /// celda se volvera a activar el boton
        /// de registrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtpIngresoEmpleado.Enabled = false;
            this.btnRegistrar.Enabled = true;
        }

        private void FrmControlUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region VALIDACION INGRESO DATOS
        /// <summary>
        /// Metodo privado del formulario que
        /// me permitira validar el ingreso
        /// de datos.
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos()
        {
            bool ingresoValido = true;
            DateTime fechaValida = new DateTime(1970, 01, 01);

            if (string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtDireccion.Text) ||
                string.IsNullOrEmpty(this.txtDNI.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtNombre.Text) ||
                string.IsNullOrEmpty(this.txtTelefono.Text))
            {
                ingresoValido = false;
            }

            if (this.cbRol.SelectedIndex < 0 || this.cbGenero.SelectedIndex < 0)
            {
                ingresoValido = false;//--->Quiere decir que no selecciono alguna opcion.
            }

            if (this.dtpIngresoEmpleado.Value <= fechaValida || this.dtpNacimiento.Value <= fechaValida)
            {
                ingresoValido = false;//-->Fecha ingresada INVALIDA
            }

            return ingresoValido;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }
        #endregion

        #endregion

        #region BOTONES
        /// <summary>
        /// Me permitira refrescar el datagridview de
        /// empleados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.CargarEmpleadosDataGrid();
        }

        /// <summary>
        /// Me permitira limpiar los 
        /// controles del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Clear();
            this.txtDireccion.Clear();
            this.txtDNI.Clear();
            this.txtEmail.Clear();
            this.txtClave.Clear();
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.dtpNacimiento.ResetText();
            this.dtpIngresoEmpleado.ResetText();
            this.cbGenero.SelectedIndex = 0;
            this.cbRol.SelectedIndex = 0;
        }

        /// <summary>
        /// Me permitira modificar un empleado
        /// en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarDatos() && this.indexTablaEmpleado >= 0)
                {
                    //-->Updateo los valores ingresados
                    this.empleadoSeleccionado.Rol = Enum.Parse<Rol>(this.cbRol.SelectedItem.ToString());
                    this.empleadoSeleccionado.Telefono = this.txtTelefono.Text;
                    this.empleadoSeleccionado.Apellido = this.txtApellido.Text;
                    this.empleadoSeleccionado.Direccion = this.txtDireccion.Text;
                    this.empleadoSeleccionado.DNI = this.txtDNI.Text;
                    this.empleadoSeleccionado.FechaAlta = this.dtpIngresoEmpleado.Value;
                    this.empleadoSeleccionado.FechaNacimeinto = this.dtpNacimiento.Value;
                    this.empleadoSeleccionado.Genero = Enum.Parse<Genero>(this.cbGenero.SelectedItem.ToString()); ;
                    this.empleadoSeleccionado.Nombre = this.txtNombre.Text;
                    this.empleadoSeleccionado.Usuario.Email = this.txtEmail.Text;
                    this.empleadoSeleccionado.Usuario.Contrasenia = this.txtClave.Text;

                    if (!empleadoDAO.UpdateDato(this.empleadoSeleccionado))
                    {
                        throw new SQLUpdateException("No se ha podido modificar al empleado seleccionado, reintente.");
                    }

                    MessageBox.Show("El empleado ha sido modificado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Alguno de los datos ingresado es incorrecto.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SQLUpdateException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Algo inesperado sucedio al intentar modificar al empleado, reintente.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.btnRegistrar.Enabled = true;
            this.CargarEmpleadosDataGrid();
        }

        /// <summary>
        /// Me permitira dar de alta un nuevo Empleado
        /// en la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarDatos())
                {
                    //-->Valido si ya existe el usuario ingresado.
                    if (this.usuarioDAO.VerificarUsuario(this.txtEmail.Text, this.txtClave.Text))
                    {
                        throw new UsuarioExistenteException("El usuario ingresado ya existe, reintente.");
                    }

                    if (!this.empleadoDAO.AgregarDato(new Empleado(Enum.Parse<Rol>(this.cbRol.SelectedItem.ToString()), DateTime.Now,
                        new DateTime(), this.txtNombre.Text, this.txtApellido.Text, this.txtDireccion.Text, this.txtDNI.Text, this.txtTelefono.Text,
                        this.dtpNacimiento.Value, Enum.Parse<Genero>(this.cbGenero.SelectedItem.ToString()),
                        new Usuario(this.txtEmail.Text, this.txtClave.Text))))
                    {
                        throw new SQLAgregarException("No se ha podido añadir al sistema al nuevo empleado.");
                    }

                    MessageBox.Show("El empleado ha sido añadido correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Alguno de los datos ingresado es incorrecto.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UsuarioExistenteException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SQLAgregarException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Algo inesperado sucedio al intentar añadir al empleado, reintente.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.btnRegistrar.Enabled = true;
            this.CargarEmpleadosDataGrid();
        }

        /// <summary>
        /// Me permitira Dar de baja un Empleado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.indexTablaEmpleado >= 0)
                {
                    if (!this.empleadoDAO.DeleteDato(empleadoSeleccionado.IDEmpleado))
                        throw new SQLDeleteException("No se ha podido dar de baja al empleado.");

                    MessageBox.Show("El empleado ha dado de baja al empleado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }else
                    MessageBox.Show("Debe de seleccionar un empleado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(SQLDeleteException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Algo inesperado sucedio al intentar añadir al empleado, reintente.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnRegistrar.Enabled = true;
            this.CargarEmpleadosDataGrid();
        }
        #endregion

        #region EVENTOS
        private void lblHorarioIngreso_Click(object sender, EventArgs e)
        {

        }
        private void dtgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion



    }
}
