using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class PedidoDAO : AccesoDB
    {

        public bool AgregarDato(Pedido pedido)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO Pedidos (Estado, TiempoEstimadoPreparacion, TiempoInicio, TiempoFin, TipoOrden, " +
                        "CodigoPedido, CostoTotal, IDMesa,PedidoFacturado) " +
                       "VALUES (@Estado, @TiempoEstimadoPreparacion, @TiempoInicio, @TiempoFin, @TipoOrden, @CodigoPedido, " +
                       "@CostoTotal, @IDMesa,@PedidoFacturado)";

                    base._comando = new SqlCommand(qryInsertProd, this._conexion);
                    base._comando.Parameters.AddWithValue("@Estado", pedido.Estado);
                    base._comando.Parameters.AddWithValue("@TiempoEstimadoPreparacion", pedido.TiempoPreparacionTotal);
                    base._comando.Parameters.AddWithValue("@TiempoInicio", pedido.TiempoInicio);
                    base._comando.Parameters.AddWithValue("@TiempoFin", pedido.TiempoFinalizacion);
                    base._comando.Parameters.AddWithValue("@TipoOrden", pedido.TipoOrden);
                    base._comando.Parameters.AddWithValue("@CodigoPedido", pedido.CodPedido);
                    base._comando.Parameters.AddWithValue("@CostoTotal", pedido.TotalPedido);
                    base._comando.Parameters.AddWithValue("@PedidoFacturado", pedido.PedidoPagado);

                    //-->Me fijo el tipo de orden
                    if (pedido.TipoOrden == TiposPedidos.Pedido.ToString())
                        base._comando.Parameters.AddWithValue("@IDMesa", pedido.IDMesa);
                    else
                        base._comando.Parameters.AddWithValue("@IDMesa", 0);

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

        public List<Pedido> ObtenerTodos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT * FROM Pedidos";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer la mesa a la lista
                {
                    listaPedidos.Add(new Pedido((int)base._lector["IDPedido"],
                        (string)base._lector["CodigoPedido"], (string)base._lector["Estado"],
                        (TimeSpan)base._lector["TiempoEstimadoPreparacion"],
                        (string)base._lector["TipoOrden"],
                        (int)base._lector["IDMesa"], (TimeSpan)base._lector["TiempoInicio"],
                        (TimeSpan)base._lector["TiempoFin"],
                        (double)base._lector["CostoTotal"],
                        (bool)base._lector["PedidoFacturado"]));
                }
            }
            catch (Exception)
            {
                return listaPedidos;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaPedidos;
        }


        public List<Pedido> ObtenerPedidosPorEstado(string estado)
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = $"SELECT * FROM Pedidos WHERE Estado = '{estado}'";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer la mesa a la lista
                {
                    listaPedidos.Add(new Pedido((int)base._lector["IDPedido"],
                        (string)base._lector["CodigoPedido"], (string)base._lector["Estado"],
                        (TimeSpan)base._lector["TiempoEstimadoPreparacion"],
                        (string)base._lector["TipoOrden"],
                        (int)base._lector["IDMesa"], (TimeSpan)base._lector["TiempoInicio"],
                        (TimeSpan)base._lector["TiempoFin"],
                        (double)base._lector["CostoTotal"],
                        (bool)base._lector["PedidoFacturado"]));
                }
            }
            catch (Exception)
            {
                return listaPedidos;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaPedidos;
        }

        public Pedido ObtenerEspecifico(int id)
        {
            Pedido pedido = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM Pedidos WHERE IDPedido = {id}"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                pedido = new Pedido((int)base._lector["IDPedido"],
                        (string)base._lector["CodigoPedido"], (string)base._lector["Estado"],
                        (TimeSpan)base._lector["TiempoEstimadoPreparacion"],
                        (string)base._lector["TipoOrden"],
                        (int)base._lector["IDMesa"], (TimeSpan)base._lector["TiempoInicio"],
                        (TimeSpan)base._lector["TiempoFin"],
                        (double)base._lector["CostoTotal"],
                        (bool)base._lector["PedidoFacturado"]);

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
            return pedido;
        }

        /// <summary>
        /// Me permitira devolver
        /// la instancia de un Pedido
        /// mediante la coincidencia del
        /// codigo del pedido.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Pedido ObtenerPedidoPorCodigoPedido(string codigo)
        {
            Pedido pedido = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = $"SELECT * FROM Pedidos WHERE CodigoPedido= '{codigo}'"; //-->La query

                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                pedido = new Pedido((int)base._lector["IDPedido"],
                        (string)base._lector["CodigoPedido"], (string)base._lector["Estado"],
                        (TimeSpan)base._lector["TiempoEstimadoPreparacion"],
                        (string)base._lector["TipoOrden"],
                        (int)base._lector["IDMesa"], (TimeSpan)base._lector["TiempoInicio"],
                        (TimeSpan)base._lector["TiempoFin"],
                        (double)base._lector["CostoTotal"],
                        (bool)base._lector["PedidoFacturado"]);

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
            return pedido;
        }

        public bool UpdateDato(Pedido pedido)
        {
            bool pudoActualizar = false;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryUpdatePedido = "UPDATE Pedidos " +
                        $"SET Estado = @Estado, " +
                        $"TiempoEstimadoPreparacion = @TiempoEstimadoPreparacion, " +
                        $"TiempoInicio = @TiempoInicio, " +
                        $"TiempoFin = @TiempoFin, " +
                        $"IDMesa = @IDMesa, " +
                        $"CodigoPedido = @CodigoPedido, " +
                        $"PedidoFacturado = @PedidoFacturado," +
                        $"TipoOrden = @TipoOrden " +
                        $"WHERE IDPedido = {pedido.IDPedido}";


                    base._comando = new SqlCommand(qryUpdatePedido, this._conexion);
                    base._comando.Parameters.AddWithValue("@Estado", pedido.Estado);
                    base._comando.Parameters.AddWithValue("@TiempoEstimadoPreparacion", pedido.TiempoPreparacionTotal);
                    base._comando.Parameters.AddWithValue("@TiempoInicio", pedido.TiempoInicio);
                    base._comando.Parameters.AddWithValue("@TiempoFin", pedido.TiempoFinalizacion);
                    base._comando.Parameters.AddWithValue("@IDMesa", pedido.IDMesa);
                    base._comando.Parameters.AddWithValue("@CodigoPedido", pedido.CodPedido);
                    base._comando.Parameters.AddWithValue("@PedidoFacturado",pedido.PedidoPagado);
                    base._comando.Parameters.AddWithValue("@TipoOrden", pedido.TipoOrden);

                    base._comando.ExecuteNonQuery();
                    pudoActualizar = true;
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
                    base._comando.Connection.Close();
                }
            }

            return pudoActualizar;
        }
    }
}
