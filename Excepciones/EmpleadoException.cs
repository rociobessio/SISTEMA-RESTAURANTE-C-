using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EmpleadoException : Exception
    {
        public EmpleadoException()
        {
        }

        public EmpleadoException(string? message) : base(message)
        {
        }
    }
}