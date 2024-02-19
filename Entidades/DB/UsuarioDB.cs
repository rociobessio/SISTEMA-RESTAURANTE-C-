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
        public bool VerificarUsuario(string email, string contrasenia, out string roles)
        {
            roles = null;
            bool verificado = false;

            try
            {
                base._comando = new SqlCommand();

                //-->Uso una interconsulta para verificar en ambas tablas (clientes y empleados)
                //el rol y ademas valido la existencia de usuario.
                base._comando.CommandText = "SELECT R.Rol FROM (" +
                    "SELECT IDUsuario, IDRol " +
                    "FROM EmpleadosTablaIntermedia " +
                    "WHERE IDEmpleado IS NOT NULL " +
                    "UNION " +
                    "SELECT IDUsuario, IDRol " +
                    "FROM ClientesUsuarios) AS EC " +
                    "INNER JOIN Usuarios U ON EC.IDUsuario = U.IDUsuario " +
                    "INNER JOIN Roles R ON EC.IDRol = R.IDRol " +
                    "WHERE U.Email = @Email AND U.Clave = @Clave;";

                base._comando.CommandType = CommandType.Text;

                base._comando.Parameters.AddWithValue("@Email", email);
                base._comando.Parameters.AddWithValue("@Clave", contrasenia);

                base._comando.Connection = base._conexion;

                base._conexion.Open();

                using (base._lector = base._comando.ExecuteReader())
                {
                    if (base._lector.Read())
                    {
                        string rol = base._lector.GetString(0);

                        if (!string.IsNullOrEmpty(rol))//-->Quiere decir que en la tabla Roles es 'Cliente'
                        {
                            roles = rol;
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

        /// <summary>
        /// Sobrecarga del metodo, me permite 
        /// saber si el usuario ya existe, utilizo
        /// el COUNT
        /// </summary>
        /// <param name="email"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public bool VerificarUsuario(string email, string clave)
        {
            bool existe = false;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();

                    string query = $"SELECT COUNT(*) FROM Usuarios WHERE Email = '{email}' AND Clave = '{clave}'";

                    using (SqlCommand comando = new SqlCommand(query, base._conexion))
                    {
                        int cantidadUsuarios = Convert.ToInt32(comando.ExecuteScalar());

                        existe = cantidadUsuarios > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }

            return existe;
        }

        public Cliente ObtenerClientePorUsuario(string email,string clave)
        {
            Cliente cliente = null;

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = "SELECT c.IDCliente, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento, " +
                    "r.Rol, u.Email, u.Clave, c.ConTarjeta, c.EfectivoDisponible, c.TarjetaVencimiento, c.TarjetaEntidadEmisora, c.TarjetaTitular, c.TarjetaNumTarjeta, " +
                    "c.TarjetaCVV, c.TarjetaEsDebito, c.ImagenCliente, p.IDPersona " +
                    "FROM Usuarios u " +
                    "INNER JOIN ClientesUsuarios cu ON u.IDUsuario = cu.IDUsuario " +
                    "INNER JOIN Personas p ON cu.IDPersona = p.IDPersona " +
                    "INNER JOIN Clientes c ON cu.IDCliente = c.IDCliente " +
                    "INNER JOIN Roles r ON cu.IDRol = r.IDRol " +
                    "WHERE u.Email = @Email AND u.Clave = @Clave;";//-->La query

                base._comando.Parameters.AddWithValue("@Email", email);
                base._comando.Parameters.AddWithValue("@Clave", clave);


                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                cliente = new Cliente(
                        (int)base._lector["IDCliente"],
                        (string)base._lector["Nombre"],
                        (string)base._lector["Apellido"],
                        (Genero)Enum.Parse(typeof(Genero), (string)base._lector["Genero"]),
                        (DateTime)base._lector["FechaNacimiento"],
                        (string)base._lector["DNI"],
                        (string)base._lector["Direccion"],
                        (string)base._lector["Telefono"],
                        new Usuario((string)base._lector["Email"], (string)base._lector["Clave"]),
                        (double)base._lector["EfectivoDisponible"],
                        (bool)base._lector["ConTarjeta"],
                        new Tarjeta(
                            (DateTime)base._lector["TarjetaVencimiento"],
                            (string)base._lector["TarjetaTitular"],
                            (string)base._lector["TarjetaCVV"],
                            (string)base._lector["TarjetaNumTarjeta"],
                            (string)base._lector["TarjetaEntidadEmisora"],
                            (bool)base._lector["TarjetaEsDebito"]
                       ),
                       (Byte[])base._lector["ImagenCliente"],
                       (int)base._lector["IDPersona"]);
                base._lector.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }
            return cliente;
        }

    }
}
