using Aplicacion.Samples;
using Entidades.DB;
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
using Aplicacion.Socio;
using Excepciones;

namespace Aplicacion.View
{
    public partial class FrmMesasView : FrmSampleListar
    {
        #region ATRIBUTOS
        private MesaDAO mesaDAO;
        private FrmAgregarMesa frmAgregarMesa;
        private List<Mesa> listaMesas;

        #region DATAGRID
        private DataTable tablaMesas;
        private DataRow auxFila;
        #endregion
        #endregion

        #region CONSTRUCTOR
        public FrmMesasView()
        {
            InitializeComponent();
            this.tablaMesas = new DataTable();
            this.mesaDAO = new MesaDAO();
            this.frmAgregarMesa = new FrmAgregarMesa();
        }
        #endregion

        
        #region METODOS
        private void CargarMesasDataGrid()
        {
            this.listaMesas = mesaDAO.ObtenerTodos();

            this.tablaMesas.Rows.Clear();//-->Limpio las filas.

            foreach (Mesa mesa in this.listaMesas)
            {
                this.auxFila = this.tablaMesas.NewRow();
                this.auxFila[0] = mesa.IDMesa;
                this.auxFila[1] = mesa.CodigoMesa;
                this.auxFila[2] = mesa.Estado;

                this.tablaMesas.Rows.Add(this.auxFila);//-->Añado las Filas 
            }
            this.dtgvMesas.DataSource = this.tablaMesas;//-->Al dataGrid le paso la lista  
        }
        #endregion

        #region OTROS EVENTOS
        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region EVENTOS
        private void FrmMesasView_Load(object sender, EventArgs e)
        {
            this.tablaMesas.Columns.Add("ID", typeof(int));
            this.tablaMesas.Columns.Add("Estado", typeof(string));
            this.tablaMesas.Columns.Add("Codigo Mesa", typeof(string));

            this.CargarMesasDataGrid();//-->Cargo las mesas en el dataGridView
        }

        private void dtgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dtgvMesas.Columns["dtgvEditar"].Index && e.RowIndex >= 0)
                {
                    //-->Obtengo el ID de la mesa
                    int idMesa = Convert.ToInt32(this.dtgvMesas.CurrentRow.Cells["ID"].Value);

                    //-->Obtengo el codigo de la mesa
                    string codigoMesa = this.dtgvMesas.CurrentRow.Cells["Codigo Mesa"].Value.ToString();

                    //-->Abro el form para modificarlo
                    FrmAgregarMesa frmEditarMesa = new FrmAgregarMesa(idMesa, codigoMesa);
                    frmEditarMesa.ShowDialog();

                    //--->Actualizo el dtgv
                    if (frmEditarMesa.DialogResult == DialogResult.OK)
                    {
                        this.CargarMesasDataGrid();//-->Recargo del dtgv
                    }
                }
                else if (e.ColumnIndex == this.dtgvMesas.Columns["dtgvEliminar"].Index && e.RowIndex >= 0)
                {
                    try
                    {
                        //-->Pregunto si desea eliminar:
                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                        this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                        if (this.guna2MessageDialog1.Show("Desea eliminar la mesa?", "Información") == DialogResult.Yes)
                        {
                            int idMesa = Convert.ToInt32(this.dtgvMesas.CurrentRow.Cells["ID"].Value);//-->Obtengo ID

                            if (!this.mesaDAO.EliminarDato(idMesa))//-->Lanzo una exception de que no pudo eliminar.
                                throw new EliminarSQLException("No se ha podido eliminar la mesa, reintente!");

                            //-->Modifico el mensaje de Texto
                            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                            this.guna2MessageDialog1.Show("Se ha eliminado la mesa correctamente!", "Información");

                            this.CargarMesasDataGrid();//-->Actualizo el datagridView
                        }
                    }
                    catch (EliminarSQLException ex)
                    {
                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        this.guna2MessageDialog1.Show(ex.Message, "Error");
                    }
                    catch (Exception)
                    {
                        this.guna2MessageDialog1.Show("Algo inesperado sucedio! Reintente.", "Error");
                    }
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error.", "Error");
            }
        }

        public void btnAgregar_Click(object sender, EventArgs e)
        {
            this.frmAgregarMesa.ShowDialog();
            this.CargarMesasDataGrid();//--->Vuelvo a cargar.
        }
        #endregion
    }
}
