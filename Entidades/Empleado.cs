using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Empleado.
    /// </summary>
    public class Empleado : Persona
    {
        #region ATRIBUTOS
        private int _idEmpleado;
        private Rol _rol;
        private DateTime _fechaAlta;
        private DateTime _fechaBaja;
        private Usuario _usuario;
        #endregion

        #region PROPIEDADES
        public int IDEmpleado { get { return this._idEmpleado; } set { this._idEmpleado = value; } }
        public Rol Rol { get { return this._rol; } set { this._rol = value; } }
        public DateTime FechaAlta { get { return this._fechaAlta; } set { this._fechaBaja = value; } }
        public DateTime FechaBaja { get { return this._fechaBaja; } set { this._fechaBaja = value; } }
        public Usuario Usuario { get { return this._usuario; } set { this._usuario = value; } }
        /// <summary>
        /// Hago override de la propiedad EsCliente retornando false, servirá para
        /// el Login.
        /// </summary>
        public override bool EsCliente { get { return false; } }
        #endregion

        #region CONSTRUCTORES
        public Empleado(Rol rol, DateTime fAlta,
             string nombre, string apellido, string direccion, string dni, string telefono, DateTime fNacimiento,
             Genero genero, Usuario usuario)
            : base(nombre, apellido, genero, fNacimiento, dni, direccion, telefono)
        {
            this._usuario = usuario;
            this._fechaAlta = fAlta;
            this._usuario = usuario;
            this._rol = rol;
        }


        public Empleado(int id, Rol rol, DateTime fAlta, DateTime fBaja,
             string nombre, string apellido, string direccion, string dni, string telefono, DateTime fNacimiento,
             Genero genero, Usuario usuario)
            : this(rol, fAlta, nombre, apellido, direccion, dni, telefono, fNacimiento, genero, usuario)
        {
            this._idEmpleado = id;
            this._fechaBaja = fBaja;
        }
        public Empleado(int id, Rol rol, DateTime fAlta,
             string nombre, string apellido, string direccion, string dni, string telefono, DateTime fNacimiento,
             Genero genero, Usuario usuario)
            : this(rol, fAlta, nombre, apellido, direccion, dni, telefono, fNacimiento, genero, usuario)
        {
            this._idEmpleado = id;
        }
        #endregion

        #region SOBRE-CARGA DE OPERADORES
        /// <summary>
        /// La sobrecarga del == me permitira saber
        /// si dos empleados son iguales mediante la
        /// coincidencia de ID.
        /// </summary>
        /// <param name="empleado1"></param>
        /// <param name="empleado2"></param>
        /// <returns></returns>
        public static bool operator ==(Empleado empleado1, Empleado empleado2)
        {
            bool sonIguales = false;
            if (!(empleado1 is null) && !(empleado2 is null))
            {
                sonIguales = (empleado1.IDEmpleado == empleado2.IDEmpleado);
            }
            return sonIguales;
        }
        public static bool operator !=(Empleado empleado1, Empleado empleado2)
        {
            return !(empleado1 == empleado2);
        }
        #endregion
    }
}
