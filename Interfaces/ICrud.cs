using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICrud <T>
       where T : class
    {
        bool Delete(int id);

        bool Actualizar(T valor);

        bool Guardar(T valor);

        T ObtenerUno(int id);

        List<T> ObtenerTodos();
    }
}
