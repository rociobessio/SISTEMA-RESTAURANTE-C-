using Entidades;
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
using Excepciones;

namespace Aplicacion.View
{
    public partial class FrmCocina : Form
    {
        #region CONTRUCTOR
        public FrmCocina()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTOS
        private void FrmCocina_Load(object sender, EventArgs e)
        {
            this.MostrarPedidos();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo privado que me permitira
        /// mostrar los pedidos que no esten
        /// entregados o despachados. 
        /// Imprimiendo unas cards con la informacion.
        /// </summary>
        private void MostrarPedidos()
        {
            this.flowLayoutPanel1.Controls.Clear();
            try
            {

                List<Pedido> listaPedidos = new PedidoDAO().ObtenerTodos();

                foreach (Pedido pedido in listaPedidos)
                {
                    if (pedido.Estado != "Entregado" && pedido.Estado != "Despachar")//-->Filtro para no mostrar los entregados{
                    {
                        FlowLayoutPanel panel = CrearPanelPedido(pedido);
                        this.flowLayoutPanel1.Controls.Add(panel);

                    }
                }

                this.flowLayoutPanel1.AutoScroll = true;
            }
            catch (Exception ex)
            {
                MostrarMensajeError("Ocurrió un error en la aplicación.", ex.Message);
            }
        }

        /// <summary>
        /// Me permitira crear el panel o card 
        /// del pedido con el boton para cambiar el 
        /// estado del pedido.
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        private FlowLayoutPanel CrearPanelPedido(Pedido pedido)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.Width = 230;
            panel.Height = 350;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Margin = new Padding(10, 10, 12, 100);

            FlowLayoutPanel panel2 = new FlowLayoutPanel();
            panel2.BackColor = Color.IndianRed;
            panel2.AutoSize = true;
            panel2.Width = 230;
            panel2.Height = 125;
            panel2.FlowDirection = FlowDirection.TopDown;//-->Como iran las cajas
            panel2.Margin = new Padding(10, 0, 10, 0);

            Label lbl = new Label();
            lbl.ForeColor = Color.White;
            lbl.Margin = new Padding(10, 10, 3, 0);
            lbl.AutoSize = true;

            Label lbl2 = new Label();
            lbl2.ForeColor = Color.White;
            lbl2.Margin = new Padding(10, 5, 3, 0);
            lbl2.AutoSize = true;

            Label lbl3 = new Label();
            lbl3.ForeColor = Color.White;
            lbl3.Margin = new Padding(10, 5, 3, 0);
            lbl3.AutoSize = true;

            Label lbl4 = new Label();
            lbl4.ForeColor = Color.White;
            lbl4.Margin = new Padding(10, 5, 3, 0);
            lbl4.AutoSize = true;

            Label lbl5 = new Label();
            lbl5.ForeColor = Color.White;
            lbl5.Margin = new Padding(10, 5, 3, 0);
            lbl5.AutoSize = true;


            //-->Cargo la data:
            lbl.Text = pedido.IDMesa != 0 ? "Mesa : " + pedido.IDMesa.ToString() : "";
            lbl2.Text = "Tipo de Orden : " + pedido.TipoOrden.ToString();
            lbl3.Text = "Tiempo Total De Orden : " + pedido.TiempoPreparacionTotal.ToString();
            lbl4.Text = "Tiempo de Inicio : " + pedido.TiempoInicio.ToString();
            lbl4.Text = "Codigo de Pedido : " + pedido.CodPedido;

            panel2.Controls.Add(lbl);
            panel2.Controls.Add(lbl2);
            panel2.Controls.Add(lbl3);
            panel2.Controls.Add(lbl4);
            panel2.Controls.Add(lbl5);

            panel.Controls.Add(panel2);


            //-->La tabla intermedia.
            List<PedidoProducto> pedidoProductos = new PedidoProductoDAO().ObtenerPedidoProductosPorCodigoPedido(pedido.CodPedido);
            //-->Los productos
            List<Producto> listaProductos = new ProductoDAO().ObtenerTodos();

            int no = 0;

            foreach (PedidoProducto pedidoProducto in pedidoProductos)
            {
                Label lbl6 = new Label();
                lbl6.ForeColor = Color.Coral;
                lbl6.Margin = new Padding(10, 5, 3, 0);
                lbl6.AutoSize = true;
                no++;

                foreach (Producto product in listaProductos)
                {
                    if (pedidoProducto == product)
                    {
                        lbl6.Text = "" + no + " " + product.Nombre + " - Cantidad : " + pedidoProducto.Cantidad;
                    }

                    panel.Controls.Add(lbl6);
                }
            }

            //-->Boton para cambiar el estado
            Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();

            b.AutoRoundedCorners = true;
            b.Size = new Size(200, 70);
            b.FillColor = Color.IndianRed;
            b.Margin = new Padding(30, 10, 3, 10);

            //-->Probar los estados
            if (pedido.Estado == EstadosComidas.Pendiente.ToString())
                b.Text = EstadosComidas.En_Preparacion.ToString().Replace("_", " ");
            else if (pedido.Estado == EstadosComidas.En_Preparacion.ToString().Replace("_", " "))
                b.Text = EstadosComidas.Listo_Para_Servir.ToString().Replace("_", " ");
            else if ((pedido.Estado == EstadosComidas.Listo_Para_Servir.ToString().Replace("_", " ") &&
                (pedido.TipoOrden == "Delivery" || pedido.TipoOrden == "Para Llevar" || pedido.TipoOrden == "Para_Llevar")))
            {
                b.Text = EstadosComidas.Despachar.ToString().Replace("_", " ");
            }
            else if ((pedido.Estado == EstadosComidas.Listo_Para_Servir.ToString().Replace("_", " ")))
            {
                b.Text = EstadosComidas.Entregar.ToString().Replace("_", " ");
            }

            b.Tag = pedido.IDPedido;

            b.Click += new EventHandler(b_click);
            panel.Controls.Add(b);

         
            this.flowLayoutPanel1.AutoScroll = true;
            
            return panel;
        }

