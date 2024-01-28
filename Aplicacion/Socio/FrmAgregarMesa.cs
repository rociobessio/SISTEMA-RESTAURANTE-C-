using Entidades;
using Entidades.DB;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Socio
{
    public partial class FrmAgregarMesa : FrmSampleAdd
    {
        #region ATRIBUTOS
        private MesaDAO mesaDAO;
        private int id;
        #endregion

        #region CONSTRUCTORES
        public FrmAgregarMesa()
        {
            InitializeComponent();
            this.id = 0;
            this.mesaDAO = new MesaDAO();

            //-->Cargo los enumerados.
            var estados = Enum.GetValues(typeof(Estados))
                              .Cast<Estados>()
                              .Select(e => e.ToString().Replace("_", " "))
                              .ToList();
            this.cbEstadoMesa.DataSource = estados;
        }

        public FrmAgregarMesa(int id,string codigo)
            : this()
        {
            this.id = id;
            this.txtCodigoMesa.Text = codigo;
            //-->Habilito el cb y txt, ya que en el const por defecto sera para dar de alta
            this.cbEstadoMesa.Enabled = true;
            this.txtCodigoMesa.Enabled = true;
        }
        #endregion

        #region OTROS EVENTOS
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        #region BOTONES
        public override void btnGuardar_Click(object sender, EventArgs e)
        {
            if(this.id > 0)//-->Se modifica
            {
                try
                {
                    if (!this.mesaDAO.UpdateDato(this.id, this.cbEstadoMesa.SelectedItem.ToString(), this.txtCodigoMesa.Text))
                        throw new UpdateSQLException("No se ha podido modificar la mesa, reintente!");

                    this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    this.guna2MessageDialog1.Show("Se ha modificado la mesa correctamente!", "Información");

                    this.DialogResult = DialogResult.OK;//-->Todo OK
                    this.Close();//-->Cierro el form
                }
                catch (UpdateSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer modificar mesa.", "Error");
                }
            }
            else//-->Nueva Mesa
            {
                try
                {
                    if (!this.mesaDAO.AgregarDato(new Mesa(Herramientas.CrearCodigo(5),
                        Estados.Cerrada.ToString())))
                        throw new AgregarDatoSQLException("No se ha podido agregar la mesa, reintente!");

                    this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    this.guna2MessageDialog1.Show("Se ha guardado la mesa correctamente!", "Información");

                    this.DialogResult = DialogResult.OK;//-->Todo OK
                    this.Close();//-->Cierro el form
                }
                catch(AgregarDatoSQLException ex)
                {
                    this.guna2MessageDialog1.Show(ex.Message, "Error");
                }
                catch (Exception)
                {
                    this.guna2MessageDialog1.Show("Ocurrio un error al querer agregar la nueva mesa.", "Error");
                }
            }
        }


        #endregion
    }
}
