using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class ClientePedidoDAO : AccesoDB
    {
        /// <summary>
        /// Me permitira insertar en la tabla intermedia 
        /// de clientes y pedidos.
        /// </summary>
        /// <param name="clientePedido"></param>
        /// <returns></returns>
        public bool AgregarDato(ClientePedido clientePedido)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO ClientesPedidos (IDCliente,CodPedido) " +
                       "VALUES (@IDCliente, @CodPedido)";

                    base._comando = new SqlCommand(qryInsertProd, this._conexion); 
                    base._comando.Parameters.AddWithValue("@CodPedido", clientePedido.CodigoPedido);
                    base._comando.Parameters.AddWithValue("@IDCliente", clientePedido.IDCliente);

                    base._comando.ExecuteNonQuery();
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

        public List<ClientePedido> ObtenerTodos()
        {
            List<ClientePedido> listaClientesPedidos = new List<ClientePedido>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT * FROM ClientesPedidos";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer
                {
                    listaClientesPedidos.Add(new ClientePedido(
                        (int)base._lector["IDClientePedido"],
                        (string)base._lector["CodPedido"],
                        (int)base._lector["IDCliente"]));
                }
            }
            catch (Exception)
            {
                return listaClientesPedidos;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaClientesPedidos;
        }

        public ClientePedido ObtenerEspecifico(int id)
        {
            ClientePedido clientePedido = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM ClientesPedidos WHERE IDClientePedido = {id}"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                clientePedido = new ClientePedido(
                        (int)base._lector["IDClientePedido"],
                        (string)base._lector["CodPedido"],
                        (int)base._lector["IDCliente"]);

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
            return clientePedido;
        }

        public ClientePedido ObtenerEspecificoPorCodigoPedido(string codigo)
        {
            ClientePedido clientePedido = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM ClientesPedidos WHERE CodPedido = '{codigo}'"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                clientePedido = new ClientePedido(
                        (int)base._lector["IDClientePedido"],
                        (string)base._lector["CodPedido"],
                        (int)base._lector["IDCliente"]);

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
            return clientePedido;
        }

        public List<ClientePedido> ObtenerClientePedidoPorCodigoPedido(string cod)
        {
            List<ClientePedido> clientePedido = new List<ClientePedido>();
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM ClientesPedidos WHERE CodPedido = '{cod}'"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                if (base._lector.HasRows)
                {
                    while (base._lector.Read())//-->Mientras pueda leer
                    {
                        clientePedido.Add(new ClientePedido(
                        (int)base._lector["IDClientePedido"],
                        (string)base._lector["CodPedido"],
                        (int)base._lector["IDCliente"]));
                    }
                }

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
            return clientePedido;
        }

    }
}
