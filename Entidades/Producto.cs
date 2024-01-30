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
        private DateTime _fechaBaja;
        private TimeSpan _tiempoEstimadoPreparacion;
        private double _precio;
        private int _categoria;
        private Byte[] _imagen;
        #endregion

        #region PROPIEDADES
        public int IDProducto { get { return this._idProducto; } set { if (value >= 0) this._idProducto = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public Sectores Sector { get { return this._sector; } set { this._sector = value; } }
        public Tipo Tipo { get { return this._tipo; } set { this._tipo = value; } }
        public double Precio { get { return this._precio; } set { this._precio = value; } }
        public int Categoria { get { return this._categoria; } set { this._categoria = value; } }
        public Byte[] Imagen { get { return this._imagen; } set { this._imagen = value; } }
        public DateTime FechaBaja { get { return this._fechaBaja; } set { this._fechaBaja = value; } }
        public TimeSpan TiempoEstimadoPreparacion { get { return this._tiempoEstimadoPreparacion; } set { this._tiempoEstimadoPreparacion = value; } }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor de la Entidad Producto
        /// </summary>
        /// <param name="nombre">El nombre del Producto</param>
        /// <param name="sector">El sector del Producto</param>
        /// <param name="tipo">El Tipo del Producto.</param>
        public Producto(string nombre, Sectores sector, Tipo tipo, TimeSpan tiempoEstimado, double precio,int idCategoria, Byte[] img)
        {
            this._nombre = nombre;
            this._sector = sector;
            this._tipo = tipo;
            this._tiempoEstimadoPreparacion = tiempoEstimado;
            this._precio = precio;
            this._categoria = idCategoria;
            this._imagen = img;
        }

        public Producto(string nombre, Sectores sector, Tipo tipo, TimeSpan tiempoEstimado, DateTime fBaja, double precio, int idCategoria, Byte[] img)
            :this(nombre,sector,tipo,tiempoEstimado,precio, idCategoria,img)
        {
            this._fechaBaja = fBaja;
        }

        /// <summary>
        /// Sobrecarga del Constructor de la clase Producto.
        /// </summary>
        /// <param name="id">ID Del Producto.</param>
        /// <param name="nombre"></param>
        /// <param name="sector"></param>
        /// <param name="tipo"></param>
        public Producto(int id, string nombre, Sectores sector, Tipo tipo,TimeSpan tiempoEstimado, double precio,int idCategoria, Byte[] img)
            : this(nombre, sector, tipo,tiempoEstimado, precio,idCategoria, img)
        {
            this._idProducto = id;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Me permitira asignar el sector
        /// dependiendo del rol.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static string ValidarPedido(string rol)
        {
            string sector = "vacio";
            switch (rol)
            {
                case "Bartender":
                    sector = "Barra";
                    break;
                case "Cervezero":
                    sector = "Cerveceria";
                    break;
                case "Cocinero":
                    sector = "Cocina";
                    break;
                case "Candybar"://-->Pastelero no esta certificado en el enunciado
                    sector = "CandyBar";
                    break;
                case "Vinoteca":
                    sector = "Vinoteca";
                    break;
                }
                return sector;
            }
        #endregion

        }
}
