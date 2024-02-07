using Entidades.DB;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Socio
{
    public partial class FrmBillList : FrmSampleAdd
    {
        #region ATRIBUTOS
        private List<Pedido> listaPedidos;
        public int IDPedido;

        #region DATAGRID
        private DataTable tabla;
        private DataRow auxFila = null;
        #endregion
        #endregion

        #region CONSTRUCTOR
        public FrmBillList()
        {
            InitializeComponent();
            this.tabla = new DataTable();
        }
        #endregion

        #region EVENTOS
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmBillList_Load(object sender, EventArgs e)
        {
            #region CREO COLUMNAS DTGV
            this.tabla.Columns.Add("Sr#", typeof(int));
            this.tabla.Columns.Add("ID", typeof(int));
            this.tabla.Columns.Add("Mesa");
            this.tabla.Columns.Add("Tipo Orden", typeof(string));
            this.tabla.Columns.Add("Estado", typeof(string));
            this.tabla.Columns.Add("Total", typeof(double));
            this.tabla.Columns.Add("Pedido Abonado");
            #endregion

            this.CargarDataGrid();
        }

        private void dtgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dtgvBillList.Columns["dtgvEditar"].Index && e.RowIndex >= 0)
                {
                    this.IDPedido = Convert.ToInt32(this.dtgvBillList.CurrentRow.Cells["ID"].Value);//-->Obtengo el ID
                    this.Close();
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion.", "Error");
            }
        }
        #endregion

        #region METODOS
        private void CargarDataGrid()
        {
            this.listaPedidos = new PedidoDAO().ObtenerTodos();

            this.tabla.Rows.Clear();//-->Limpio las filas.
            int sr = 1;

            foreach (Pedido pedido in this.listaPedidos)
            {
                this.auxFila = this.tabla.NewRow();
                this.auxFila[0] = sr;
                this.auxFila[1] = pedido.IDPedido;
                this.auxFila[2] = pedido.IDMesa == 0 ? "-" : pedido.IDMesa.ToString();
                this.auxFila[3] = pedido.TipoOrden.Replace("_", " ");
                this.auxFila[4] = pedido.Estado;
                this.auxFila[5] = pedido.TotalPedido;
                this.auxFila[6] = pedido.PedidoPagado ? "SI" : "NO";

                sr++;
                this.tabla.Rows.Add(this.auxFila);//-->Añado las Filas 
            }
            this.dtgvBillList.DataSource = this.tabla;//-->Al dataGrid le paso la lista  
        }
        #endregion
    }
}
