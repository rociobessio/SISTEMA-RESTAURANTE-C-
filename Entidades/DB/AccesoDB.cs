using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class AccesoDB
    {
        #region ATRIBUTOS
        protected SqlConnection _conexion;
        protected SqlCommand _comando;
        protected SqlDataReader _lector;
        protected static string _cadenaDeConexion;
        #endregion

        #region PROPIEDAD
        /// <summary>
        /// Propiedad estatica de lectura y escritura
        /// sobre mi atributo _cadenaDeConexion.
        /// </summary>
        public static string CadenaDeConexion { get { return AccesoDB._cadenaDeConexion; } set { AccesoDB._cadenaDeConexion = value; } }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Se ejecutara una sola vez el
        /// constructor estatico, obteniendo 
        /// la cadena de conexion a la DB.
        /// </summary>
        static AccesoDB()
        {
            AccesoDB._cadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Restaurante;Data Source=DESKTOP-S8KBDM2;Trusted_Connection=True;";
        }

        /// <summary>
        /// Constructor sin parametros que le
        /// pasa al SQLConnection la cadena de 
        /// conexion.
        /// </summary>
        public AccesoDB()
        {
            this._conexion = new SqlConnection(AccesoDB._cadenaDeConexion);
        }

        /// <summary>
        /// Constructor parametrizado que me servirá para 
        /// comprobar el unit testing de la clase.
        /// </summary>
        /// <param name="cadena"></param>
        public AccesoDB(string cadena)
        {
            this._conexion = new SqlConnection(cadena);
        }
        #endregion

        #region METODO
        /// <summary>
        /// Metodo de prueba para la conexion a 
        /// base de datos.
        /// </summary>
        /// <returns></returns>
        public bool ProbarConexion()
        {
            bool pudoConectar = true;

            try
            {
                this._conexion.Open();
            }
            catch (Exception)
            {
                pudoConectar = false;
            }
            finally
            {
                if (this._conexion.State == System.Data.ConnectionState.Open)
                {
                    this._conexion.Close();
                }
            }
            return pudoConectar;
        }


        #endregion
    }
}
