using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Interfaces;
using System.Data; 


namespace Entidades.DB
{
    public class EmpleadoDAO : AccesoDB//, ICrud<Empleado>
    {
        #region METODOS
        /// <summary>
        /// Me permitira Guardar un empleado en la 
        /// tabla de empleados dentro de la DB.
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool Guardar(Empleado empleado)
        {
            bool pudoGuardar = false;

            try
            {
                string querySQL = "INSERT INTO Empleados (rol,nombre,fechaAlta,clave,usuario)";
                querySQL += $"VALUES ('{empleado.Rol}', '{empleado.Nombre}', '{empleado.FechaAlta.ToShortDateString()}'," +
                    $"'{empleado.Usuario.IDUsuario}')";

                base._comando = new SqlCommand();
                base._comando.CommandType = CommandType.Text;
                base._comando.CommandText = querySQL;//-->Le paso la query
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion a la DB

                int filasAfectadas = base._comando.ExecuteNonQuery(); ;
                if(filasAfectadas > 0) { pudoGuardar = true; }

            }
            catch (Exception) {
                pudoGuardar = false; 
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)//-->Chequeo si la conexion esta abierta
                {
                    base._conexion.Close();//-->La cierro
                }
            }
            return pudoGuardar;
        }

        /// <summary>
        /// Me permitira retornar la lista de empleados
        /// de la DB
        /// </summary>
        /// <returns></returns>
        public List<Empleado> ObtenerTodos()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT e.IDEmpleado, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                                                    "e.FechaAlta, e.FechaBaja, r.Rol, u.Email, u.Clave " +
                                                    "FROM EmpleadosClientes ec " +
                                                    "INNER JOIN Personas p ON ec.IDPersona = p.IDPersona " +
                                                    "INNER JOIN Empleados e ON ec.IDEmpleado = e.IDEmpleado " +
                                                    "INNER JOIN Roles r ON ec.IDRol = r.IDRol " +
                                                    "INNER JOIN Usuarios u ON ec.IDUsuario = u.IDUsuario";//-->La query
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer agrego el empleado a la lista
                {
                    listaEmpleados.Add(new Empleado(
                        (int)base._lector["IDEmpleado"],
                        (Rol)Enum.Parse(typeof(Rol), (string)base._lector["Rol"]),
                        (DateTime)base._lector["FechaAlta"],
                        base._lector["FechaBaja"] is DBNull ? DateTime.Now : (DateTime)base._lector["FechaBaja"],
                        (string)base._lector["Nombre"],
                        (string)base._lector["Apellido"],
                        (string)base._lector["Direccion"],
                        (string)base._lector["DNI"],
                        (string)base._lector["Telefono"],
                        (DateTime)base._lector["FechaNacimiento"],
                        (Genero)Enum.Parse(typeof(Genero), (string)base._lector["Genero"]),
                        new Usuario((string)base._lector["Email"], (string)base._lector["Clave"])
                    ));
                }
            }
            catch(Exception) {
                return listaEmpleados;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaEmpleados;
        }

        /// <summary>
        /// Me permitira obtener un Empleado
        /// especifico mediante la coincidencia de ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Empleado ObtenerEspecifico(int id)
        {
            Empleado empleado = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = "SELECT e.IDEmpleado, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                                            "e.FechaAlta, e.FechaBaja, r.Rol, u.Email, u.Clave " +
                                            "FROM EmpleadosClientes ec " +
                                            "INNER JOIN Personas p ON ec.IDPersona = p.IDPersona " +
                                            "INNER JOIN Empleados e ON ec.IDEmpleado = e.IDEmpleado " +
                                            "INNER JOIN Roles r ON ec.IDRol = r.IDRol " +
                                            "INNER JOIN Usuarios u ON ec.IDUsuario = u.IDUsuario " + 
                                            $"WHERE e.IDEmpleado = {id}"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                empleado = new Empleado((int)base._lector["IDEmpleado"],
                        (Rol)Enum.Parse(typeof(Rol), (string)base._lector["Rol"]),
                        (DateTime)base._lector["FechaAlta"],
                        base._lector["FechaBaja"] is DBNull ? DateTime.Now : (DateTime)base._lector["FechaBaja"],
                        (string)base._lector["Nombre"],
                        (string)base._lector["Apellido"],
                        (string)base._lector["Direccion"],
                        (string)base._lector["DNI"],
                        (string)base._lector["Telefono"],
                        (DateTime)base._lector["FechaNacimiento"],
                        (Genero)Enum.Parse(typeof(Genero), (string)base._lector["Genero"]),
                        new Usuario((string)base._lector["Email"], (string)base._lector["Clave"]));
                
                base._lector.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)//-->Chequeo si la conexion esta abierta
                {
                    base._conexion.Close();//-->La cierro
                }
            }
            return empleado;
        }

        public bool UpdateDato(Empleado empleado)
        {
            bool pudoActualizar = true;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    string query = $"UPDATE Empleados " +
                                   $"SET " +
                                   $"FechaAlta = '{empleado.FechaAlta.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                   $"FechaBaja = {(empleado.FechaBaja != DateTime.MinValue ? $"'{empleado.FechaBaja.ToString("yyyy-MM-dd HH:mm:ss")}'" : "NULL")}, " +
                                   $"Nombre = '{empleado.Nombre}', " +
                                   $"Apellido = '{empleado.Apellido}', " +
                                   $"Telefono = '{empleado.Telefono}', " +
                                   $"Direccion = '{empleado.Direccion}', " +
                                   $"DNI = '{empleado.DNI}', " +
                                   $"Genero = '{empleado.Genero}', " +
                                   $"FechaNacimiento = '{empleado.FechaNacimeinto.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                   $"IDRol = (SELECT IDRol FROM Roles WHERE Rol = '{empleado.Rol}'), " +
                                   $"IDUsuario = (SELECT IDUsuario FROM Usuarios WHERE Email = '{empleado.Usuario.Email}') " +
                                   $"WHERE IDEmpleado = {empleado.IDEmpleado}";

                    using (SqlCommand comando = new SqlCommand(query, base._conexion))
                    {
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            { 
                return false;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)//-->Chequeo si la conexion esta abierta
                {
                    base._conexion.Close();//-->La cierro
                }
            }

            return pudoActualizar;

        }
        #endregion
    }
}
