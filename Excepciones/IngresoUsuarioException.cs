using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class IngresoUsuarioException : Exception
    {
        public IngresoUsuarioException(string? message) : base(message)
        {
        }
    }
}
