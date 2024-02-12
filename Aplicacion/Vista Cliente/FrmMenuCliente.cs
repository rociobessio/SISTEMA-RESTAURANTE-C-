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
using Entidades;
using Entidades.DB;
using Guna.UI2.WinForms.Helpers;
using Microsoft.VisualBasic.Devices;

namespace Aplicacion.Cliente
{
    public partial class FrmMenuCliente : Form
    {
        #region ATRIBUTOS
        private List<Tuple<int, string>> listaCategorias;
        private List<Producto> listaProductos;
        private PanelScrollHelper panelScrollHelper;
        #endregion

        #region CONSTRUCTOR
        public FrmMenuCliente()
        {
            InitializeComponent();
            this.listaCategorias = new CategoriasDAO().ObtenerTodos();
            this.listaProductos = new ProductoDAO().ObtenerTodos();//-->Traigo todos los productos.


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
                b.Size = new Size(160,76);
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
        #endregion

        #region METODOS
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
                //w.onSelect += (ss, ee) =>
                //{
                //    var wdg = (ucProducto)ss;
                //    foreach (DataGridViewRow item in this.dtgv.Rows)
                //    {
                //        if (item.Cells["ID"].Value != null && int.TryParse(item.Cells["ID"].Value.ToString(), out int idValue))
                //        {
                //            if (idValue == wdg.ID)
                //            {
                //                item.Cells["Cantidad"].Value = int.Parse(item.Cells["Cantidad"].Value.ToString()) + 1;
                //                item.Cells["Total"].Value = int.Parse(item.Cells["Cantidad"].Value.ToString()) *
                //                double.Parse(item.Cells["Precio"].Value.ToString());

                //                return;
                //            }
                //        }
                //    }

                //    this.dtgv.Rows.Add(new object[] { wdg.ID, wdg.Nombre, 1, wdg.Precio, wdg.Precio });
                //    this.ImprimirTotal();
                //};
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error en la aplicación. Reintente!");
            }
        }
        #endregion

        #region BOTONES
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region OTROS EVENTOS
        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
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
