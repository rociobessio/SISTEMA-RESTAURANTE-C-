using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Controles;
using Aplicacion.Socio;
using Aplicacion.Vista_Cliente;
using Entidades;
using Entidades.DB;
using Excepciones;
using Guna.UI2.WinForms.Helpers;
using Microsoft.VisualBasic.Devices;

namespace Aplicacion.Cliente
{
    public partial class FrmMenuCliente : Form
    {
        #region ATRIBUTOS
        private List<Tuple<int, string>> listaCategorias;
        private List<Producto> listaProductos;
        private List<Producto> listaProductosSeleccionados;
        private PanelScrollHelper panelScrollHelper;
        private PanelScrollHelper panelScrollHelperProdSeleccionados;
        private List<ucPago> productosSeleccionados;

        private Byte[] imagenArray;
        private string pathImagen;
        private Entidades.Cliente cliente;
        #endregion

        #region CONSTRUCTOR
        public FrmMenuCliente()
        {
            InitializeComponent();
            this.listaCategorias = new CategoriasDAO().ObtenerTodos();
            this.listaProductos = new ProductoDAO().ObtenerTodos();
            this.lblFechaActual.Text = DateTime.Now.ToLongDateString();
            this.listaProductosSeleccionados = new List<Producto>();

            this.productosSeleccionados = new List<ucPago>();
        }


        public FrmMenuCliente(Entidades.Cliente cliente)
            : this()
        {
            this.lblNombreCliente.Text = cliente.Nombre + " " + cliente.Apellido;
            this.cliente = cliente;
            this.CargarImagenCliente();
        }
        #endregion

        #region EVENTOS
        private void FrmMenuCliente_Load(object sender, EventArgs e)
        {
            this.panelProductos.Controls.Clear();
            this.CargarProductos();
            this.CargarCategorias();

            //-->Para la Scroll-Bar
            this.panelScrollHelper = new PanelScrollHelper(this.panelProductos, this.scrollBarProductos, true);
            this.panelScrollHelperProdSeleccionados = new PanelScrollHelper(this.panelProductosSeleccionados, this.scrollBarProductosPedidos, true);
        }

        /// <summary>
        /// Para que el scroll bar se vaya actualizando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelProductos_Scroll(object sender, ScrollEventArgs e)
        {
            this.panelScrollHelper.UpdateScrollBar();
        }

        private void panelProductosSeleccionados_Scroll(object sender, ScrollEventArgs e)
        {
            this.panelScrollHelperProdSeleccionados.UpdateScrollBar();
        }

        /// <summary>
        /// Me permitira cargar los botones
        /// de las categorias.
        /// </summary>
        private void CargarCategorias()
        {
            this.panelCategorias.Controls.Clear();

            foreach (Tuple<int, string> categoria in this.listaCategorias)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.FillColor = Color.IndianRed;
                b.Size = new Size(160, 76);
                b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                b.Text = categoria.Item2;
                b.CustomizableEdges.BottomLeft = false;
                b.CustomizableEdges.TopLeft = false;
                b.Click += new EventHandler(_Click);//-->Al presionar el boton de alguna categoria filtro

                this.panelCategorias.Controls.Add(b);//-->Añado el boton de la categoria
            }
        }

        /// <summary>
        /// Al presionar una categoria
        /// mostrara en el panel de productos
        /// aquellos productos de la categoria
        /// seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Click(object? sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;

            foreach (var item in this.panelProductos.Controls)
            {
                var prod = (ucProducto)item;
                prod.Visible = prod.Categoria.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            this.lblTipoPedido.Text = TiposPedidos.Delivery.ToString().Replace("_", " ");
        }

