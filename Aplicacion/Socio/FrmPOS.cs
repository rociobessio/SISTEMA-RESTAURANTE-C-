using Aplicacion.Selection;
using Entidades;
using Entidades.DB;
using Excepciones;
using Guna.UI2.WinForms;

namespace Aplicacion.Socio
{
    public partial class FrmPOS : Form
    {
        #region ATRIBUTOS
        private List<Tuple<int, string>> listaCategorias;
        private List<Producto> listaProductos;
        private List<Pedido> listaPedidos = new List<Pedido>();
        private List<PedidoProducto> listaPedidosProducto;
        private string codPedido;
        private int _idConductor;
        private Pedido pedido;

        #region Cliente
        private string _nombreCliente;
        private string _apellidoCliente;
        private string _telefonoCliente;
        private string _direccionCliente;
        private Empleado _conductor;
        #endregion
        #endregion

        #region CONSTRUCTOR
        public FrmPOS()
        {
            InitializeComponent();
            this.listaCategorias = new CategoriasDAO().ObtenerTodos();
            this.listaProductos = new List<Producto>();


            #region OCULTO LABELS
            this.lblNombreConductor.Visible = false;
            this.lblTipoPedido.Visible = false;//-->Oculto el tipo de pedido
            this.lblTituloMesa.Visible = false;
            this.lblTituloMozo.Visible = false;
            this.lblMozo.Visible = false;
            this.lblMesa.Visible = false;
            #endregion
        }
        #endregion

        #region BOTONES

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                this.OcultarLabels();

                this.lblTipoPedido.Text = TiposPedidos.Delivery.ToString();

                FrmAgregarCliente frmAgregarCliente = new FrmAgregarCliente(TiposPedidos.Delivery.ToString());
                frmAgregarCliente.codigoPedido = codPedido;
                frmAgregarCliente.ShowDialog();

