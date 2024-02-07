using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TarjetaNOValidaException : Exception
    {
        public TarjetaNOValidaException(string? message) : base(message)
        {
        }
    }
}
