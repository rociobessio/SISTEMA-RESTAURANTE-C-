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
        private void MostrarPedidos()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                //-->Obtengo TODOS LOS PEDIDOS Y SUS ESTADOS
                List<Pedido> listaPedidos = new PedidoDAO().ObtenerTodos();



                //-->Imprimire dentro del panel las boxes con los datos del pedido
                foreach (Pedido pedido in listaPedidos)
                {
                    if (pedido.Estado != "Entregado")//-->Filtro para no mostrar los entregados
                    {

                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoSize = true;
                        panel.Width = 230;
                        panel.Height = 350;
                        panel.FlowDirection = FlowDirection.TopDown;//-->Como iran las cajas
                                                                    //panel.BorderStyle = BorderStyle.FixedSingle;
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
                        lbl.Text = "Mesa : " + pedido.IDMesa.ToString();
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
                        else if ((pedido.Estado == EstadosComidas.Listo_Para_Servir.ToString().Replace("_", " ")))
                        {
                            b.Text = EstadosComidas.Entregar.ToString().Replace("_", " "); 
                        }

                        b.Tag = pedido.IDPedido;

                        b.Click += new EventHandler(b_click);
                        panel.Controls.Add(b);

                        this.flowLayoutPanel1.Controls.Add(panel);
                    }
                    this.flowLayoutPanel1.AutoScroll = true;
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error en la aplicacion.", "Error");
            }

        }

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



                    //-->Si pedido estaria para entregar y es delivery/para llevar podria despacharlo.
                    //-->Asi lo facturo


                    if (!new PedidoDAO().UpdateDato(pedido))//-->Actualizo
                        throw new UpdateSQLException("No se ha podido actualizar el estado del pedido.");

                    this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    this.guna2MessageDialog1.Show("Pedido Actualizado!", "Información");

                    this.MostrarPedidos();//-->Recargo
                }
            }
            catch (UpdateSQLException ex)
            {
                this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                this.guna2MessageDialog1.Show(ex.Message, "Error");
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error en la aplicacion.", "Error");
            }
        }
        #endregion

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