                if (!string.IsNullOrEmpty(frmAgregarCliente.txtNombre.Text))
                {
                    this._idConductor = frmAgregarCliente._idConductor;
                    this.lblNombreConductor.Visible = true;
                    this.lblNombreConductor.Text = $"Nombre Cliente: {frmAgregarCliente.txtNombre.Text} - Celular: {frmAgregarCliente.txtTelefono.Text} - Conductor: {frmAgregarCliente.cbConductor.Text}";
                    this._nombreCliente = frmAgregarCliente.txtNombre.Text;
                    this._telefonoCliente = frmAgregarCliente.txtTelefono.Text;
                    this._direccionCliente = frmAgregarCliente.txtDireccion.Text;
                    this._conductor = new EmpleadoDAO().ObtenerConductor(frmAgregarCliente.cbConductor.Text);
                    this._apellidoCliente = frmAgregarCliente.txtApellido.Text;

                }

            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion!");
            }
        }

        private void btnParaLlevar_Click(object sender, EventArgs e)
        {
            try
            {
                this.OcultarLabels();

                this.lblTipoPedido.Text = TiposPedidos.Para_Llevar.ToString();
                FrmAgregarCliente frmAgregarCliente = new FrmAgregarCliente(TiposPedidos.Para_Llevar.ToString().Replace("_", " "));
                frmAgregarCliente.codigoPedido = codPedido;
                frmAgregarCliente.ShowDialog();

                if (!string.IsNullOrEmpty(frmAgregarCliente.txtNombre.Text))
                {
                    this._idConductor = frmAgregarCliente._idConductor;
                    this.lblNombreConductor.Visible = true;
                    this.lblNombreConductor.Text = $"Nombre Cliente: {frmAgregarCliente.txtNombre.Text} - Celular: {frmAgregarCliente.txtTelefono.Text}";
                    this._nombreCliente = frmAgregarCliente.txtNombre.Text;
                    this._telefonoCliente = frmAgregarCliente.txtTelefono.Text;
                    this._direccionCliente = frmAgregarCliente.txtDireccion.Text;
                    this._apellidoCliente = frmAgregarCliente.txtApellido.Text;
                }

            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion!");
            }
        }

        /// <summary>
        /// Para comer dentro del restaurante.
        /// 
        /// 1. Obtengo el nombre/ID de la Mesa.
        /// 2. Obtengo el nombre del Mozo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPedido_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblTipoPedido.Text = TiposPedidos.Pedido.ToString();

                FrmElegirMesa frmElegirMesa = new FrmElegirMesa();
                frmElegirMesa.ShowDialog();//-->Abro el formulario

                if (!string.IsNullOrEmpty(frmElegirMesa.nombreTabla))
                    this.lblMesa.Text = frmElegirMesa.nombreTabla;
                else
                    this.lblMesa.Text = string.Empty;

                FrmElegirMozo frmElegirMozo = new FrmElegirMozo();
                frmElegirMozo.ShowDialog();//-->Abro los forms.

                if (!string.IsNullOrEmpty(frmElegirMozo.nombreMozo))
                    this.lblMozo.Text = frmElegirMozo.nombreMozo;
                else
                    this.lblMozo.Text = string.Empty;

                this.MostrarLabels();
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion!");
            }
        }

        /// <summary>
        /// El boton de la cocina/o pedido
        /// que me servira para generar 
        /// justamente le pedido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKOT_Click(object sender, EventArgs e)
        {
            try
            {

                Pedido pedido = this.CrearPedido();
                this.InsertarPedidoEnBaseDatos(pedido, pedido.TiempoPreparacionTotal);

                if(pedido.TipoOrden != "Pedido")//-->Si es Delivery o Para Llevar
                    this.AsignarCliente(pedido);

                this.pedido = pedido;
                this.codPedido = pedido.CodPedido;

                this.MostrarMensajeExito();
            }
            catch (AgregarDatoSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message);
            }
            catch (UpdateSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message);
            }
            catch (MesaNoSeleccionadaException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message);
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion!");
            }
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBillList frmBillList = new FrmBillList();
                frmBillList.ShowDialog();
                this.lblMozo.Visible = false;

                this.listaPedidos = new PedidoDAO().ObtenerTodos();
                this.listaPedidosProducto = new PedidoProductoDAO().ObtenerTodos();
                this.listaProductos = new ProductoDAO().ObtenerTodos();

                if (frmBillList.IDPedido > 0)
                {
                    //-->Recorro la lista de pedidos en coincidencia de IDs
                    foreach (Pedido pedido in this.listaPedidos)
                    {
                        if (pedido.IDPedido == frmBillList.IDPedido)//-->Coinciden las IDs, cargo
                        {
                            foreach (PedidoProducto ped in this.listaPedidosProducto)
                            {
                                if (pedido.CodPedido == ped.CodigoPedido)
                                {
                                    foreach (Producto producto in this.listaProductos)
                                    {
                                        if (ped.IDProducto == producto.IDProducto)
                                        {
                                            this.codPedido = pedido.CodPedido;

                                            if (pedido.TipoOrden == "Pedido")
                                            {
                                                this.lblMesa.Text = pedido.IDMesa.ToString();
                                                this.btnPedido.Checked = true;
                                            }
                                            else if (pedido.TipoOrden == "Para Llevar")
                                            {
                                                this.lblMesa.Visible = false;
                                                this.btnParaLlevar.Checked = true;
                                            }
                                            else
                                            {
                                                this.lblMesa.Visible = false;
                                                this.btnDelivery.Checked = true;
                                            }

                                            //-->Creo el Objeto
                                            object[] obj = { 0, producto.Nombre, ped.Cantidad, producto.Precio, producto.Precio * ped.Cantidad };
                                            this.dtgv.Rows.Add(obj);//-->Lo guardo
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                this.ImprimirTotal();
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error en la aplicación. Reintente!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Me permitira generar un nuevo pedido
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.lblMesa.Visible = false;
            this.lblMozo.Visible = false;
            this.dtgv.Rows.Clear();
            this.lblTotal.Text = "0.00";
            this.lblNombreConductor.Text = string.Empty;
        }

        /// <summary>
        /// Para pagar un pedido seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.codPedido))//-->Chequeo que no este vacio.
                {
                    FrmCheckOut frmCheckOut = new FrmCheckOut(this.codPedido);
                    frmCheckOut.ShowDialog();

                    if (frmCheckOut.pudoPagar)//-->Si pudo pagar, me fijo si es delivery
                    {
                        //-->Si es delivery asigno un delivery al pedido.
                        this.pedido = new PedidoDAO().ObtenerPedidoPorCodigoPedido(this.codPedido);
                        if (this.pedido.TipoOrden == "Delivery")
                        {
                            Pedido pedidoDelivery = new PedidoDAO().ObtenerPedidoPorCodigoPedido(this.codPedido);
                            if (!new DeliveryDAO().AgregarDato(new Delivery(this._direccionCliente, pedidoDelivery.IDPedido,
                                frmCheckOut.idFacturacion, this._conductor.IDEmpleado)))
                                throw new AgregarDatoSQLException("No se ha podido asignar un delivery");
                        }
                        else if(this.pedido.TipoOrden == "Pedido" && this.pedido.Estado == "Entregado")
                        {
                            Mesa mesa = new MesaDAO().ObtenerEspecifico(this.pedido.IDMesa);
                            mesa.Estado = Estados.Cerrada.ToString().Replace("_", " ");
                            if (!new MesaDAO().UpdateDato(mesa))//-->Actualizo
                                throw new UpdateSQLException("No se ha podido actualizar el estado de la mesa.");
                        }
                    }
                }
                else
                {
                    this.guna2MessageDialog1.Show("No hay pedido seleccionado!","Error");
                }
            }
            catch (AgregarDatoSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message,"Error");
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion!","Error");
            }
        }
        #endregion

        #region EVENTOS
        private void FrmPOS_Load(object sender, EventArgs e)
        {
            this.dtgv.BorderStyle = BorderStyle.FixedSingle;

            this.CargarCategorias();//-->Cargo los botones de las categorias.

            this.panelProductos.Controls.Clear();
            this.CargarProductos();
        }

        /// <summary>
        /// Me permitira buscar por nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in this.panelProductos.Controls)
            {
                var prod = (ucProducto)item;
                prod.Visible = prod.Nombre.ToLower().Contains(this.txtBuscar.Text.Trim().ToLower());
            }
        }
        #endregion

        #region METODOS
        private void InsertarPedidoEnBaseDatos(Pedido pedido, TimeSpan tiempoEstimado)
        {
            //-->Guardo el pedido.
            if (!new PedidoDAO().AgregarDato(pedido))
                throw new AgregarDatoSQLException("No se ha podido generar el pedido, reintente!");

            foreach (Producto prod in this.listaProductos)
            {
                int cantidadProducto = ObtenerCantidadProducto(prod.IDProducto);
                if (!new PedidoProductoDAO().AgregarDato(new PedidoProducto(pedido.CodPedido, prod.IDProducto, EstadosComidas.Pendiente.ToString(), cantidadProducto)))
                {
                    throw new AgregarDatoSQLException("No se pudo agregar a la tabla intermedia, reintente!");
                }
            }
        }

        private int ObtenerCantidadProducto(int idProducto)
        {
            foreach (DataGridViewRow row in this.dtgv.Rows)
            {
                if (row.Cells["ID"].Value != null && Convert.ToInt32(row.Cells["ID"].Value) == idProducto)
                {
                    return Convert.ToInt32(row.Cells["Cantidad"].Value);
                }
            }
            return 0;
        }

        private void AsignarCliente(Pedido pedido)
        {
            this.codPedido = pedido.CodPedido;
            this.pedido = pedido;
            int idCliente = 0;
            if (!new ClienteDAO().AgregarDato(new Entidades.Cliente(this._nombreCliente, this._apellidoCliente, Genero.Otro, new DateTime(), "", this._direccionCliente,
                this._telefonoCliente, new Usuario("", ""), 0, false, new Tarjeta()), out idCliente))
            {
                throw new AgregarDatoSQLException("No se ha podido generar al Cliente!");
            }

            if (!new ClientePedidoDAO().AgregarDato(new ClientePedido(this.codPedido, idCliente)))
            {
                throw new AgregarDatoSQLException("No se ha podido guardar en la tabla Cliente-Pedido!");
            }
        }


        private void MostrarMensajeExito()
        {
            this.lblTotal.Text = "00.0";
            this.guna2MessageDialog1.Icon = MessageDialogIcon.Information;
            this.guna2MessageDialog1.Caption = "Información";
            this.guna2MessageDialog1.Show("Pedido generado correctamente!");
            this.dtgv.Rows.Clear();
        }

        private Pedido CrearPedido()
        {
            Pedido pedido = new Pedido(Herramientas.CrearCodigo(5), EstadosComidas.Pendiente.ToString(), TimeSpan.Zero, this.lblTipoPedido.Text);

            if (this.lblTipoPedido.Text == TiposPedidos.Pedido.ToString())
            {
                Mesa mesa = new MesaDAO().ObtenerEspecifico(int.Parse(this.lblMesa.Text));
                pedido.IDMesa = mesa.IDMesa;
                mesa.Estado = Estados.Con_Cliente_Esperando_Pedido.ToString().Replace("_", " ");
                if (!new MesaDAO().UpdateDato(mesa))
                {
                    throw new UpdateSQLException("No se ha podido modificar el estado de la mesa, reintente!");
                }
            }

            foreach (DataGridViewRow item in this.dtgv.Rows)
            {
                int cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value);
                Producto producto = new ProductoDAO().ObtenerEspecifico(Convert.ToInt32(item.Cells["ID"].Value));
                if (producto.TiempoEstimadoPreparacion > pedido.TiempoPreparacionTotal)
                {
                    pedido.TiempoPreparacionTotal = producto.TiempoEstimadoPreparacion;
                }
                pedido.TotalPedido += cantidad * producto.Precio;
                this.listaProductos.Add(producto);
            }

            return pedido;
        }


        private void MostrarLabels()
        {
            #region MUESTRO LABELS
            this.lblTituloMesa.Visible = true;
            this.lblTituloMozo.Visible = true;
            this.lblMozo.Visible = true;
            this.lblMesa.Visible = true;
            #endregion
        }

        private void OcultarLabels()
        {
            #region Oculto LABELS
            this.lblTituloMesa.Visible = false;
            this.lblTituloMozo.Visible = false;
            this.lblMozo.Visible = false;
            this.lblMesa.Visible = false;
            #endregion
        }

        /// <summary>
        /// Me permitira imprimir el valor
        /// total de los productos sumados 
        /// al pedido.
        /// </summary>
        private void ImprimirTotal()
        {
            double total = 0;
            this.lblTotal.Text = "0.00";
            foreach (DataGridViewRow item in this.dtgv.Rows)
            {
                if (item.Cells["Total"] != null && item.Cells["Total"].Value != null)
                {
                    total += double.Parse(item.Cells["Total"].Value.ToString());
                }
            }
            this.lblTotal.Text = total.ToString("N2");
        }



        /// <summary>
        /// Me permitira cargar los botones
        /// de las categorias.
        /// </summary>
        private void CargarCategorias()
        {
            //DataTable dt = new DataTable();
            this.panelCategorias.Controls.Clear();

            foreach (Tuple<int, string> categoria in this.listaCategorias)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.FillColor = Color.IndianRed;
                b.Size = new Size(195, 76);
                b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                b.Text = categoria.Item2;
                b.Click += new EventHandler(_Click);//-->Al presionar el boton de alguna categoria filtro

                this.panelCategorias.Controls.Add(b);//-->Añado el boton de la categoria
            }
        }

        private void _Click(object? sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;

            foreach (var item in this.panelProductos.Controls)
            {
                var prod = (ucProducto)item;
                prod.Visible = prod.Categoria.ToLower().Contains(b.Text.Trim().ToLower());
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
                    Categoria = CategoriasDAO.ObtenerNombreCategoriaPorID(prod.Categoria),//-->Obtengo la categoria
                    ID = prod.IDProducto
                };

                using (MemoryStream ms = new MemoryStream(prod.Imagen))//-->Para asignar la imagen del producto.
                {
                    w.Imagen = Image.FromStream(ms);
                }

                panelProductos.Controls.Add(w);//-->Muestro el item

                //-->Concateno el evento
                w.onSelect += (ss, ee) =>
                {
                    var wdg = (ucProducto)ss;
                    foreach (DataGridViewRow item in this.dtgv.Rows)
                    {
                        if (item.Cells["ID"].Value != null && int.TryParse(item.Cells["ID"].Value.ToString(), out int idValue))
                        {
                            if (idValue == wdg.ID)
                            {
                                item.Cells["Cantidad"].Value = int.Parse(item.Cells["Cantidad"].Value.ToString()) + 1;
                                item.Cells["Total"].Value = int.Parse(item.Cells["Cantidad"].Value.ToString()) *
                                double.Parse(item.Cells["Precio"].Value.ToString());

                                return;
                            }
                        }
                    }

                    this.dtgv.Rows.Add(new object[] { wdg.ID, wdg.Nombre, 1, wdg.Precio, wdg.Precio });
                    this.ImprimirTotal();
                };
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error en la aplicación. Reintente!");
            }
        }
        #endregion

        #region OTROS
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
