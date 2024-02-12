using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Delivery
    {
        #region ATRIBUTOS
        private int _idDelivery;
        private string _direccion;
        private int _idPedido;
        private int _idFacturacion;
        private int _idConductor;
        #endregion

        #region PROPIEDADES
        public int IDDelivery { get { return _idDelivery; } set { _idDelivery = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public int IDPedido { get {  return _idPedido; } set { this._idPedido = value; } }
        public int IDFacturacion { get { return _idFacturacion; } set { this._idFacturacion = value; } }
        public int IDConductor { get { return _idConductor;} set { this._idConductor = value;} }
        #endregion

        #region CONSTRUCTOR
        public Delivery(string direccion,int idPedido,int idFacturacion,int idCOnductor)
        {
            this._direccion = direccion;
            this._idPedido = idPedido;
            this._idFacturacion = idFacturacion;
            this._idConductor = idCOnductor;
        }

        public Delivery(int id,string direccion, int idPedido, int idFacturacion, int idCOnductor)
            : this(direccion,idPedido,idFacturacion,idCOnductor)
        {
            this._idDelivery = id;
        }
        #endregion
    }
}
