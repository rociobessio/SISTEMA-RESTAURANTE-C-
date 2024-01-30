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
    public partial class FrmProductosView : FrmSampleListar
    {
        #region ATRIBUTOS
        private ProductoDAO productoDAO;
        private List<Producto> listaProductos;
        private FrmAgregarProducto frmAgregarProducto;

        #region DATAGRID
        private DataTable tablaProductos;
        private DataRow auxFila = null;
        #endregion
        #endregion

        #region CONSTRUCTOR
        public FrmProductosView()
        {
            InitializeComponent();
            this.productoDAO = new ProductoDAO();
            this.listaProductos = new List<Producto>();
            this.tablaProductos = new DataTable();
        }
        #endregion

        #region OTROS EVENTOS
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region EVENTOS

        private void dtgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dtgvProductos.Columns["dtgvEditar"].Index && e.RowIndex >= 0)
                {
                    int idProducto = Convert.ToInt32(this.dtgvProductos.CurrentRow.Cells["ID"].Value);//-->Obtengo el ID

                    //-->Busco al producto para pasarlo
                    Producto producto = this.productoDAO.ObtenerEspecifico(idProducto);

                    //-->Abro el form para modificarlo
                    FrmAgregarProducto frmEditarProducto = new FrmAgregarProducto(producto);
                    frmEditarProducto.ShowDialog();

                    //--->Actualizo el dtgv
                    if (frmEditarProducto.DialogResult == DialogResult.OK)
                    {
                        this.CargarProductosDataGrid();//-->Recargo del dtgv
                    }
                }
                else if (e.ColumnIndex == this.dtgvProductos.Columns["dtgvEliminar"].Index && e.RowIndex >= 0)
                {
                    try
                    {
                        //-->Pregunto si desea eliminar:
                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                        this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                        if (this.guna2MessageDialog1.Show("Desea dar de baja el producto?", "Cuidado") == DialogResult.Yes)
                        {
                            int idProducto = Convert.ToInt32(this.dtgvProductos.CurrentRow.Cells["ID"].Value);//-->Obtengo el ID

                            if (!this.productoDAO.DeleteDato(idProducto))
                                throw new EliminarSQLException("No se ha podido dar de baja el producto, reintente!");

                            //-->Modifico el mensaje de Texto
                            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                            this.guna2MessageDialog1.Show("Se ha dado de baja el producto correctamente!", "Información");

                            this.CargarProductosDataGrid();//-->Actualizo el datagridView
                        }
                    }
                    catch (EliminarSQLException ex)
                    {
                        this.guna2MessageDialog1.Show(ex.Message, "Error");
                    }
                    catch (Exception)
                    {
                        this.guna2MessageDialog1.Show("Ocurrio un error al intentar dar de baja al producto.", "Error");
                    }
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error.", "Error");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.frmAgregarProducto = new FrmAgregarProducto();
            this.frmAgregarProducto.ShowDialog();
            this.CargarProductosDataGrid();//-->Recargo el datagridview
        }

        private void FrmProductosView_Load(object sender, EventArgs e)
        {
            #region CREO COLUMNAS DTGV
            this.tablaProductos.Columns.Add("ID", typeof(int));
            this.tablaProductos.Columns.Add("Nombre", typeof(string));
            this.tablaProductos.Columns.Add("Sector", typeof(Sectores));
            this.tablaProductos.Columns.Add("Precio", typeof(double));
            this.tablaProductos.Columns.Add("Tipo", typeof(Tipo));
            this.tablaProductos.Columns.Add("Tiempo Estimado Preparación", typeof(TimeSpan));
            this.tablaProductos.Columns.Add("Categoria", typeof(int));
            #endregion

            //-->Cargo el datagridview
            this.CargarProductosDataGrid();
        }
        #endregion

        #region METODOS
        private void CargarProductosDataGrid()
        {
            this.listaProductos = productoDAO.ObtenerTodos();

            this.tablaProductos.Rows.Clear();//-->Limpio las filas.

            foreach (Producto producto in this.listaProductos)
            {
                this.auxFila = this.tablaProductos.NewRow();
                this.auxFila[0] = producto.IDProducto;
                this.auxFila[1] = producto.Nombre;
                this.auxFila[2] = producto.Sector;
                this.auxFila[3] = producto.Precio;
                this.auxFila[4] = producto.Tipo;
                this.auxFila[5] = producto.TiempoEstimadoPreparacion;
                this.auxFila[6] = producto.Categoria;
                //this.auxFila[7] = empleado.Rol;//-->IMAGEN


                this.tablaProductos.Rows.Add(this.auxFila);//-->Añado las Filas 
            }
            this.dtgvProductos.DataSource = this.tablaProductos;//-->Al dataGrid le paso la lista  
        }
        #endregion



    }
}
