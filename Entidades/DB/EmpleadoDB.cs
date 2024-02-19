using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.SymbolStore;
using Interfaces;
using System.Reflection;

namespace Entidades.DB
{
    public class EmpleadoDAO : AccesoDB, ICrud<Empleado>
    {
        #region METODOS

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
                                                    "FROM EmpleadosTablaIntermedia ec " +
                                                    "INNER JOIN Personas p ON ec.IDPersona = p.IDPersona " +
                                                    "INNER JOIN Empleados e ON ec.IDEmpleado = e.IDEmpleado " +
                                                    "INNER JOIN Roles r ON ec.IDRol = r.IDRol " +
                                                    "INNER JOIN Usuarios u ON ec.IDUsuario = u.IDUsuario";//-->La query
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())
                {
                    DateTime fechaBaja = base._lector["FechaBaja"] != DBNull.Value ? (DateTime)base._lector["FechaBaja"] : DateTime.MinValue;

                    listaEmpleados.Add(new Empleado(
                        (int)base._lector["IDEmpleado"],
                        (Rol)Enum.Parse(typeof(Rol), (string)base._lector["Rol"]),
                        (DateTime)base._lector["FechaAlta"],
                        fechaBaja, // Utiliza la fechaBaja que se asignó arriba
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
            catch (Exception)
            {
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
                                            "FROM EmpleadosTablaIntermedia ec " +
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

                empleado.IDPersona = (int)base._lector["IDPersona"];

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

        /// <summary>
        /// Me permitira obtener un conductor RANDOM
        /// para asignarselo a un delivery.
        /// </summary>
        /// <param name="nombreConductor"></param>
        /// <returns></returns>
        public Empleado ObtenerConductorRandom()
        {
            Empleado empleado = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText =
                    "SELECT TOP 1 e.IDEmpleado, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                    "e.FechaAlta, e.FechaBaja, r.Rol, u.Email, u.Clave " +
                    "FROM EmpleadosTablaIntermedia ec " +
                    "INNER JOIN Personas p ON ec.IDPersona = p.IDPersona " +
                    "INNER JOIN Empleados e ON ec.IDEmpleado = e.IDEmpleado " +
                    "INNER JOIN Roles r ON ec.IDRol = r.IDRol " +
                    "INNER JOIN Usuarios u ON ec.IDUsuario = u.IDUsuario " +
                    "WHERE ec.IDRol = @IDRol " +
                    "ORDER BY NEWID();";

                base._comando.Parameters.AddWithValue("@IDRol", 8);


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

                //empleado.IDPersona = (int)base._lector["IDPersona"];

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

        public Empleado ObtenerConductor(string nombreConductor)
        {
            Empleado empleado = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = "SELECT e.IDEmpleado, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                            "e.FechaAlta, e.FechaBaja, r.Rol, u.Email, u.Clave " +
                            "FROM EmpleadosTablaIntermedia ec " +
                            "INNER JOIN Personas p ON ec.IDPersona = p.IDPersona " +
                            "INNER JOIN Empleados e ON ec.IDEmpleado = e.IDEmpleado " +
                            "INNER JOIN Roles r ON ec.IDRol = r.IDRol " +
                            "INNER JOIN Usuarios u ON ec.IDUsuario = u.IDUsuario " +
                            "WHERE CONCAT(p.Nombre, ' ', p.Apellido) = @NombreConductor " +
                            "AND ec.IDRol = @IDRol";

                base._comando.Parameters.AddWithValue("@NombreConductor", nombreConductor);
                base._comando.Parameters.AddWithValue("@IDRol", 8);


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

                //empleado.IDPersona = (int)base._lector["IDPersona"];

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

        /// <summary>
        /// Me permitira dar de alta un empleado en la
        /// Tabla de Empleados.
        /// Guardando sus datos en tres tablas:
        /// 1. La tabla de Personas, 2. la tabla de Empleados
        /// 3. una tabla Intermedia que contiene las IDs.
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool AgregarDato(Empleado empleado)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    //-->Primero se hace el INSERT en la tabla Personas y con OUTPUT se consigue el ID.
                    string queryInsertPersonas = $"INSERT INTO Personas (Nombre, Apellido, Telefono, Direccion, DNI, Genero, FechaNacimiento) " +
                                                 $"OUTPUT INSERTED.IDPersona " +
                                                 $"VALUES ('{empleado.Nombre}', '{empleado.Apellido}', '{empleado.Telefono}', " +
                                                 $"'{empleado.Direccion}', '{empleado.DNI}', '{empleado.Genero}', '{empleado.FechaNacimeinto.ToString("yyyy-MM-dd HH:mm:ss")}')";

                    using (SqlCommand comando = new SqlCommand(queryInsertPersonas, base._conexion))
                    {
                        int idPersona = Convert.ToInt32(comando.ExecuteScalar());//-->Obtengo el ID en Personas

                        //-->Segundo se hace el insert en la tabla de Empleados y se consigue el ID del Empleado.
                        string queryInsertEmpleados = $"INSERT INTO Empleados (FechaAlta, FechaBaja) " +
                                                     $"OUTPUT INSERTED.IDEmpleado " +
                                                     $"VALUES ('{empleado.FechaAlta.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                                     $"{(empleado.FechaBaja != DateTime.MinValue ? $"'{empleado.FechaBaja.ToString("yyyy-MM-dd HH:mm:ss")}'" : "NULL")})";

                        using (SqlCommand comandoInsertEmpleado = new SqlCommand(queryInsertEmpleados, base._conexion))
                        {
                            int idEmpleado = Convert.ToInt32(comandoInsertEmpleado.ExecuteScalar());//-->Obtengo el ID del Empleado

                            //-->Tercero hago el INSERT en la tabla Usuarios
                            string queryInsertUsuario = $"INSERT INTO Usuarios (Email, Clave) " +
                                                        $"OUTPUT INSERTED.IDUsuario " +
                                                        $"VALUES ('{empleado.Usuario.Email}', '{empleado.Usuario.Contrasenia}')";

                            using (SqlCommand comandoInsertUsuario = new SqlCommand(queryInsertUsuario, base._conexion))
                            {
                                int idUsuario = Convert.ToInt32(comandoInsertUsuario.ExecuteScalar());//-->Obtengo el ID del Usuario

                                //-->Cuarto hago el INSERT en la tabla INTERMEDIA:
                                string queryEmpleadosClientes = "INSERT INTO EmpleadosTablaIntermedia (IDPersona, IDEmpleado, IDUsuario, IDRol)" +
                                                                $"VALUES({idPersona},{idEmpleado},{idUsuario},'{(int)empleado.Rol}')";

                                using (SqlCommand comandoInsertEmpleadosClientes = new SqlCommand(queryEmpleadosClientes, base._conexion))
                                {
                                    comandoInsertEmpleadosClientes.ExecuteNonQuery();//-->Ejecuto
                                }
                            }
                        }
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
            return true;
        }


        /// <summary>
        /// Me permitira actualizar datos sobre los
        /// empleados.
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool UpdateDato(Empleado empleado)
        {
            bool pudoActualizar = true;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion

                    using (SqlTransaction transaction = base._conexion.BeginTransaction())
                    {
                        try
                        {
                            //Actualizo la tabla EMPLEADOS
                            string queryEmpleados = $"UPDATE Empleados " +
                                                     $"SET FechaAlta = '{empleado.FechaAlta.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                                     $"FechaBaja = {(empleado.FechaBaja != DateTime.MinValue ? $"'{empleado.FechaBaja.ToString("yyyy-MM-dd HH:mm:ss")}'" : "NULL")} " +
                                                     $"WHERE IDEmpleado = {empleado.IDEmpleado}";

                            using (SqlCommand comandoEmpleados = new SqlCommand(queryEmpleados, base._conexion, transaction))
                            {
                                comandoEmpleados.ExecuteNonQuery();
                            }

                            //-->Luego actualizo la tabla PERSONAS
                            string queryPersonas = $"UPDATE Personas " +
                                                   $"SET Nombre = '{empleado.Nombre}', " +
                                                   $"Apellido = '{empleado.Apellido}', " +
                                                   $"Telefono = '{empleado.Telefono}', " +
                                                   $"Direccion = '{empleado.Direccion}', " +
                                                   $"DNI = '{empleado.DNI}', " +
                                                   $"Genero = '{empleado.Genero}', " +
                                                   $"FechaNacimiento = '{empleado.FechaNacimeinto.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                                                   $"FROM Personas P " +
                                                   $"INNER JOIN EmpleadosTablaIntermedia EC ON P.IDPersona = EC.IDPersona " +
                                                   $"INNER JOIN Empleados E ON EC.IDEmpleado = E.IDEmpleado " +
                                                   $"WHERE E.IDEmpleado = {empleado.IDEmpleado}";

                            using (SqlCommand comandoPersonas = new SqlCommand(queryPersonas, base._conexion, transaction))
                            {
                                comandoPersonas.ExecuteNonQuery();
                            }

                            //-->Actualizo el ROL
                            string queryRol = $"UPDATE EC " +
                                              $"SET EC.IDRol = '{(int)empleado.Rol}' " +
                                              $"FROM EmpleadosTablaIntermedia EC " +
                                              $"INNER JOIN Empleados E ON EC.IDEmpleado = E.IDEmpleado " +
                                              $"WHERE E.IDEmpleado = {empleado.IDEmpleado}";

                            using (SqlCommand cmdRol = new SqlCommand(queryRol, base._conexion, transaction))
                            {
                                cmdRol.ExecuteNonQuery();
                            }

                            //-->Commit si todo se realizó con éxito
                            transaction.Commit();
                            pudoActualizar = true;
                        }
                        catch (Exception)
                        {
                            //-->Rollback en caso de error
                            transaction.Rollback();
                            pudoActualizar = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                pudoActualizar = false;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }

            return pudoActualizar;
        }

        /// <summary>
        /// Me permitira realizar una baja logica
        /// de la tabla de empleados.
        /// Cambiando la fecha de baja
        /// seteandole la actual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDato(int id)
        {
            bool pudoEliminar = false;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion

                    using (SqlTransaction transaction = base._conexion.BeginTransaction())
                    {
                        try
                        {
                            string queryDelete = "UPDATE Empleados " +
                                                 $"SET FechaBaja = '{DateTime.Now.ToString("yyyy-MM-dd")}' " +
                                                 $"WHERE IDEmpleado = {id}";

                            using (base._comando = new SqlCommand(queryDelete, base._conexion, transaction))
                            {
                                base._comando.ExecuteNonQuery();
                            }

                            //-->Commit si todo se realizó con éxito
                            transaction.Commit();
                            pudoEliminar = true;
                        }
                        catch (Exception)
                        {
                            //-->Rollback en caso de error
                            transaction.Rollback();
                            pudoEliminar = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                pudoEliminar = false;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }
            return pudoEliminar;
        }

            public List<Empleado> ObtenerEmpleadoPorRol(string rol)
            {
                List<Empleado> listaEmpleados = new List<Empleado>();

                try
                {
                    base._comando = new SqlCommand();

                    base._comando.CommandType = System.Data.CommandType.Text;
                    base._comando.CommandText = "SELECT e.IDEmpleado, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                                                        "e.FechaAlta, e.FechaBaja, r.Rol, u.Email, u.Clave " +
                                                        "FROM EmpleadosTablaIntermedia ec " +
                                                        "INNER JOIN Personas p ON ec.IDPersona = p.IDPersona " +
                                                        "INNER JOIN Empleados e ON ec.IDEmpleado = e.IDEmpleado " +
                                                        "INNER JOIN Roles r ON ec.IDRol = r.IDRol " +
                                                        "INNER JOIN Usuarios u ON ec.IDUsuario = u.IDUsuario " +
                                                        $"WHERE r.Rol = '{rol}'";//-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())
                {
                    DateTime fechaBaja = base._lector["FechaBaja"] != DBNull.Value ? (DateTime)base._lector["FechaBaja"] : DateTime.MinValue;

                    listaEmpleados.Add(new Empleado(
                        (int)base._lector["IDEmpleado"],
                        (Rol)Enum.Parse(typeof(Rol), (string)base._lector["Rol"]),
                        (DateTime)base._lector["FechaAlta"],
                        fechaBaja, // Utiliza la fechaBaja que se asignó arriba
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
            catch (Exception)
            {
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
        #endregion
    }
}
