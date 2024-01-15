using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Claims;

namespace Entidades.DB
{
    public class UsuarioDAO : AccesoDB
    {
        /// <summary>
        /// Me permite verificar si el email y contrasenia
        /// se encuentran en la tabla Usuarios.
        /// Ademas verificara si es cliente, preparador o 
        /// socio.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contrasenia"></param>
        /// <param name="esCliente"></param>
        /// <returns>Devuelve true si es esCliente, false sino</returns>
        public bool VerificarUsuario(string email, string contrasenia, out string esCliente)
        {
            //esCliente = false;
            esCliente = null;
            bool verificado = false;

            try
            {
                base._comando = new SqlCommand();

                base._comando.Parameters.AddWithValue("@Email", email);
                base._comando.Parameters.AddWithValue("@Clave", contrasenia);

                base._comando.CommandType = CommandType.Text;
                base._comando.CommandText = $"SELECT R.Rol FROM EmpleadosClientes EC " +
                                            $"INNER JOIN Usuarios U ON EC.IDUsuario = U.IDUsuario " +
                                            $"INNER JOIN Roles R ON EC.IDRol = R.IDRol " +
                                            $"WHERE U.Email = @Email AND U.Clave = @Clave";
                base._comando.Connection = base._conexion;

                base._conexion.Open();

                using (base._lector = base._comando.ExecuteReader())
                {
                    if (base._lector.Read())
                    {
                        string rol = base._lector.GetString(0);

                        if (!string.IsNullOrEmpty(rol))//-->Quiere decir que en la tabla Roles es 'Cliente'
                        {
                            esCliente = rol;
                        }
                        //return true;
                        verificado = true;
                    }
                }
            }
            catch (Exception)
            {
                //esCliente = false;
                throw;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)//-->Chequeo si la conexion esta abierta
                {
                    base._conexion.Close();//-->La cierro
                }
            }
            //return false;
            return verificado;
        }
    }
}
