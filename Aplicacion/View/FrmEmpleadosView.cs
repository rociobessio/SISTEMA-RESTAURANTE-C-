using Aplicacion.Samples;
using Aplicacion.Socio;
using Entidades;
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

namespace Aplicacion.View
{
    public partial class FrmEmpleadosView : FrmSampleListar
    {
        #region ATRIBUTOS
        private EmpleadoDAO empleadoDAO;
        private List<Empleado> listaEmpleados;
        private FrmAgregarEmpleado frmAgregarEmpleado;

        #region DATAGRID
        private DataTable tablaEmpleados;
        private DataRow auxFila;
        #endregion
        #endregion

        #region CONSTRUCTOR
        public FrmEmpleadosView()
        {
            InitializeComponent();
            this.empleadoDAO = new EmpleadoDAO();
            this.listaEmpleados = new List<Empleado>();
            this.tablaEmpleados = new DataTable();

            this.dtgvEmpleados.RowPrePaint += this.dtgvEmpleados_RowPrePaint;
        }
        #endregion

        #region EVENTOS
        private void FrmEmpleadosView_Load(object sender, EventArgs e)
        {
            #region CREO COLUMNAS DTGV
            this.tablaEmpleados.Columns.Add("ID", typeof(int));
            this.tablaEmpleados.Columns.Add("Nombre", typeof(string));
            this.tablaEmpleados.Columns.Add("Apellido", typeof(string));
            this.tablaEmpleados.Columns.Add("Direccion", typeof(string));
            this.tablaEmpleados.Columns.Add("Telefono", typeof(string));
            this.tablaEmpleados.Columns.Add("DNI", typeof(string));
            this.tablaEmpleados.Columns.Add("E-Mail", typeof(string));
            this.tablaEmpleados.Columns.Add("Rol", typeof(Rol));
            this.tablaEmpleados.Columns.Add("Fecha Alta", typeof(DateTime));
            this.tablaEmpleados.Columns.Add("Fecha Baja",typeof(DateTime));
            #endregion

            this.CargarEmpleadosDataGrid();//-->Cargo los empleados en el dataGridView
        }

        /// <summary>
        /// Me permitira abrir el formulario 
        /// para poder dar de alta un nuevo Empleado
        /// y guardarlo en la tabla correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.frmAgregarEmpleado = new FrmAgregarEmpleado();
            this.frmAgregarEmpleado.ShowDialog();
            this.CargarEmpleadosDataGrid();//-->Vuelvo a cargar el dtgv actualizado.
        }

        /// <summary>
        /// Evento para poder pintar aquellas
        /// filas en las cuales el empleado
        /// haya sido dado de baja.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvEmpleados_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //-->Obtengo la fila actual
            DataGridViewRow row = dtgvEmpleados.Rows[e.RowIndex];
            object fechaBajaCellValue = row.Cells["Fecha Baja"].Value;

            //-->Compruebo
            if (fechaBajaCellValue is DateTime fechaBaja && fechaBaja > DateTime.MinValue)
            {
                //-->Cambio el color de la fila.
                row.DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
        }
    #endregion

    #region METODOS
    /// <summary>
    /// Me permitira cargar los empleados al datagridview
    /// </summary>
    private void CargarEmpleadosDataGrid()
        {
            this.listaEmpleados = empleadoDAO.ObtenerTodos();

            this.tablaEmpleados.Rows.Clear();//-->Limpio las filas.

            foreach (Empleado empleado in this.listaEmpleados)
            {
                this.auxFila = this.tablaEmpleados.NewRow();
                this.auxFila[0] = empleado.IDEmpleado;
                this.auxFila[1] = empleado.Nombre;
                this.auxFila[2] = empleado.Apellido;
                this.auxFila[3] = empleado.Direccion;
                this.auxFila[4] = empleado.Telefono;
                this.auxFila[5] = empleado.DNI;
                this.auxFila[6] = empleado.Usuario.Email;
                this.auxFila[7] = empleado.Rol;
                this.auxFila[8] = empleado.FechaAlta;
                this.auxFila[9] = empleado.FechaBaja;// == null ? "INACTIVO" : "ACTIVO";


                this.tablaEmpleados.Rows.Add(this.auxFila);//-->Añado las Filas 
            }
            this.dtgvEmpleados.DataSource = this.tablaEmpleados;//-->Al dataGrid le paso la lista  
        }

        private void dtgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dtgvEmpleados.Columns["dtgvEditar"].Index && e.RowIndex >= 0)
                {
                    int idEmpleado = Convert.ToInt32(this.dtgvEmpleados.CurrentRow.Cells["ID"].Value);//-->Obtengo el ID

                    //-->Busco al empleado para pasarlo
                    Empleado empleado = this.empleadoDAO.ObtenerEspecifico(idEmpleado);

                    //-->Abro el form para modificarlo
                    FrmAgregarEmpleado frmEditarEmpleado = new FrmAgregarEmpleado(empleado);
                    frmEditarEmpleado.ShowDialog();

                    //--->Actualizo el dtgv
                    if (frmEditarEmpleado.DialogResult == DialogResult.OK)
                    {
                        this.CargarEmpleadosDataGrid();//-->Recargo del dtgv
                    }
                }
                else if(e.ColumnIndex == this.dtgvEmpleados.Columns["dtgvEliminar"].Index && e.RowIndex >= 0)//-->Una BAJA LOGICA
                {
                    try
                    {
                        //-->Pregunto si desea eliminar:
                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                        this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                        if (this.guna2MessageDialog1.Show("Desea dar de baja al empleado?","Cuidado") == DialogResult.Yes)
                        {
                            int idEmpleado = Convert.ToInt32(this.dtgvEmpleados.CurrentRow.Cells["ID"].Value);//-->Obtengo el ID

                            if (!this.empleadoDAO.DeleteDato(idEmpleado))
                                throw new EliminarSQLException("No se ha podido dar de baja al empleado, reintente!");

                            //-->Modifico el mensaje de Texto
                            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                            this.guna2MessageDialog1.Show("Se ha dado de baja al empleado    correctamente!", "Información");

                            this.CargarEmpleadosDataGrid();//-->Actualizo el datagridView
                        }
                    }
                    catch (EliminarSQLException ex)
                    {
                        this.guna2MessageDialog1.Show(ex.Message, "Error");
                    }
                    catch (Exception)
                    {
                        this.guna2MessageDialog1.Show("Ocurrio un error al intentar eliminar.", "Error");
                    }
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error.", "Error");
            }
        }
        #endregion



    }
}
