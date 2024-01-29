using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mesa
    {
        #region ATRIBUTOS
        private int _idMesa;
        private string _estado;
        private string _codigoMesa;
        #endregion

        #region PROPIEDADES
        public int IDMesa { get { return _idMesa; } set { this._idMesa = value; } }
        public string CodigoMesa { get { return _codigoMesa; } set {  _codigoMesa = value; } }
        public string Estado { get { return this._estado; } set { this._estado = value; } }
        #endregion

        #region CONSTRUCTORES
        public Mesa()
        {
            this._idMesa = 0;
            this._codigoMesa = Herramientas.CrearCodigo(5);
            this._estado = "Cerrada";
        }

        public Mesa(string codigo,string estado)
        {
            this._estado = estado;
            this._codigoMesa = codigo;
        }

        public Mesa(int id,string codigo,string estado)
            :this(codigo,estado)
        {
            this._idMesa = id;
        }
        #endregion
    }
}
