using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoProducto
    {
        #region ATRIBUTOS
        private int _idPedidoProducto;
        private string _codPedido;//-->El pedido de identifica x su codigo
        private int _idProducto;
        private string _estado;//-->A nivel TOTAL del pedido.
        private int _idEmpleado;//-->El empleado a cargo del pedido
        private int _cantidadProducto;
        #endregion

        #region PROPIEDADES
        public int IDPedProd { get { return this._idPedidoProducto; } set { this.IDPedProd = value; } }
        public string CodigoPedido { get { return this._codPedido; } set { this._codPedido = value; } }
        public int IDProducto { get { return this._idProducto; } set { this._idProducto = value; } }
        public string Estado { get { return this._estado; } set { this._estado = value; } }
        public int IDEmpleado { get { return this._idEmpleado; } set { this._idEmpleado = value;} }
        public int Cantidad { get { return this._cantidadProducto; } set { this._cantidadProducto = value; } }
        #endregion

        #region CONSTRUCTORES
        public PedidoProducto(string codPedido,int IDProd,string estado,int cantidad)
        {
            this._codPedido = codPedido;
            this._idProducto=IDProd;
            this._estado = estado;
            this._cantidadProducto = cantidad;
        }

        public PedidoProducto(int id,string codPedido, int IDProd, string estado,int cantidad)
            : this(codPedido,IDProd,estado,cantidad)
        {
            this._idProducto = IDProd;
        }

        public PedidoProducto(int id, string codPedido, int IDProd, string estado,int idEmpleado,int cantidad)
            : this(id,codPedido, IDProd, estado, cantidad)
        {
            this._idEmpleado =idEmpleado;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        public static bool operator ==(PedidoProducto pd,Producto prod)
        {
            return (pd.IDProducto == prod.IDProducto);
        }

        public static bool operator !=(PedidoProducto pd, Producto prod)
        {
            return !(pd == prod);
        }
        #endregion
    }
}
