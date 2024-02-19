using Aplicacion.Controles;
using Aplicacion.Socio;
using Entidades;
using Entidades.DB;
using Guna.UI2.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Vista_Cliente
{
    public partial class FrmVerHistorial : Form
    {
        #region ATRIBUTOS
        private PanelScrollHelper panelScrollHelper;
        private List<PedidoProducto> listaPedidosProductos;
        private List<ClientePedido> listaClientePedido;
        private List<Pedido> listaPedidos;
        private Entidades.Cliente cliente;
        private PanelScrollHelper panelScrollHelperPedidos;

        #region DATAGRID
        private DataTable tabla;
        private DataRow auxFila = null;
        #endregion
        #endregion

        #region CONTRUCTOR
        public FrmVerHistorial(Entidades.Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.listaClientePedido = new ClientePedidoDAO().ObtenerTodos();
            this.listaPedidosProductos = new PedidoProductoDAO().ObtenerTodos();
            this.listaPedidos = new PedidoDAO().ObtenerTodos();
            this.tabla = new DataTable();
        }
        #endregion

        #region EVENTOS
        private void panelPedidosRealizados_Scroll(object sender, ScrollEventArgs e)
        {
            this.panelScrollHelper.UpdateScrollBar();
        }

        private void FrmVerHistorial_Load(object sender, EventArgs e)
        {
            //-->Para la Scroll-Bar
            this.panelScrollHelper = new PanelScrollHelper(this.panelPedidosRealizados, this.scrollBarProductos, true);

            #region CREO COLUMNAS DTGV
            this.tabla.Columns.Add("Sr#", typeof(int));
            this.tabla.Columns.Add("Nombre Producto", typeof(string));
            this.tabla.Columns.Add("Cantidad", typeof(int));
            this.tabla.Columns.Add("Precio", typeof(double));
            #endregion

            //-->Cargo los pedidos
            this.CargarPedidos();
        }

        /// <summary>
        /// Me permitira cerrar el formulario
        /// de historial de pedidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira recorrer los pedidos
        /// y buscar la coincidencia entre las 3 tablas
        /// clientePedido-PedidoProducto-Pedido
        /// </summary>
        private void CargarPedidos()
        {
            foreach (Pedido pedido in this.listaPedidos)
            {
                bool pedidoCoincide = false;

                foreach (ClientePedido clientePedido in this.listaClientePedido)
                {
                    foreach (PedidoProducto pedidoProducto in this.listaPedidosProductos)
                    {
                        //-->Si todo coincide:
                        if ((this.cliente.IDCliente == clientePedido.IDCliente) &&
                            (pedido.CodPedido == clientePedido.CodigoPedido && clientePedido.CodigoPedido == pedidoProducto.CodigoPedido))
                        {
                            pedidoCoincide = true;
                            break;
                        }
                    }
                }
                if (pedidoCoincide)
                {
                    this.AñadirItems(pedido);
                }
            }
        }

        /// <summary>
        /// Añadira controles de usuario ucPedido
        /// que al ser seleccionados mostrara
        /// en un datagrid el detalle del 
        /// pedido (producto, cant, precio,etc)
        /// </summary>
        /// <param name="pedido"></param>
        private void AñadirItems(Pedido pedido)
        {
            try
            {
                //-->Cargo el control de usuarios.
                var w = new ucPedido()
                {
                    CodigoPedido = pedido.CodPedido,
                    Total = pedido.TotalPedido.ToString(),
                    Estado = pedido.Estado,
                    FechaPedido = new FacturacionesDAO().ObtenerFacturacionPorCodigoPedido(pedido.CodPedido).FechaFacturacion.ToString()
                };

                this.panelPedidosRealizados.Controls.Add(w);//-->Muestro el control


                //-->Al clickear sobre el pedido se mostrara el detalle de este:
                //-->Concateno el evento
                w.onSelect += (ss, ee) =>
                {
                    this.lblCodigoPedido.Text = ((ucPedido)ss).CodigoPedido;
                    this.CargarDataGrid(((ucPedido)ss).CodigoPedido);
                };

            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error en la aplicación. Reintente!");
            }
        }

        /// <summary>
        /// Me permitira cargar
        /// los datos de un pedido
        /// realizado por un cliente en
        /// especifico en un datagrid view.
        /// </summary>
        private void CargarDataGrid(string codigoPedido)
        {
            this.tabla.Rows.Clear();//-->Limpio las filas.
            int sr = 1;

            foreach (PedidoProducto pedidoProducto in this.listaPedidosProductos)
            {
                //-->Si todo coincide:
                if (codigoPedido == pedidoProducto.CodigoPedido)
                {
                    Producto prod = new ProductoDAO().ObtenerEspecifico(pedidoProducto.IDProducto);
                    this.auxFila = this.tabla.NewRow();
                    this.auxFila[0] = sr;
                    this.auxFila[1] = prod.Nombre;
                    this.auxFila[2] = pedidoProducto.Cantidad;
                    this.auxFila[3] = prod.Precio;

                    sr++;
                    this.tabla.Rows.Add(this.auxFila);//-->Añado las Filas 
                }
            }
            this.dtgvProductosPedido.DataSource = this.tabla;//-->Al dataGrid le paso la lista  
        }
        #endregion

        #region EVENTOS
        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
