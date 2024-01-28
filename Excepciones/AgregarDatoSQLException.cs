using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AgregarDatoSQLException : Exception
    {
        public AgregarDatoSQLException(string? message) : base(message)
        {
        }
    }
}
