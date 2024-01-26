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

namespace Aplicacion.Socio
{
    public partial class FrmAgregarCategoria : FrmSampleAdd
    {
        #region ATRIBUTOS
        private CategoriasDAO categoriasDAO;
        private int id;
        #endregion

        #region CONSTRUCTOR
        public FrmAgregarCategoria()
        {
            InitializeComponent();
            this.id = 0;
            this.categoriasDAO =  new CategoriasDAO();
        }

        /// <summary>
        /// Quiere decir que es editar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        public FrmAgregarCategoria(int id,string categoria)
            : this()
        {
            this.id = id;//-->Guardo el ID
            this.txtCategoria.Text = categoria;//-->Que me muestre el nombre
        }
        #endregion

        #region EVENTOS
        public override void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.id > 0)//-->Si ID mayor a 0, es para modificar
            {
                if (this.categoriasDAO.UpdateDato(id, this.txtCategoria.Text))
                {
                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;//-->Todo OK
                    this.Close();//-->Cierro el form
                }
                else
                {
                    MessageBox.Show("Error al actualizar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else//-->Si es 0 entonces nueva categoria
            {
                if (this.categoriasDAO.AgregarCategoria(this.txtCategoria.Text))
                {
                    MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicamos que la operación fue exitosa
                    this.Close(); // Cerramos el formulario
                }
                else
                {
                    MessageBox.Show("Error al agregar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region OTROS EVENTOS
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        #region METODOS

        #endregion

    }
}
