using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        #region ATRIBUTOS
        private int _idUsuario;
        private string _email;
        private string _contrasenia;
        private DateTime _horaIngresoApp;
        private bool _esCliente;
        #endregion

        #region PROPIEDADES
        public int IDUsuario { get { return this._idUsuario; } }
        /// <summary>
        /// Esta propiedad de lectura me permitira imprimir en los textboxes
        /// la contrasenia.
        /// </summary>
        public string Contrasenia { get { return this._contrasenia; } set { this._contrasenia = value; } }
        /// <summary>
        /// Esta propiedad de lectura me permitira imprimir en los textboxes
        /// el email.
        /// </summary>
        public string Email { get { return this._email; } set { this._email = value; } }
        public DateTime HoraIngreso { get { return this._horaIngresoApp; } }
        public bool EsCliente { get { return this._esCliente; } set { this._esCliente = value; } }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor parametrizado de la clase Usuario.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contrasenia"></param>
        public Usuario(string email, string contrasenia)
        {
            this._horaIngresoApp = DateTime.Now;
            this._email = email;
            this._contrasenia = contrasenia;
        }

        /// <summary>
        /// Sobrecarga del constructor.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contrasenia"></param>
        /// <param name="esCliente"></param>
        /// <param name="idPersona"></param>
        /// <param name="idCliente"></param>
        public Usuario(string email, string contrasenia, bool esCliente)
            : this(email, contrasenia)
        {
            this._esCliente = esCliente;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Operador implicito que me devuelve el email de la persona.
        /// </summary>
        /// <param name="persona"></param>
        public static implicit operator string(Usuario user)
        {
            return user.Email;
        }
        /// <summary>
        /// Dos usuarios seran iguales si comparten email y contraseña
        /// </summary>
        /// <param name="usuario1"></param>
        /// <param name="usuario2"></param>
        /// <returns>True si lo son, false sino</returns>
        public static bool operator ==(Usuario usuario1, Usuario usuario2)
        {
            return ((usuario1._email == usuario2._email) && (usuario1._contrasenia == usuario2._contrasenia));
        }

        public static bool operator !=(Usuario usuario1, Usuario usuario2)
        {
            return !(usuario1 == usuario2);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Cambio el metodo por un booleano.
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="userRecibido"></param>
        /// <returns></returns>
        public static bool esValidoElUsuario(List<Usuario> usuarios, Usuario userRecibido)
        {
            bool pudo = false;
            foreach (Usuario usuario in usuarios)
            {
                if (usuario == userRecibido)
                {
                    return true;
                }
            }
            return pudo;
        }
        #endregion

        #region POLIMORFISMO
        /// <summary>
        /// Sobrecarga del .ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" email: {this._email} - contraseña: {this._contrasenia}";
        }

        /// <summary>
        /// Compara si el objeto this actual es igual obj del parametro comparando por la sobrecarga del ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Usuario)
            {
                retorno = this == ((Usuario)obj);
            }
            return retorno;
        }

        /// <summary>
        /// Codigo Hash del objeto, es unico.
        /// </summary>
        /// <returns>Codigo Hash del objeto</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
