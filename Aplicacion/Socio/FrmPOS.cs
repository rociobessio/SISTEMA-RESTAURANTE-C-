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

namespace Aplicacion.Socio
{
    public partial class FrmPOS : Form
    {
        #region ATRIBUTOS

        private DataTable tabla;
        private DataRow auxFila = null;
        private CategoriasDAO categoriasDAO;
        private List<Tuple<int, string>> listaCategorias;
        #endregion
        public FrmPOS()
        {
            InitializeComponent();
            this.tabla = new DataTable();
            this.listaCategorias = new CategoriasDAO().ObtenerTodos();
        }

        #region BOTONES
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EVENTOS
        private void FrmPOS_Load(object sender, EventArgs e)
        {
            this.dtgv.BorderStyle = BorderStyle.FixedSingle;

            this.CargarCategorias();//-->Cargo los botones de las categorias.

            panelProductos.Controls.Clear();
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
        private void ImprimirTotal()
        {
            double total = 0;
            this.lblTotal.Text = "0.00";
            foreach (DataGridViewRow item in this.dtgv.Rows)
            {
                total += double.Parse(item.Cells["Total"].Value.ToString());
            }
            this.lblTotal.Text = "$" + total.ToString("N2");
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
        #endregion


    }
}
