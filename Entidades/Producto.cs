using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;//-->Implemento la biblioteca de entidades.

namespace Entidades
{
    /// <summary>
    /// Clase Producto.
    /// </summary>
    public class Producto
    {
        #region ATRIBUTOS
        private int _idProducto;
        private string _nombre;
        private Sectores _sector;
        private Tipo _tipo;
        #endregion

        #region PROPIEDADES
        public int IDProducto { get { return this._idProducto; } set { if (value >= 0) this._idProducto = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public Sectores Sector { get { return this._sector; } set { this._sector = value; } }
        public Tipo Tipo { get { return this._tipo; } set { this._tipo = value; } }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor de la Entidad Producto
        /// </summary>
        /// <param name="nombre">El nombre del Producto</param>
        /// <param name="sector">El sector del Producto</param>
        /// <param name="tipo">El Tipo del Producto.</param>
        public Producto(string nombre, Sectores sector, Tipo tipo)
        {
            this._nombre = nombre;
            this._sector = sector;
            this._tipo = tipo;
        }

        /// <summary>
        /// Sobrecarga del Constructor de la clase Producto.
        /// </summary>
        /// <param name="id">ID Del Producto.</param>
        /// <param name="nombre"></param>
        /// <param name="sector"></param>
        /// <param name="tipo"></param>
        public Producto(int id, string nombre, Sectores sector, Tipo tipo)
            : this(nombre, sector, tipo)
        {
            this._idProducto = id;
        }
        #endregion

    }
}
