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
                try
                {
                    if (!this.categoriasDAO.UpdateDato(id, this.txtCategoria.Text))
                        throw new UpdateSQLException("No se ha podido realizar la modificación de la categoria, reintente!");


                    this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    this.guna2MessageDialog1.Show("Se ha modificado la categoria correctamente!", "Información");

                    this.DialogResult = DialogResult.OK;//-->Todo OK
                    this.Close();//-->Cierro el form
                }
                catch (UpdateSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message,"Error");
                }
                catch(Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer modificar la categoria.", "Error");
                }
            }
            else//-->Si es 0 entonces nueva categoria
            {
                try
                {
                    if (!this.categoriasDAO.AgregarCategoria(this.txtCategoria.Text))
                        throw new AgregarDatoSQLException("No se ha podido guardar la nueva categoria, reintente1");

                    this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    this.guna2MessageDialog1.Show("Se ha guardado la categoria correctamente!", "Información");

                    this.DialogResult = DialogResult.OK;//-->Todo OK
                    this.Close();//-->Cierro el form
                }
                catch(AgregarDatoSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer agregar la nueva categoria.", "Error");
                }
            }
        }
        #endregion

        #region OTROS EVENTOS
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
