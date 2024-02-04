using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class PedidoProductoDAO : AccesoDB
    {
        /// <summary>
        /// Me permitira insertar en la
        /// tabla intermedia de pedidos
        /// y productos.
        /// </summary>
        /// <param name="pedidoProd"></param>
        /// <returns></returns>
        public bool AgregarDato(PedidoProducto pedidoProd)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO PedidosProducto (Estado, " +
                        "CodPedido, IDProducto,IDEmpleado,Cantidad) " +
                       "VALUES (@Estado, @CodPedido, @IDProducto, @IDEmpleado,@Cantidad)";

                    base._comando = new SqlCommand(qryInsertProd, this._conexion);
                    base._comando.Parameters.AddWithValue("@Estado", pedidoProd.Estado);
                    base._comando.Parameters.AddWithValue("@CodPedido", pedidoProd.CodigoPedido);
                    base._comando.Parameters.AddWithValue("@IDProducto", pedidoProd.IDProducto);
                    base._comando.Parameters.AddWithValue("@Cantidad", pedidoProd.Cantidad);
                    base._comando.Parameters.AddWithValue("@IDEmpleado", 1);
                    
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

        public List<PedidoProducto> ObtenerTodos()
        {
            List<PedidoProducto> listaPedidosProductos = new List<PedidoProducto>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT * FROM Pedidos";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer
                {
                    listaPedidosProductos.Add(new PedidoProducto(
                        (int)base._lector["IDPedidoProd"],
                        (string)base._lector["CodPedido"],
                        (int)base._lector["IDProducto"],
                        (string)base._lector["Estado"],
                        (int)base._lector["IDEmpleado"],
                        (int)base._lector["Cantidad"]));
                }
            }
            catch (Exception)
            {
                return listaPedidosProductos;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaPedidosProductos;
        }

        public PedidoProducto ObtenerEspecifico(int id)
        {
            PedidoProducto pedidoProd = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM PedidosProducto WHERE IDPedidoProd = {id}"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                pedidoProd = new PedidoProducto(
                        (int)base._lector["IDPedidoProd"],
                        (string)base._lector["CodPedido"],
                        (int)base._lector["IDProducto"],
                        (string)base._lector["Estado"],
                        (int)base._lector["IDEmpleado"],
                        (int)base._lector["Cantidad"]);

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
            return pedidoProd;
        }

        public List<PedidoProducto> ObtenerPedidoProductosPorCodigoPedido(string cod)
        {
            List<PedidoProducto> pedidoProd = new List<PedidoProducto>();
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM PedidosProducto WHERE CodPedido = '{cod}'"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                if (base._lector.HasRows)
                {
                    while (base._lector.Read())//-->Mientras pueda leer
                    {
                        pedidoProd.Add(new PedidoProducto(
                            (int)base._lector["IDPedidoProd"],
                            (string)base._lector["CodPedido"],
                            (int)base._lector["IDProducto"],
                            (string)base._lector["Estado"],
                            (int)base._lector["IDEmpleado"],
                            (int)base._lector["Cantidad"]));
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
            return pedidoProd;
        }

        public bool UpdateDato(PedidoProducto pedidoProducto)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string qryUpdatePedidoProd = $"UPDATE PedidosProducto SET Estado = '{pedidoProducto.Estado}', CodPedido = '{pedidoProducto.CodigoPedido}'," +
                        $"IDProducto = {pedidoProducto.IDProducto}, IDEmpleado = {pedidoProducto.IDEmpleado}, Cantidad = {pedidoProducto.Cantidad} " +
                        $"WHERE IDPedidoProd = {pedidoProducto.IDPedProd}";

                    using (SqlCommand cmdUpdatePedidoProd = new SqlCommand(qryUpdatePedidoProd, base._conexion))
                    {
                        cmdUpdatePedidoProd.ExecuteNonQuery();//-->Ejecuto
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
    }
}
