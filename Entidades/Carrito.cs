using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrito
    {
        #region ATRIBUTOS 
        private DateTime _fechaCompra;
        private double _precioTotal;
        private bool _conTarjeta;
        private List<Producto> _listaDeProductos;
        private string _usuarioCompra;
        private static int ultimoCodigo;
        #endregion

        #region PROPIEDADES
        public string UsuarioCompra { get { return this._usuarioCompra; } set { this._usuarioCompra = value; } }
        /// <summary>
        /// Propiedad de lectura que me permite obtener la fecha de compra.
        /// </summary>
        public DateTime FechaCompra { get { return this._fechaCompra; } set { this._fechaCompra = value; } }
        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public double PrecioTotal { get { return this._precioTotal; } set { this._precioTotal = value; } }
        /// <summary>
        /// Propiedad de escritura y lectura, me permite saber si la compra/venta se realizo con
        /// Tarjeta.
        /// </summary>
        public bool ConTarjeta { get { return this._conTarjeta; } set { this._conTarjeta = value; } }
        /// <summary>
        /// Propiedad de escritura y lectura de la Lista de Productos.
        /// </summary>
        public List<Producto> Productos { get { return this._listaDeProductos; } set { this._listaDeProductos = value; } }
        #endregion

        #region CONSTRUCTOR 

        /// <summary>
        /// Este constructor inicializa todos los parametros
        /// </summary>
        public Carrito()
        {
            this._conTarjeta = false;
            this._fechaCompra = DateTime.Today;
            this._precioTotal = 00;
            this._listaDeProductos = new List<Producto>();
        }

        /// <summary>
        /// Constructor de la clase Carrito que me permite crear una instacia del objeto
        /// parametrizado.
        /// parametrizado. 
        /// </summary>
        /// <param name="compra"></param>
        /// <param name="precioTotal"></param>
        /// <param name="tarjeta"></param>
        /// <param name="productos"></param>
        public Carrito(DateTime compra, double precioTotal, List<Producto> productos, bool tarjeta)
            : this()
        {
            this._conTarjeta = tarjeta;
            this._fechaCompra = compra;
            this._precioTotal = precioTotal;
            this._listaDeProductos = productos;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// La sobrecarga del operador + me permite añadir un producto al carrito si este no se encuentra
        /// ya contenido en el.
        /// Utilizo la sobrecarga del == de Carne.
        /// </summary>
        /// <param name="carrito"></param>
        /// <param name="carne"></param>
        /// <returns>Devuelve true si pudo añadirlo, false sino.</returns>
        public static bool operator +(Carrito carrito, Producto carne)
        {
            bool puede = true;
            if (!(carrito is null) && !(carne is null))
            {
                if (!carrito._listaDeProductos.Contains(carne))
                {
                    carrito._listaDeProductos.Add(carne);
                    puede = true;
                }
            }
            return puede;
        }
        #endregion

        /// <summary>
        /// Valor Hash del objeto, es unico
        /// </summary>
        /// <returns>Valor Hash del objeto</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
