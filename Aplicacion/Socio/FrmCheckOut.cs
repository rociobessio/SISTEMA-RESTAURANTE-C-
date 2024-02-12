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
using Guna.UI2.WinForms;

namespace Aplicacion.Socio
{
    public partial class FrmCheckOut : FrmSampleAdd
    {
        #region ATRIBUTOS
        public double total;
        public int ID;
        private string codPedido;
        private double recibido;
        private double cambio;
        private Pedido pedido;
        public int idFacturacion;
        public bool pudoPagar = false;
        #endregion

        #region CONTRUCTOR
        public FrmCheckOut()
        {
            InitializeComponent();

            //-->Formateo el datetimepicker
            this.dtpVencimientoTarjeta.CustomFormat = "dd/MM/yyyy";
            this.dtpVencimientoTarjeta.Format = DateTimePickerFormat.Custom;

            #region DESHABILITO EL INGRESO DE DATOS:
            this.txtRecibido.Enabled = false;
            this.txtCambio.Enabled = false;
            this.txtTotal.Enabled = false;//-->Para que no modifique el total.
            this.DeshabilitarDatosTarjeta();
            #endregion

            foreach (EntidadesBancarias entidades in Enum.GetValues(typeof(EntidadesBancarias)))
            {
                this.cbEntidad.Items.Add(entidades);
            }
        }

        public FrmCheckOut(string codPedido)
            : this()
        {
            this.codPedido = codPedido;
            this.lblCodPedido.Text = codPedido;

            //-->Obtengo el pedido:
            this.pedido = new PedidoDAO().ObtenerPedidoPorCodigoPedido(codPedido);
            this.txtTotal.Text = pedido.TotalPedido.ToString();
        }
        #endregion

        #region METODOS
        private void DeshabilitarDatosTarjeta()
        {
            this.txtNroTarjeta.Enabled = false;
            this.txtTitular.Enabled = false;
            this.dtpVencimientoTarjeta.Enabled = false;
            this.cbEntidad.Enabled = false;
            this.txtNroCVV.Enabled = false;
        }

        private void HabilitarDatosTarjeta()
        {
            this.txtNroTarjeta.Enabled = true;
            this.txtTitular.Enabled = true;
            this.dtpVencimientoTarjeta.Enabled = true;
            this.cbEntidad.Enabled = true;
            this.txtNroCVV.Enabled = true;
        }
        #endregion

        #region VALIDACIONES
        private bool ValidarInput()
        {
            bool valid = true;
            double efectivo = 0;
            double.TryParse(this.txtRecibido.Text, out efectivo);

            if (this.rbEfectivo.Checked)//-->Efectivo seleccionado
            {
                if (string.IsNullOrEmpty(this.txtRecibido.Text) || efectivo <= 0)
                {
                    valid = false;
                }
            }

            //-->Valido datos tarjeta:
            if (this.rbTarjetaDebito.Checked)
            {
                if (string.IsNullOrEmpty(this.txtNroTarjeta.Text) || string.IsNullOrEmpty(this.txtTitular.Text) ||
                    string.IsNullOrEmpty(this.txtNroCVV.Text) || this.cbEntidad.SelectedIndex < -1 ||
                    this.dtpVencimientoTarjeta.Value < DateTime.Now)
                    valid = false;
            }

            return valid;
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtNroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtNroCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloNumeros(sender, e);
        }

        private void txtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmLogin.SoloLetras(sender, e);
        }
        #endregion

        #region OTROS
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxMetodoPago_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTotal_TextChanged_1(object sender, EventArgs e)
        {
            double.TryParse(this.txtTotal.Text, out this.total);
            double.TryParse(this.txtRecibido.Text, out this.recibido);

            this.cambio = Math.Abs(total - recibido);

            this.txtCambio.Text = cambio.ToString();
        }
        private void groupBoxTarjeta_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region EVENTOS
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(this.txtTotal.Text, out this.total);
            double.TryParse(this.txtRecibido.Text, out this.recibido);

            this.cambio = total - recibido;

            this.txtCambio.Text = cambio.ToString();
        }

        /// <summary>
        /// Si selecciono pagar con tarjeta entonces
        /// habilito los controles con el ingreso
        /// de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTarjetaDebito_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbTarjetaDebito.Checked)
            {
                this.HabilitarDatosTarjeta();
                this.txtRecibido.Enabled = false;
            }
            else
                this.DeshabilitarDatosTarjeta();
        }

        /// <summary>
        /// Si selecciono efectivo imprimo el cambio
        /// que recibira el cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbEfectivo.Checked)
            {
                this.txtRecibido.Enabled = true;
            }
            else
                this.DeshabilitarDatosTarjeta();
        }
        #endregion


        #region BOTONES
        public override void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarInput() && !string.IsNullOrEmpty(this.codPedido))
                {
                    if (!this.pedido.PedidoPagado)
                    {
                        
                        if (this.rbTarjetaDebito.Checked)//-->Si es con tarjeta
                        {
                            if (!Tarjeta.ValidarTarjeta(new Tarjeta(this.dtpVencimientoTarjeta.Value, this.txtTitular.Text,
                                this.txtNroCVV.Text, this.txtNroTarjeta.Text, this.cbEntidad.SelectedItem.ToString(), true)))
                                throw new TarjetaNOValidaException("Tarjeta Ingresada NO valida, reintente!");

                            if (!new FacturacionesDAO().AgregarFacturacionRetornarID(new Facturaciones(MetodosPago.Tarjeta_Debito.ToString().Replace("_", " "),
                                this.total, DateTime.Now, true, this.codPedido),out idFacturacion))
                                throw new AgregarDatoSQLException("No se ha podido generar la facturación, reintente!");
                        }

                        if (this.rbEfectivo.Checked)//-->Si es con Efectivo
                        {
                            if (!new FacturacionesDAO().AgregarFacturacionRetornarID(new Facturaciones(MetodosPago.Efectivo.ToString().Replace("_", " "),
                                this.total, DateTime.Now, true, this.codPedido, this.recibido, this.cambio),out idFacturacion))
                                throw new AgregarDatoSQLException("No se ha podido generar la facturación, reintente!");
                        }

                        //-->Cambio el Estado del pedido a pagado. Ya que lo puede abonar en cualquier momento.
                        this.pedido.PedidoPagado = true;
                        if (!new PedidoDAO().UpdateDato(this.pedido))
                            throw new UpdateSQLException("No se ha podido pagar el pedido, reintente!");

                        this.guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                        this.guna2MessageDialog1.Caption = "Información";
                        this.guna2MessageDialog1.Show("Facturación generada correctamente!");
                        this.pudoPagar = true;
                    }
                    else
                    {
                        this.guna2MessageDialog1.Caption = "Error";
                        this.guna2MessageDialog1.Show("El pedido ya ha sido pagado!");
                    }
                }
                else
                    this.guna2MessageDialog1.Show("Error en el ingreso de datos, reintente!");
            }
            catch (UpdateSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message);
            }
            catch (AgregarDatoSQLException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message);
            }
            catch (TarjetaNOValidaException ex)
            {
                this.guna2MessageDialog1.Show(ex.Message);
            }
            catch (Exception)
            {
                this.guna2MessageDialog1.Caption = "Error";
                this.guna2MessageDialog1.Show("Ocurrio un error dentro de la aplicacion!");
            }
        }
        #endregion



    }
}
