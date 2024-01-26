using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        private int _idPersona;
        private string _nombre;
        private string _apellido;
        private string _numeroTelefono;
        private string _direccion;
        private string _dni;
        private DateTime _fechaNacimiento;
        private Genero _genero;
        #endregion

        #region PROPIEDADES
        public int IDPersona { get { return this._idPersona; } set { _idPersona = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public string Apellido { get { return this._apellido; } set { this._apellido = value; } }
        public string Direccion { get { return this._direccion; } set { this._direccion = value; } }
        public string DNI { get { return this._dni; } set { this._dni = value; } }
        public DateTime FechaNacimeinto { get { return _fechaNacimiento; } set { this._fechaNacimiento = value; } }
        public Genero Genero { get { return _genero; } set { _genero = value; } }
        public string Telefono { get { return this._numeroTelefono; } set { _numeroTelefono = value; } }
        /// <summary>
        /// Esta propiedad abstracta, me permite implementarla en las clases derivadas, 
        /// de esta forma retornara en cliente true y en vendedor false, para poder usarla.
        /// </summary>
        public abstract bool EsCliente { get; }
        #endregion


        #region CONSTRUCTORES
        /// <summary>
        /// Constructor privado que inicializa con datos vacios un objeto derivado de persona.
        /// </summary>
        private Persona()
        {
            this._nombre = "BBB";
            this._apellido = "AAAA";
            this._direccion = "Calle Falsa";
            this._dni = "00.000.000";
            this._genero = Genero.Femenino;
            this._fechaNacimiento = new DateTime();
            this._numeroTelefono = "000";
        }

        protected Persona(string nombre, string apellido, Genero sexo, DateTime fechaNacimiento,
            string dni, string domicilio, string telefono)
        {
            this._genero = sexo;
            this._fechaNacimiento = fechaNacimiento;
            this._dni = dni;
            this._direccion = domicilio;
            this._apellido = apellido;
            this._nombre = nombre;
            this._numeroTelefono = telefono;
        }
        #endregion
    }
}
