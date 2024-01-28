using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class UpdateSQLException : Exception
    {
        public UpdateSQLException(string? message) : base(message)
        {
        }
    }
}
