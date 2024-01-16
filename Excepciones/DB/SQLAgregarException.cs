using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.DB
{
    public class SQLAgregarException : Exception
    {
        public SQLAgregarException(string? message) : base(message)
        {
        }
    }
}
