using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.DB
{
    public class SQLUpdateException : Exception
    {
        public SQLUpdateException()
        {
        }

        public SQLUpdateException(string? message) : base(message)
        {
        }
    }
}
