using Aplicacion.Samples;
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
using Aplicacion.Socio;
using System.Data.SqlClient;
using Excepciones;

namespace Aplicacion.View
{
    public partial class FrmCategoriasView : FrmSampleListar
    {
        #region ATRIBUTOS
        private CategoriasDAO categoriasDAO;
        private FrmAgregarCategoria frmAgregarCategoria;
        List<Tuple<int, string>> listaCategorias = new List<Tuple<int, string>>();

        #region DATAGRIDVIEW
        DataTable tablaCategorias;
        DataRow auxFilaCategoria;
        #endregion
        #endregion

        #region CONSTRUCTOR
        public FrmCategoriasView()
        {
            InitializeComponent();
            this.tablaCategorias = new DataTable();
            this.categoriasDAO = new CategoriasDAO();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira cargar las filas
        /// de las categorias.
        /// </summary>
        private void CargarCategoriasDataGrid()
        {
            this.listaCategorias = categoriasDAO.ObtenerTodos();

            this.tablaCategorias.Rows.Clear();//-->Limpio las filas.

            foreach (var categoria in this.listaCategorias)
            {
                this.auxFilaCategoria = this.tablaCategorias.NewRow();
                this.auxFilaCategoria[0] = categoria.Item1; // ID
                this.auxFilaCategoria[1] = categoria.Item2; // Nombre de la categoría

                this.tablaCategorias.Rows.Add(this.auxFilaCategoria);//-->Añado las Filas 
            }
            this.dtgvCategorias.DataSource = this.tablaCategorias;//-->Al dataGrid le paso la lista  
        }
        #endregion

        #region EVENTOS
        private void FrmCategoriasView_Load(object sender, EventArgs e)
        {
            this.tablaCategorias.Columns.Add("ID", typeof(int));
            this.tablaCategorias.Columns.Add("Categoria", typeof(string));

            this.CargarCategoriasDataGrid();
        }

        /// <summary>
        /// Al presionarlo me abrira el formulario para 
        /// añadir una nueva categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.frmAgregarCategoria = new FrmAgregarCategoria();
            this.frmAgregarCategoria.ShowDialog();
            this.CargarCategoriasDataGrid();
        }

        public override void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }


        private void dtgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //-->Veo sobre donde clickeo
            if (e.ColumnIndex == dtgvCategorias.Columns["dtgvEditar"].Index && e.RowIndex >= 0)
            {
                //-->Obtengo el ID de la categoria
                int idCategoria = Convert.ToInt32(dtgvCategorias.CurrentRow.Cells["ID"].Value);

                //-->Obtengo el nombre de la categoria
                string nombreCategoria = dtgvCategorias.CurrentRow.Cells["Categoria"].Value.ToString();

                //-->Abro el form para modificarlo
                FrmAgregarCategoria frmEditarCategoria = new FrmAgregarCategoria(idCategoria, nombreCategoria);
                frmEditarCategoria.ShowDialog();

                //--->Actualizo el dtgv
                if (frmEditarCategoria.DialogResult == DialogResult.OK)
                {
                    this.CargarCategoriasDataGrid();//-->Recargo del dtgv
                }
            }
            else if (e.ColumnIndex == dtgvCategorias.Columns["dtgvEliminar"].Index && e.RowIndex >= 0)//-->Para eliminar
            {
                try
                {
                    //-->Pregunto si desea eliminar:
                    this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                    this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                    if (this.guna2MessageDialog1.Show("Desea eliminar la categoria?", "Información") == DialogResult.Yes)
                    {
                        int idCategoria = Convert.ToInt32(dtgvCategorias.CurrentRow.Cells["ID"].Value);//-->Obtengo ID

                        if (!this.categoriasDAO.EliminarDato(idCategoria))//-->Lanzo una exception de que no pudo eliminar.
                            throw new EliminarSQLException("No se ha podido eliminar la categoria, reintente!");

                        //-->Modifico el mensaje de Texto
                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Show("Se ha eliminado la categoria correctamente!", "Información");

                        this.CargarCategoriasDataGrid();//-->Actualizo el datagridView
                    }
                }
                catch (EliminarSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Algo inesperado sucedio! Reintente.", "Error");
                }
            }
        }
        #endregion

        #region OTROS EVENTOS
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
