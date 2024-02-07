using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        #region ATRIBUTOS
        private int _id;
        private string _codPedido;
        private string _estado;
        private TimeSpan _tiempoEstimadoPreparacion;
        private TimeSpan _tiempoInicio;
        private TimeSpan _tiempoFinalizacion;
        private bool _pedioFacturado;//-->Sobre si ya fue facturado
        private double _totalPedido;
        private string _tipoOrden;
        private int _IDMesa;
        #endregion

        #region PROPIEDADES
        public int IDPedido { get { return this._id; } set { this._id = value; } }
        public string CodPedido { get { return this._codPedido; } set { this._codPedido = value;} }
        public string Estado { get { return this._estado; }  set { this._estado = value; } }
        public TimeSpan TiempoPreparacionTotal { get { return this._tiempoEstimadoPreparacion; } set { this._tiempoEstimadoPreparacion = value; } }
        public TimeSpan TiempoInicio { get { return this._tiempoInicio; } set { this._tiempoInicio = value; } }
        public TimeSpan TiempoFinalizacion { get { return this._tiempoFinalizacion; } set { this._tiempoFinalizacion = value; } }
        public double TotalPedido { get { return this._totalPedido; } set { this._totalPedido = value; } }
        public bool PedidoPagado { get { return this._pedioFacturado; } set { this._pedioFacturado = value; } }
        public string TipoOrden { get { return this._tipoOrden; } set { this._tipoOrden = value; } }
        public int IDMesa { get { return this._IDMesa; } set { this._IDMesa = value; } }
        #endregion

        #region CONSTRUCTOR
        public Pedido(string cod,string estado,TimeSpan tiempoPreparacionTotal,string tipoOrden,int idMesa, double total)
        {
            this._codPedido = cod;
            this._estado = estado;
            this._tiempoEstimadoPreparacion = tiempoPreparacionTotal;
            this._tipoOrden = tipoOrden;
            this._IDMesa = idMesa;
            this._totalPedido = total;
        }

        public Pedido(string cod, string estado, TimeSpan tiempoPreparacionTotal, string tipoOrden)
        {
            this._codPedido = cod;
            this._estado = estado;
            this._tiempoEstimadoPreparacion = tiempoPreparacionTotal;
            this._tipoOrden = tipoOrden;
        }

        public Pedido(int id, string cod,string estado, TimeSpan tiempoPreparacionTotal, string tipoOrden,int idMesa,
            TimeSpan tiempoInicio,TimeSpan tiempoFin,double total)
            : this (cod,estado,tiempoPreparacionTotal,tipoOrden,idMesa,total)
        {
            this._id = id;
            this._tiempoInicio = tiempoInicio;
            this._tiempoFinalizacion = tiempoFin;
        }

        public Pedido(int id, string cod, string estado, TimeSpan tiempoPreparacionTotal, string tipoOrden, int idMesa,
            TimeSpan tiempoInicio, TimeSpan tiempoFin,double total,bool pagado)
            : this (id,cod, estado, tiempoPreparacionTotal,tipoOrden,idMesa,tiempoInicio,tiempoFin,total)
        {
            this._pedioFacturado = pagado;
        }
        #endregion

        #region METODOS

        #endregion
    }
}