        private void btnParaLlevar_Click(object sender, EventArgs e)
        {
            this.lblTipoPedido.Text = TiposPedidos.Para_Llevar.ToString().Replace("_", " ");
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira resetear 
        /// algunos controles del formulario.
        /// </summary>
        private void LimpiarControles()
        {
            this.listaProductosSeleccionados.Clear();
            this.panelProductosSeleccionados.Controls.Clear();
            this.lblTotal.Text = "0.00";
            this.btnDelivery.Checked = false;
            this.btnParaLlevar.Checked = false;
        }

        /// <summary>
        /// Metodo que me permitira cargar la 
        /// imagen del cliente en el picture box.
        /// </summary>
        private void CargarImagenCliente()
        {
            try
            {
                if (this.cliente.Imagen != null && this.cliente.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(this.cliente.Imagen))
                    {
                        this.pcImagenUsuario.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    this.pcImagenUsuario.Image = null;//-->Si no hay imagen que muestre la default
                }
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Algo salio mal al querer mostrar la imagen de usuario!", "Error");
            }
        }


        /// <summary>
        /// Me permitira obtener la lista d productos
        /// para luego añadir los items al panel de control
        /// y mostrarlo.
        /// </summary>
        private void CargarProductos()
        {
            List<Producto> listaProductos = new ProductoDAO().ObtenerTodos();

            foreach (Producto producto in listaProductos)
            {
                Byte[] imagenArray = (byte[])producto.Imagen;
                byte[] imageByteArray = imagenArray;

                this.AñadirItems(producto);
            }
        }

        /// <summary>
        /// Me permitira guardar un item
        /// con los datos del producto.
        /// </summary>
        /// <param name="prod"></param>
        private void AñadirItems(Producto prod)
        {
            try
            {
                var w = new ucProducto()
                {
                    Nombre = prod.Nombre,
                    Precio = prod.Precio,
                    Categoria = CategoriasDAO.ObtenerNombreCategoriaPorID(prod.Categoria),
                    ID = prod.IDProducto
                };

                using (MemoryStream ms = new MemoryStream(prod.Imagen))
                {
                    w.Imagen = Image.FromStream(ms);
                }

                w.onSelect += (ss, ee) =>
                {
                    var wdg = (ucProducto)ss;

                    var controlPedido = new ucPago();
                    controlPedido.Nombre = wdg.Nombre;
                    controlPedido.Precio = wdg.Precio.ToString();
                    controlPedido.Categoria = wdg.Categoria.ToString();
                    controlPedido.Cantidad = 1;

                    //-->Si los Nombres de los productos coinciden que no lo vuelva a mostrar.
                    if (!this.productosSeleccionados.Any(p => p.Nombre == controlPedido.Nombre))
                    {

                        this.productosSeleccionados.Add(controlPedido);


                        this.MostrarProductosSeleccionados();

                    }
                    this.ImprimirTotal();//-->Imprimo el total s
                };

                this.panelProductos.Controls.Add(w);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el producto.");
            }
        }

        /// <summary>
        /// Me permitira mostrar los productos seleccionados
        /// del panel de productos para imprimirlos en el 
        /// de 'Nueva Orden'
        /// </summary>
        private void MostrarProductosSeleccionados()
        {
            this.panelProductosSeleccionados.Controls.Clear();

            //-->Agrego los productos al panel
            foreach (ucPago productoSeleccionado in this.productosSeleccionados)
            {
                //productoSeleccionado.Cantidad = ObtenerCantidadProducto(productoSeleccionado.Nombre);
                this.panelProductosSeleccionados.Controls.Add(productoSeleccionado);
            }
        }


        /// <summary>
        /// Metodo para ir actualizando el total 
        /// de la compra.
        /// </summary>
        private void ImprimirTotal()
        {
            double total = 0;

            // Iterar a través de los productos seleccionados y calcular el total
            foreach (var productoSeleccionado in this.productosSeleccionados)
            {
                // Obtener el precio y la cantidad del producto
                double precioProducto = Convert.ToDouble(productoSeleccionado.Precio);
                int cantidadProducto = productoSeleccionado.Cantidad;

                // Calcular el subtotal del producto (precio * cantidad)
                double subtotalProducto = precioProducto * cantidadProducto;

                // Agregar el subtotal del producto al total
                total += subtotalProducto;
            }

            // Mostrar el total en el label correspondiente
            this.lblTotal.Text = total.ToString("N2");
        }

        /// <summary>
        /// Metodo que me permitira generar un pedido y
        /// guardarlo en la db.
        /// </summary>
        /// <returns></returns>
        private Pedido GenerarPedido()
        {
            Pedido pedido = new Pedido(Herramientas.CrearCodigo(5), EstadosComidas.Pendiente.ToString(), TimeSpan.Zero, this.lblTipoPedido.Text);

            foreach (ucPago productoSeleccionado in this.panelProductosSeleccionados.Controls)
            {
                Producto producto = new ProductoDAO().ObtenerPorNombre(productoSeleccionado.Nombre);

                if (producto.TiempoEstimadoPreparacion > pedido.TiempoPreparacionTotal)
                {
                    pedido.TiempoPreparacionTotal = producto.TiempoEstimadoPreparacion;
                }
                pedido.TotalPedido += producto.Precio;
                this.listaProductosSeleccionados.Add(producto);
            }

            return pedido;
        }

        /// <summary>
        /// Me permitira guardar un pedido en la db.
        /// </summary>
        /// <param name="pedido"></param>
        /// <param name="tiempoEstimado"></param>
        /// <exception cref="AgregarDatoSQLException"></exception>
        private void InsertarPedidoEnBaseDatos(Pedido pedido, TimeSpan tiempoEstimado)
        {
            //-->Guardo el pedido.
            if (!new PedidoDAO().AgregarDato(pedido))
                throw new AgregarDatoSQLException("No se ha podido generar el pedido, reintente!");


            //-->Guardo en la tabla intermedia
            foreach (Producto prod in this.listaProductos)
            {
                foreach (var control in this.panelProductosSeleccionados.Controls)
                {
                    if (control is ucPago productoSeleccionado)
                    {
                        if (productoSeleccionado.Nombre == prod.Nombre)
                        {
                            if (!new PedidoProductoDAO().AgregarDato(new PedidoProducto(pedido.CodPedido, prod.IDProducto, EstadosComidas.Pendiente.ToString(), productoSeleccionado.Cantidad)))
                            {
                                throw new AgregarDatoSQLException("No se pudo agregar a la tabla intermedia, reintente!");
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Me permitira fragmentar el codigo
        /// y poder guardar una instancia de cliente-pedido
        /// en una tabla intermedia.
        /// </summary>
        /// <param name="pedido"></param>
        /// <param name="cliente"></param>
        /// <exception cref="AgregarDatoSQLException"></exception>
        private void AsignarCliente(Pedido pedido, Entidades.Cliente cliente)
        {
            if (!new ClientePedidoDAO().AgregarDato(new ClientePedido(pedido.CodPedido, cliente.IDCliente)))
            {
                throw new AgregarDatoSQLException("No se ha podido guardar en la tabla Cliente-Pedido!");
            }
        }

        /// <summary>
        /// Me permitira generar un delivery si 
        /// el pedido lo requiere.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="pedido"></param>
        /// <param name="idFacturacion"></param>
        /// <exception cref="AgregarDatoSQLException"></exception>
        private void AsignarDelivery(Pedido pedido, int idFacturacion, string direccionPedido)
        {
            Pedido pedConID = new PedidoDAO().ObtenerPedidoPorCodigoPedido(pedido.CodPedido);

            if (!new DeliveryDAO().AgregarDato(new Delivery(direccionPedido, pedConID.IDPedido,
                                idFacturacion, new EmpleadoDAO().ObtenerConductorRandom().IDEmpleado)))
                throw new AgregarDatoSQLException("No se ha podido asignar un Delivery al pedido!");
        }
        #endregion

        #region BOTONES
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Me permitira saber si se cumplen
        /// todos los requisitos para realizar un pago.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbonar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnDelivery.Checked || this.btnParaLlevar.Checked)
                {
                    //--->Primero genero el pedido
                    Pedido pedido = this.GenerarPedido();

                    this.InsertarPedidoEnBaseDatos(pedido, pedido.TiempoPreparacionTotal);

                    //--->Luego lo pago y le pregunto si desea guardar los datos de su tarjeta,
                    //donde modificaria su tabla.
                    FrmAbonarPedido frmPagarPedido = new FrmAbonarPedido(pedido.CodPedido, this.cliente);
                    frmPagarPedido.ShowDialog();

                    if (frmPagarPedido.pudoPagar)//-->Efectivamente se efecturo la compra
                    {
                        this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                        if (frmPagarPedido.EsConTarjeta && this.guna2MessageDialog1.Show("¿Desea guardar la tarjeta?") == DialogResult.Yes)
                        {
                            this.cliente.Tarjeta = frmPagarPedido.Tarjeta;//-->Asigno la tarjeta generada.
                            if (!new ClienteDAO().UpdateDato(this.cliente))
                                throw new UpdateSQLException("No se ha podido guardar la tarjeta.");
                        }

                        //--->Al pedido le guardamos el cliente en la tabla intermedia.
                        this.AsignarCliente(pedido, this.cliente);


                        if (pedido.TipoOrden == "Delivery")
                        {
                            this.AsignarDelivery(pedido, frmPagarPedido.idFacturacion, frmPagarPedido.Direccion);
                        }

                        this.LimpiarControles();
                        this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Show("Pedido generado con exito!", "Información.");
                    }
                }
                else
                {
                    this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    this.guna2MessageDialog1.Show("Debe de seleccionar el retiro del pedido.", "Información.");
                }
                //-->Podria haber un historial de pedidos, o implementar
                //que el cliente pueda ver el tiempo de demora y estado 
                //del pedido.
            }
            catch (UpdateSQLException ex)
            {
                this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                this.guna2MessageDialog1.Show(ex.Message, "Error.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar abonar el pedido.");
            }
        }

        /// <summary>
        /// Me permitira abrir otro formulario
        /// para poder ver el historial de pedidos realizados
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerMisPedidos_Click(object sender, EventArgs e)
        {
            FrmVerHistorial frmVerHistorial = new FrmVerHistorial(this.cliente);
            frmVerHistorial.ShowDialog();
        }

        /// <summary>
        /// Podre abrir un formulario para editar
        /// el perfil del cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingsCliente_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region OTROS EVENTOS
        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {

        }
        private void scrollBarProductosPedidos_Scroll(object sender, ScrollEventArgs e)
        {

        }
        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panelProductos_Paint(object sender, PaintEventArgs e)
        {

        }
        private void scrollBarProductos_Scroll(object sender, ScrollEventArgs e)
        {

        }
        #endregion


    }
}
