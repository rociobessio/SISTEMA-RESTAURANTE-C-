using Entidades.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna;
using System.Windows.Forms;
using Entidades;
using System.Collections.Immutable;
using Guna.UI2.WinForms;
using Aplicacion.Selection;
using Excepciones;

namespace Aplicacion.Socio
{
    public partial class FrmPOS : Form
    {
        #region ATRIBUTOS
        private List<Tuple<int, string>> listaCategorias;
        private List<Producto> listaProductos;
        #endregion

        #region CONSTRUCTOR
        public FrmPOS()
        {
            InitializeComponent();
            this.listaCategorias = new CategoriasDAO().ObtenerTodos();
            this.lblTipoPedido.Visible = false;//-->Oculto el tipo de pedido
            this.listaProductos = new List<Producto>();
        }
        #endregion

        #region BOTONES


        private void btnDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblTipoPedido.Text = TiposPedidos.Delivery.ToString();
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
                this.lblTipoPedido.Text = TiposPedidos.Para_Llevar.ToString();

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
                //if (!string.IsNullOrEmpty(this.lblMesa.Text))
                //    throw new MesaNoSeleccionadaException("Debe de seleccionar una mesa");

                Pedido pedido = new Pedido(Herramientas.CrearCodigo(5), EstadosComidas.Pendiente.ToString(), TimeSpan.Zero, this.lblTipoPedido.Text);

                if (this.lblTipoPedido.Text == TiposPedidos.Pedido.ToString())//-->Se selecciono una mesa xq es un pedido
                {
                    Mesa mesa = new MesaDAO().ObtenerEspecifico(int.Parse(this.lblMesa.Text));//-->Obtengo la mesa mediante su ID
                    
                    //-->Asigno el id al pedido
                    pedido.IDMesa = mesa.IDMesa;

                    //-->Cambio el estado de la mesa si el tipo de orden lo requiere
                    mesa.Estado = Estados.Con_Cliente_Esperando_Pedido.ToString().Replace("_", " ");
                    if (!new MesaDAO().UpdateDato(mesa))
                        throw new UpdateSQLException("No se ha podido modificar el estado de la mesa, reintente!");
                }
                
                TimeSpan tiempoEstimado = new TimeSpan();
                double totalPedido = 0;

                //-->Obtengo los productos, el precio TOTAL y el total del tiempo de preparacion del datagridview.
                foreach (DataGridViewRow item in this.dtgv.Rows)
                {
                    int cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value);

                    //-->Obtengo el producto
                    Producto producto = new ProductoDAO().ObtenerEspecifico(Convert.ToInt32(item.Cells["ID"].Value));

                    if (producto.TiempoEstimadoPreparacion > tiempoEstimado)
                        tiempoEstimado = producto.TiempoEstimadoPreparacion;

                    totalPedido += cantidad * producto.Precio;

                    //-->Agrego a la lista de productos el producto
                    this.listaProductos.Add(producto);
                }

                //-->Asigno el tiempo de preparacion
                pedido.TiempoPreparacionTotal = tiempoEstimado;
                pedido.TotalPedido = totalPedido;

                //-->Inserto el pedido
                if (!new PedidoDAO().AgregarDato(pedido))
                    throw new AgregarDatoSQLException("No se ha podido generar el pedido, reintente!");

                //-->Guardo en la tabla intermedia.
                foreach (Producto prod in this.listaProductos)
                {
                    int cantidadProducto = 0;

                    //-->Obtengo la cantidad
                    foreach (DataGridViewRow row in this.dtgv.Rows)
                    {
                        if (row.Cells["ID"].Value != null && Convert.ToInt32(row.Cells["ID"].Value) == prod.IDProducto)
                        {
                            cantidadProducto = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            break;
                        }
                    }

                    if (!new PedidoProductoDAO().AgregarDato(
                        new PedidoProducto(pedido.CodPedido, prod.IDProducto, EstadosComidas.Pendiente.ToString(), cantidadProducto)))
                    {
                        throw new AgregarDatoSQLException("No se pudo agregar a la tabla intermedia, reintente!");
                    }
                }

                this.guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                this.guna2MessageDialog1.Caption = "Información";
                this.guna2MessageDialog1.Show("Pedido generado!");
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
