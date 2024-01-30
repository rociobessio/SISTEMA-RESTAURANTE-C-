using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICrud<T> 
        where T : class
    {
        public bool AgregarDato(T dato);
        public List<T> ObtenerTodos();
        public T ObtenerEspecifico(int id);
        public bool UpdateDato(T dato);
        public bool DeleteDato(int id);
    }
}
