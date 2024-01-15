using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarjeta
    {
        #region ATRIBUTOS
        private string _entidadEmisora;
        private string _titular;
        private string _numeroTarjeta;//16 numeros
        private string _cvv;//4 numeros mas importantes
        private DateTime _fechaVencimiento;
        private double _dineroDisponible;
        private bool _esDebito;//-->Puede ser debito o credito
        #endregion

        #region PROPIEDADES
        public DateTime FechaVencimiento { get { return this._fechaVencimiento; } set { this._fechaVencimiento = value; } }
        public string CVV { get { return this._cvv; } set { this._cvv = value; } }
        public string NumeroTarjeta { get { return this._numeroTarjeta; } set { this._numeroTarjeta = value; } }
        public string EntidadEmisora { get { return this._entidadEmisora; } set { this._entidadEmisora = value; } }
        public string Titular { get { return this._titular; } set { this._titular = value; } }
        public double DineroDisponible { get { return this._dineroDisponible; } set { this._dineroDisponible = value; } }
        public bool EsDebito { get { return this._esDebito; } set { this._esDebito = value; } }
        #endregion 

        #region CONSTRUCTOR
        /// <summary>
        /// Este constructor privado me permite crear una instancia de tarjeta por defecto. 
        /// </summary>
        private Tarjeta()
        {
            this._fechaVencimiento = DateTime.Now;
            this._titular = "AAAA AAAA";
            this._cvv = "6666";
            this._numeroTarjeta = "1234";
            this._entidadEmisora = "Banco Nación";
            this._dineroDisponible = 00;
            this._esDebito = true;
        }

        /// <summary>
        /// Constructor parametrizado de la clase Tarjeta, me permite crear una instancia
        /// con valores.
        /// </summary>
        /// <param name="vencimiento"></param>
        /// <param name="titular"></param>
        /// <param name="cvv"></param>
        /// <param name="numeroTarjeta"></param>
        /// <param name="entidadEmisora"></param>
        /// <param name="saldo"></param>
        public Tarjeta(DateTime vencimiento, string titular, string cvv, string numeroTarjeta,
            string entidadEmisora, double saldo, bool esDebito)
        {
            this._fechaVencimiento = vencimiento;
            this._titular = titular;
            this._cvv = cvv;
            this._numeroTarjeta = numeroTarjeta;
            this._entidadEmisora = entidadEmisora;
            this._dineroDisponible = saldo;
            this._esDebito = esDebito;
        }
        #endregion

        #region METODOS 
        /// <summary>
        /// Este metodo estatico me permite verificar si la tarjeta
        /// es valida, mediante su numero (cant digitos), su fecha de vencimiento
        /// y si tiene saldo disponible.
        /// </summary>
        /// <param name="tarjetaValidar"></param>
        /// <returns>Retornara true si es valida, false sino.</returns>
        public static bool ValidarTarjeta(Tarjeta tarjetaValidar)
        {
            bool esValida = true;//Como inicio presupongo que es valida. 

            if (tarjetaValidar != null)
            {
                if (tarjetaValidar._numeroTarjeta.Length < 16 ||
                    tarjetaValidar._numeroTarjeta.Length > 16 ||
                    tarjetaValidar._dineroDisponible <= 0 ||
                    tarjetaValidar._fechaVencimiento < DateTime.Now ||
                    tarjetaValidar._cvv.Length < 4 || tarjetaValidar._cvv.Length > 4)
                {
                    esValida = false;
                }
            }
            return esValida;
        }
        #endregion

        #region SOBRECARGA
        /// <summary>
        /// Dos tarjetas seran iguales si tienen el mismo numero y titular.
        /// </summary>
        /// <param name="tarjeta1"></param>
        /// <param name="tarjeta2"></param>
        /// <returns></returns>
        public static bool operator ==(Tarjeta tarjeta1, Tarjeta tarjeta2)
        {
            bool sonIguales = false;
            if (!(tarjeta1 is null) && !(tarjeta2 is null))
            {
                sonIguales = (tarjeta1._titular == tarjeta2._titular) &&
                             (tarjeta1._numeroTarjeta == tarjeta2._numeroTarjeta);
            }
            return sonIguales;
        }

        public static bool operator !=(Tarjeta tarjeta1, Tarjeta tarjeta2)
        {
            return !(tarjeta1 == tarjeta2);
        }
        #endregion

        #region POLIMORFISMO
        /// <summary>
        /// Sobrecarga del .ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this._entidadEmisora}-{this._titular}-{this._fechaVencimiento}-" +
                $"{this._numeroTarjeta}-{this._cvv}-{this._dineroDisponible}-{this._esDebito}";
        }

        /// <summary>
        /// Compara si el objeto this actual es igual al pasaddo por parametro
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Tarjeta)
            {
                retorno = this == ((Tarjeta)obj);
            }
            return retorno;
        }

        /// <summary>
        /// Valor Hash del objeto
        /// </summary>
        /// <returns>Valor Hash del objeto</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
