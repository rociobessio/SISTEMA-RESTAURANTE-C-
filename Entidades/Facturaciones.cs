using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Facturaciones
    {
        #region ATRIBUTOS
        private int _id;
        private string _metodoPago;
        private double _total;
        private double _recibido;
        private double _cambio;
        private DateTime _fechaFacturacion;
        private bool _pagada;
        private string _codPedido;
        #endregion

        #region PROPIEDADES
        public int ID { get { return this._id; } set { this._id = value; } }
        public string MetodoPago { get {  return this._metodoPago; } set { this._metodoPago = value; } }
        public double Total { get { return this._total; } set { this._total = value; } }
        public double Cambio { get { return this._cambio; } set { this._cambio = value; } }
        public double Recibido { get { return this._recibido; } set { this._recibido = value; } }
        public DateTime FechaFacturacion { get { return this._fechaFacturacion; } set { this._fechaFacturacion = value; } }
        public bool Pagado { get { return this._pagada; } set { this._pagada = value; } }
        public string CodigoPedido { get { return this._codPedido; } set { this._codPedido = value; } }
        #endregion

        #region CONSTRUCTORES
        public Facturaciones()
        {
            this._recibido = 0;
            this._cambio = 0;
            this.MetodoPago = "";
            this.Total = 0;
        }
        public Facturaciones(string metodo,double total,DateTime fechaFacturacion,bool pagado,string codPedido)
            : this()
        {
            this._metodoPago = metodo;
            this._total = total;
            this._fechaFacturacion = fechaFacturacion;
            this._pagada = pagado;
            this._codPedido = codPedido;
        }

        public Facturaciones(int id,string metodo, double total, DateTime fechaFacturacion, bool pagado, string codPedido)
            : this(metodo,total,fechaFacturacion,pagado,codPedido)
        {
            this._id = id;
        }

        public Facturaciones(string metodo, double total, DateTime fechaFacturacion, bool pagado, string codPedido,
            double recibido, double cambio)
            : this(metodo, total, fechaFacturacion, pagado, codPedido)
        {
            this._recibido = recibido;
            this._cambio = cambio;
        }

        public Facturaciones(int id,string metodo, double total, DateTime fechaFacturacion, bool pagado, string codPedido,
            double recibido, double cambio)
            : this(metodo, total, fechaFacturacion, pagado, codPedido,recibido,cambio)
        {
            this._id = id;
        }  
        #endregion
    }
}
