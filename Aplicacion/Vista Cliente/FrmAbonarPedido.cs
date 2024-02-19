using Aplicacion.Socio;
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

namespace Aplicacion.Vista_Cliente
{
    public partial class FrmAbonarPedido : FrmSampleAdd
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
        private Tarjeta tarjeta;
        private bool esConTarjeta;
        private string direccionPedido;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Me permitira obtener la tarjeta cargada
        /// para luego preguntar si quiere guardar sus datos.
        /// </summary>
        public Tarjeta Tarjeta { get { return this.tarjeta; } }
        public bool EsConTarjeta { get { return this.esConTarjeta; } }
        public string Direccion { get { return this.txtDireccionPedido.Text; } }
        #endregion


        #region CONSTRUCTORES
        public FrmAbonarPedido()
        {
            InitializeComponent();


            //-->Formateo el datetimepicker
            this.dtpVencimientoTarjeta.CustomFormat = "dd/MM/yyyy";
            this.dtpVencimientoTarjeta.Format = DateTimePickerFormat.Custom;

            this.esConTarjeta = false;
            this.tarjeta = new Tarjeta();

            #region DESHABILITO EL INGRESO DE DATOS:
            this.txtRecibido.Enabled = false;
            this.txtCambio.Enabled = false;
            this.txtTotal.Enabled = false;//-->Para que no modifique el total.
            this.DeshabilitarDatosTarjeta();
            this.dtpVencimientoTarjeta.Enabled = true;
            #endregion

            foreach (EntidadesBancarias entidades in Enum.GetValues(typeof(EntidadesBancarias)))
            {
                this.cbEntidad.Items.Add(entidades);
            }
        }

        public FrmAbonarPedido(string codPedido,Entidades.Cliente cliente)
            : this()
        {
            this.codPedido = codPedido;
            this.lblCodPedido.Text = codPedido;

            //-->Obtengo el pedido:
            this.pedido = new PedidoDAO().ObtenerPedidoPorCodigoPedido(codPedido);
            this.txtTotal.Text = pedido.TotalPedido.ToString();
            this.tarjeta = cliente.Tarjeta;
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
            this.btnCargarTarjeta.Enabled = false;
        }

        private void HabilitarDatosTarjeta()
        {
            this.txtNroTarjeta.Enabled = true;
            this.txtTitular.Enabled = true;
            this.dtpVencimientoTarjeta.Enabled = true;
            this.cbEntidad.Enabled = true;
            this.txtNroCVV.Enabled = true;
            this.btnCargarTarjeta.Enabled = true;
        }

        /// <summary>
        /// Me permitira abstraer la logica para 
        /// pagar con tarjeta.
        /// </summary>
        /// <exception cref="TarjetaNOValidaException"></exception>
        /// <exception cref="AgregarDatoSQLException"></exception>
        private void GenerarPagoConTarjeta(Tarjeta tarjeta)
        {
            this.esConTarjeta = true;
            this.tarjeta = tarjeta;

            if (!Tarjeta.ValidarTarjeta(tarjeta))
                throw new TarjetaNOValidaException("Tarjeta Ingresada NO valida, reintente!");

            if (!new FacturacionesDAO().AgregarFacturacionRetornarID(new Facturaciones(MetodosPago.Tarjeta_Debito.ToString().Replace("_", " "),
                this.total, DateTime.Now, true, this.codPedido), out idFacturacion))
                throw new AgregarDatoSQLException("No se ha podido generar la facturación, reintente!");
        }
        #endregion

        #region VALIDACIONES
        /// <summary>
        /// Me permitira calcular los valores correspondientes
        /// al pago en efectivo.
        /// </summary>
        /// <param name="total"></param>
        /// <param name="recibido"></param>
        /// <param name="cambio"></param>
        private void CalcularMontos(out double total, out double recibido, out double cambio)
        {
            total = 0;
            recibido = 0;
            cambio = 0;
            double.TryParse(this.txtTotal.Text, out total);
            double.TryParse(this.txtRecibido.Text, out recibido);

            cambio = Math.Abs(total - recibido);
        }


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

        #region EVENTOS
        /// <summary>
        /// Ira imprimiendo la diferencia entre
        /// lo que se paga y el total, para asi
        /// mostrar el cambio que se recibira.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(this.txtTotal.Text, out this.total);
            double.TryParse(this.txtRecibido.Text, out this.recibido);

            this.cambio = Math.Abs(this.total - this.recibido);

            this.txtCambio.Text = cambio.ToString();
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbEfectivo.Checked)
            {
                this.txtRecibido.Enabled = true;
            }
            else
                this.DeshabilitarDatosTarjeta();
        }

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
        #endregion

        #region BOTONES
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (this.ValidarInput())
                {
                    if (!this.pedido.PedidoPagado)
                    {

                        if (this.rbTarjetaDebito.Checked)//-->Si es con tarjeta
                        {
                            this.GenerarPagoConTarjeta(new Tarjeta(this.dtpVencimientoTarjeta.Value, this.txtTitular.Text,
                            this.txtNroCVV.Text, this.txtNroTarjeta.Text, this.cbEntidad.SelectedItem.ToString(), true));
                        }

                        if (this.rbEfectivo.Checked)//-->Si es con Efectivo
                        {
                            double total, recibido, cambio;
                            CalcularMontos(out total, out recibido, out cambio);

                            if (!new FacturacionesDAO().AgregarFacturacionRetornarID(new Facturaciones(MetodosPago.Efectivo.ToString().Replace("_", " "),
                                this.total, DateTime.Now, true, this.codPedido, recibido, cambio), out idFacturacion))
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

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Si el cliente tiene un
        /// perfil con una tarjeta creada
        /// podra ahorrarse introducir los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarTarjeta_Click(object sender, EventArgs e)
        {
            if (this.tarjeta.Titular != "AAAA AAAA")//-->Valor por default
            {
                this.txtNroCVV.Text = this.tarjeta.CVV;
                this.txtNroTarjeta.Text = this.tarjeta.NumeroTarjeta;
                this.txtTitular.Text = this.tarjeta.Titular;
                this.dtpVencimientoTarjeta.Value = this.tarjeta.FechaVencimiento;
                this.cbEntidad.SelectedItem = this.tarjeta.EntidadEmisora;
            }
            else
            {
                this.guna2MessageDialog1.Show("No tiene una tarjeta registrada!","Información");
            }
        }
        #endregion

    }
}
