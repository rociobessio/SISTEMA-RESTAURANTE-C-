using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClientePedido
    {
        #region ATRIBUTOS
        private int _idClientePedido;
        private string _codigoPedido;
        private int _idCliente;
        #endregion

        #region CONSTRUCTORES
        public ClientePedido(string codPedido,int idCliente)
        {
            this._codigoPedido = codPedido;
            this._idCliente = idCliente;
        }

        public ClientePedido(int id,string codPedido, int idCliente)
            :this(codPedido,idCliente)
        {
            this._idClientePedido = id;
        }
        #endregion

        #region PROPIEDADES
        public int IDClientePedido { get { return _idClientePedido; } set { this._idClientePedido= value; } }
        public string CodigoPedido { get { return this._codigoPedido; } set { this._codigoPedido = value; } }
        public int IDCliente { get { return this._idCliente; } set { this._idCliente = value; } }
        #endregion
    }
}
