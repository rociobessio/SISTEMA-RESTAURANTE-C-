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
using Entidades.DB;
using Excepciones;
using System.IO;

namespace Aplicacion.Socio
{
    public partial class FrmAgregarProducto : FrmSampleAdd
    {
        #region ATRIBUTOS
        private CategoriasDAO categoriasDAO;
        private ProductoDAO productoDAO;
        private List<Tuple<int, string>> listaCategorias;
        private TimeSpan tiempoPreparacion;

        private Byte[] imagenArray;

        private int id;
        private string pathImagen;
        #endregion

        #region CONSTRUCTORES
        public FrmAgregarProducto()
        {
            InitializeComponent();
            this.categoriasDAO = new CategoriasDAO();
            this.productoDAO = new ProductoDAO();
            this.listaCategorias = this.categoriasDAO.ObtenerTodos();
        }

        public FrmAgregarProducto(Producto prod)
            : this()
        {
            this.label1.Text = "Modificar Producto";
            this.id = prod.IDProducto;

            this.CargarControles(prod);//-->Cargo los controles con la data del producto
        }
        #endregion

        #region BOTONES
        /// <summary>
        /// Me servira para pedirle una imagen
        /// y obtener el path de esta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.jpg, *.png)|*.png;*.jpg;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pathImagen = ofd.FileName;
                pcbImagen.Image = new Bitmap(this.pathImagen);
            }
        }

        public override void btnGuardar_Click(object sender, EventArgs e)
        {
            //-->Para la imagen:
            Image tempo = new Bitmap(this.pcbImagen.Image);
            MemoryStream memory = new MemoryStream();
            tempo.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            this.imagenArray = memory.ToArray();

            //-->Combo box Tupla categorias
            int selectedValue = this.listaCategorias[this.cbCategoria.SelectedIndex].Item1;


            if (this.id > 0)//-->Se modificara el producto
            {
                try
                {
                    if (this.ValidarInput())
                    {

                        if (!productoDAO.UpdateDato(new Producto(this.id, this.txtNombre.Text, Enum.Parse<Sectores>(this.cbSector.SelectedItem.ToString()),
                            Enum.Parse<Tipo>(this.cbTipo.SelectedItem.ToString()), this.tiempoPreparacion, double.Parse(this.txtPrecio.Text),
                            selectedValue, imagenArray)))
                            throw new UpdateSQLException("No se ha podido actualizar el producto, reintente!");

                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Show("Se ha modificado al empleado correctamente!", "Información");

                        this.DialogResult = DialogResult.OK;//-->Todo OK
                        this.Close();//-->Cierro el form
                    }
                    else
                        this.guna2MessageDialog1.Show("Verifique que el ingreso de datos sea correcto.", "Error");
                }
                catch (UpdateSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer agregar el nuevo producto.", "Error");
                }
            }
            else//-->Es un nuevo producto.
            {
                try
                {
                    if (this.ValidarInput())//-->Valido los datos.
                    {
                        if (!this.productoDAO.AgregarDato(new Producto(this.txtNombre.Text, Enum.Parse<Sectores>(this.cbSector.SelectedItem.ToString()),
                            Enum.Parse<Tipo>(this.cbTipo.SelectedItem.ToString()), this.tiempoPreparacion,
                            double.Parse(this.txtPrecio.Text), selectedValue, imagenArray)))
                            throw new AgregarDatoSQLException("No se ha podido agregar el producto, reintente!");

                        this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Show("Se ha guardado el producto correctamente!", "Información");

                        this.DialogResult = DialogResult.OK;//-->Todo OK
                        this.Close();//-->Cierro el form

                    }
                    else
                        this.guna2MessageDialog1.Show("Verifique que el ingreso de datos sea correcto.", "Error");
                }
                catch (AgregarDatoSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer agregar el nuevo producto.", "Error");
                }
            }
        }
        #endregion

        #region VALIDACIONES
        private bool ValidarInput()
        {
            bool valido = true;

            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtPrecio.Text) ||
                string.IsNullOrEmpty(this.txtTiempoEstimado.Text))
                valido = false;

            if (this.cbCategoria.SelectedIndex < 0 || this.cbSector.SelectedIndex < 0 || this.cbTipo.SelectedIndex < 0)
                valido = false;

            if (!TimeSpan.TryParse(this.txtTiempoEstimado.Text, out this.tiempoPreparacion))//-->Hora no valida
                valido = false;

            return valido;
        }
        /// <summary>
        /// Para que solo en el textbox 
        /// de nombre se ingresen letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }
        /// <summary>
        /// En el textbox de precio solo 
        /// se ingresaran numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }
        #endregion

        #region OTROS EVENTOS
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira mostrar los valores
        /// de un producto en los controles
        /// del formulario.
        /// </summary>
        /// <param name="producto"></param>
        private void CargarControles(Producto producto)
        {

            // Cargar la imagen desde el byte array en el PictureBox
            if (producto.Imagen != null && producto.Imagen.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(producto.Imagen))
                {
                    this.pcbImagen.Image = Image.FromStream(ms);
                }
            }
            else
            {
                this.pcbImagen.Image = null;//-->Si no hay imagen que muestre la default
            }

            this.txtNombre.Text = producto.Nombre;
            this.txtPrecio.Text = producto.Precio.ToString();
            this.txtTiempoEstimado.Text = producto.TiempoEstimadoPreparacion.ToString();
            //this.pcbImagen.Image = Aplicacion.Properties.Resources.imagen;//-->Cargar Imagen

            //-->Cargo los cbs
            this.cbSector.SelectedItem = producto.Sector;
            this.cbTipo.SelectedItem = producto.Tipo;
            this.cbCategoria.SelectedItem = producto.Categoria;
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Cargare los comboboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            #region CARGAR COMBO-BOXES
            foreach (Sectores sec in Enum.GetValues(typeof(Sectores)))
            {
                this.cbSector.Items.Add(sec);
            }
            this.cbSector.SelectedIndex = 0;
            foreach (Tipo tipo in Enum.GetValues(typeof(Tipo)))
            {
                this.cbTipo.Items.Add(tipo);
            }
            this.cbTipo.SelectedIndex = 0;
            foreach (var categoria in this.listaCategorias)
            {
                this.cbCategoria.Items.Add(categoria.Item2);
            }
            this.cbCategoria.SelectedIndex = 0;
            #endregion
        }
        #endregion

    }
}
