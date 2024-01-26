using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Herramientas
    {
        /// <summary>
        /// Me permitira generar un codigo
        /// random de la longitud deseada
        /// </summary>
        /// <param name="longitud"></param>
        /// <returns></returns>
        public static string CrearCodigo(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] codigoArray = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                codigoArray[i] = caracteres[random.Next(caracteres.Length)];
            }

            string codigo = new string(codigoArray);
            return codigo;
        }
    }
}