        /// <summary>
        /// Al presionar el boton se cambiara el estado 
        /// del pedido y dependiedno del tipo de pedido
        /// y estado se podrá cambiar el estado 
        /// de la mesa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_click(object? sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());
                string estado = Convert.ToString((sender as Guna.UI2.WinForms.Guna2Button).Text.ToString());
                this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;


                if (this.guna2MessageDialog1.Show("Desea cambiar el estado del pedido?", "Cuidado") == DialogResult.Yes)
                {
                    //-->Obtengo el pedido y modifico su estado.
                    Pedido pedido = new PedidoDAO().ObtenerEspecifico(id);
                    pedido.Estado = estado == "Entregar" ? "Entregado" : estado;


                    if (pedido.Estado == EstadosComidas.En_Preparacion.ToString().Replace("_", " "))
                        pedido.TiempoInicio = DateTime.Now.TimeOfDay;
                    else if (pedido.Estado == EstadosComidas.Listo_Para_Servir.ToString().Replace("_", " "))
                        pedido.TiempoFinalizacion = DateTime.Now.TimeOfDay;
                    else if (pedido.Estado == EstadosComidas.Entregado.ToString().Replace("_", " "))
                    {
                        //-->Si se entrega el pedido, cambio el estado de la mesa.
                        Mesa mesa = new MesaDAO().ObtenerEspecifico(pedido.IDMesa);
                        mesa.Estado = Estados.Con_Cliente_Comiendo.ToString().Replace("_"," ");
                        if (!new MesaDAO().UpdateDato(mesa))//-->Actualizo
                            throw new UpdateSQLException("No se ha podido actualizar el estado de la mesa.");
                    }


                    if (!new PedidoDAO().UpdateDato(pedido))//-->Actualizo
                        throw new UpdateSQLException("No se ha podido actualizar el estado del pedido.");

                    this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    this.guna2MessageDialog1.Show("Pedido Actualizado!", "Información");

                    this.MostrarPedidos();//-->Recargo
                }
            }
            catch (UpdateSQLException ex)
            {
                this.MostrarMensajeError("Ocurrió un error en la aplicación.", ex.Message);
            }
            catch (Exception)
            {
                this.MostrarMensajeError("Ocurrió un error en la aplicación.", "ERROR");
            }
        }

        /// <summary>
        /// Me permitira imprimir el mensaje 
        /// de error al ocurrir alguna excepcion.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="detalle"></param>
        private void MostrarMensajeError(string mensaje, string detalle)
        {
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Show(detalle, mensaje);
        }
        #endregion

        #region OTROS EVENTOS
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}
