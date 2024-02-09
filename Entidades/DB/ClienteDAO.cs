using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class ClienteDAO : AccesoDB
    {
        /// <summary>
        /// Me permitira guardar la instancia de
        /// Cliente dentro de la tabla Clientes
        /// y tambien guardar dentro de la
        /// tabla intermedia.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool AgregarDato(Cliente cliente, out int idCliente)
        {
            idCliente = 0;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();

                    // Insertar en la tabla Personas y obtener el ID generado
                    string queryInsertPersonas = "INSERT INTO Personas (Nombre, Apellido, Telefono, Direccion, DNI, Genero, FechaNacimiento) " +
                                                 "OUTPUT INSERTED.IDPersona " +
                                                 "VALUES (@Nombre, @Apellido, @Telefono, @Direccion, @DNI, @Genero, @FechaNacimiento)";

                    using (SqlCommand comandoInsertPersona = new SqlCommand(queryInsertPersonas, base._conexion))
                    {
                        // Agregar parámetros
                        comandoInsertPersona.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        comandoInsertPersona.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                        comandoInsertPersona.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        comandoInsertPersona.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        comandoInsertPersona.Parameters.AddWithValue("@DNI", cliente.DNI);
                        comandoInsertPersona.Parameters.AddWithValue("@Genero", cliente.Genero);
                        DateTime fechaNacimiento = (cliente.FechaNacimeinto != null && cliente.FechaNacimeinto > DateTime.MinValue) ? (DateTime)cliente.FechaNacimeinto : new DateTime(1900, 1, 1);
                        comandoInsertPersona.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);


                        // Obtener el ID de la persona insertada
                        int idPersona = Convert.ToInt32(comandoInsertPersona.ExecuteScalar());

                        // Insertar en la tabla Clientes y obtener el ID generado
                        string queryInsertCliente = "INSERT INTO Clientes (ConTarjeta, EfectivoDisponible, TarjetaVencimiento, TarjetaEntidadEmisora, TarjetaTitular, " +
                                                    "TarjetaNumTarjeta, TarjetaCVV, TarjetaDineroDisponible, TarjetaEsDebito) " +
                                                    "OUTPUT INSERTED.IDCliente " +
                                                    "VALUES (@ConTarjeta, @EfectivoDisponible, @TarjetaVencimiento, @TarjetaEntidadEmisora, @TarjetaTitular, " +
                                                    "@TarjetaNumTarjeta, @TarjetaCVV, @TarjetaDineroDisponible, @TarjetaEsDebito)";

                        using (SqlCommand comandoInsertCliente = new SqlCommand(queryInsertCliente, base._conexion))
                        { 
                            comandoInsertCliente.Parameters.AddWithValue("@ConTarjeta", cliente.ConTarjeta);
                            comandoInsertCliente.Parameters.AddWithValue("@EfectivoDisponible", cliente.DineroEfectivoDisponible);
                            DateTime fechaVencimientoTarjeta = (cliente.Tarjeta.FechaVencimiento != null && cliente.Tarjeta.FechaVencimiento > DateTime.MinValue) ? (DateTime)cliente.Tarjeta.FechaVencimiento : new DateTime(1900, 1, 1);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaVencimiento", fechaVencimientoTarjeta);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaEntidadEmisora", cliente.Tarjeta.EntidadEmisora);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaTitular", cliente.Tarjeta.Titular);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaNumTarjeta", cliente.Tarjeta.NumeroTarjeta);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaCVV", cliente.Tarjeta.CVV);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaDineroDisponible", cliente.Tarjeta.DineroDisponible);
                            comandoInsertCliente.Parameters.AddWithValue("@TarjetaEsDebito", cliente.Tarjeta.EsDebito);

                            // Obtener el ID del cliente insertado
                            idCliente = Convert.ToInt32(comandoInsertCliente.ExecuteScalar());

                            // Insertar en la tabla Usuarios y obtener el ID generado
                            string queryInsertUsuario = "INSERT INTO Usuarios (Email, Clave) " +
                                                        "OUTPUT INSERTED.IDUsuario " +
                                                        "VALUES (@Email, @Clave)";

                            using (SqlCommand comandoInsertUsuario = new SqlCommand(queryInsertUsuario, base._conexion))
                            {
                                // Agregar parámetros
                                comandoInsertUsuario.Parameters.AddWithValue("@Email", cliente.Usuario.Email);
                                comandoInsertUsuario.Parameters.AddWithValue("@Clave", cliente.Usuario.Contrasenia);

                                // Obtener el ID del usuario insertado
                                int idUsuario = Convert.ToInt32(comandoInsertUsuario.ExecuteScalar());

                                // Insertar en la tabla ClientesUsuarios
                                string queryClientesUsuarios = "INSERT INTO ClientesUsuarios (IDPersona, IDCliente, IDUsuario, IDRol) " +
                                                                "VALUES (@IDPersona, @IDCliente, @IDUsuario, @IDRol)";

                                using (SqlCommand comandoInsertClientes = new SqlCommand(queryClientesUsuarios, base._conexion))
                                {
                                    // Agregar parámetros
                                    comandoInsertClientes.Parameters.AddWithValue("@IDPersona", idPersona);
                                    comandoInsertClientes.Parameters.AddWithValue("@IDCliente", idCliente);
                                    comandoInsertClientes.Parameters.AddWithValue("@IDUsuario", idUsuario);
                                    comandoInsertClientes.Parameters.AddWithValue("@IDRol", 6);

                                    // Ejecutar la consulta
                                    comandoInsertClientes.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                // Manejar la excepción aquí si es necesario
                return false;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT c.IDCliente, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                                                    "r.Rol, u.Email, u.Clave,c.ConTarjeta,c.EfectivoDisponible,c.TarjetaVencimiento,c.TarjetaEntidadEmisora,c.TarjetaTitular," +
                                                    "c.TarjetaNumTarjeta,c.TarjetaCVV,c.TarjetaDineroDisponible,c.TarjetaEsDebito " +
                                                    "FROM ClientesUsuarios cu " +
                                                    "INNER JOIN Personas p ON cu.IDPersona = p.IDPersona " +
                                                    "INNER JOIN Clientes c ON cu.IDCliente = c.IDCliente " +
                                                    "INNER JOIN Roles r ON cu.IDRol = r.IDRol " +
                                                    "INNER JOIN Usuarios u ON cu.IDUsuario = u.IDUsuario";//-->La query
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())
                {
                    listaClientes.Add(new Cliente(
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
                            (string)base._lector["Titular"],
                            (string)base._lector["TarjetaCVV"],
                            (string)base._lector["TarjetaNumTarjeta"],
                            (string)base._lector["TarjetaEntidadEmisora"],
                            (bool)base._lector["TarjetaEsDebito"],
                            (double)base._lector["TarjetaDineroDisponible"]
                       )));
                }
            }
            catch (Exception)
            {
                return listaClientes;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaClientes;
        }

        public Cliente ObtenerEspecifico(int id)
        {
            Cliente cliente = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = "SELECT c.IDCliente, p.Nombre, p.Apellido, p.Telefono, p.DNI, p.Direccion, p.Genero, p.FechaNacimiento," +
                                                    "r.Rol, u.Email, u.Clave,c.ConTarjeta,c.EfectivoDisponible,c.TarjetaVencimiento,c.TarjetaEntidadEmisora,c.TarjetaTitular," +
                                                    "c.TarjetaNumTarjeta,c.TarjetaCVV,c.TarjetaDineroDisponible,c.TarjetaEsDebito " +
                                                    "FROM ClientesUsuarios cu " +
                                                    "INNER JOIN Personas p ON cu.IDPersona = p.IDPersona " +
                                                    "INNER JOIN Clientes c ON cu.IDCliente = c.IDCliente " +
                                                    "INNER JOIN Roles r ON cu.IDRol = r.IDRol " +
                                                    "INNER JOIN Usuarios u ON cu.IDUsuario = u.IDUsuario " +
                                                    $"WHERE c.IDCliente = {id}";//-->La query

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
                        new Usuario(
                            (string)base._lector["Email"], 
                            (string)base._lector["Clave"]),
                        (double)base._lector["EfectivoDisponible"],
                        (bool)base._lector["ConTarjeta"],
                        new Tarjeta(
                            (DateTime)base._lector["TarjetaVencimiento"],
                            (string)base._lector["Titular"],
                            (string)base._lector["TarjetaCVV"],
                            (string)base._lector["TarjetaNumTarjeta"],
                            (string)base._lector["TarjetaEntidadEmisora"],
                            (bool)base._lector["TarjetaEsDebito"],
                            (double)base._lector["TarjetaDineroDisponible"]
                       ));
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
            return cliente;
        }
    }
}
