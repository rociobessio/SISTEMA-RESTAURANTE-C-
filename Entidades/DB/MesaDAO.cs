using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Entidades.DB
{
    public class MesaDAO : AccesoDB, ICrud<Mesa>
    {
        public bool AgregarDato(Mesa mesa)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string queryAgregarMesa = "INSERT INTO Mesas (Estado,CodigoMesa) " +
                        $"VALUES ('{mesa.Estado}','{mesa.CodigoMesa}')";

                    using (SqlCommand cmdAgregarMesa = new SqlCommand(queryAgregarMesa, base._conexion))
                    {
                        cmdAgregarMesa.ExecuteNonQuery();//-->Ejecuto
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

        public bool DeleteDato(int id)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string qryDeleteMesa = $"DELETE FROM Mesas " +
                        $"WHERE IDMesa = {id}";

                    using (SqlCommand cmdDeleteMesa = new SqlCommand(qryDeleteMesa, base._conexion))
                    {
                        cmdDeleteMesa.ExecuteNonQuery();//-->Ejecuto
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
        /// Me permitira actualizar el estado
        /// y codigo de mesa segun el ID recibido.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public bool UpdateDato(Mesa mesa)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string nuevoEstado = mesa.Estado;

                    mesa.Estado = nuevoEstado; // Asigna el nuevo estado a la mesa antes de la consulta de actualización

                    string queryUpdateMesa = $"UPDATE Mesas SET Estado = '{mesa.Estado}', CodigoMesa = '{mesa.CodigoMesa}' " +
                                           $"WHERE IDMesa = {mesa.IDMesa}";

                    using (SqlCommand cmdUpdateMesa = new SqlCommand(queryUpdateMesa, base._conexion))
                    {
                        cmdUpdateMesa.ExecuteNonQuery();//-->Ejecuto
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

        public List<Mesa> ObtenerTodos()
        {
            List<Mesa> listaMesas = new List<Mesa>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT * FROM Mesas";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer la mesa a la lista
                {
                    listaMesas.Add(new Mesa((int)base._lector["IDMesa"],
                        (string)base._lector["Estado"],
                        (string)base._lector["CodigoMesa"]));
                }
            }
            catch (Exception)
            {
                return listaMesas;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaMesas;
        }

        /// <summary>
        /// Me permitira devolver
        /// aquellas mesas en las cuales
        /// se busque un estado en especifico
        /// por ej. Cerrada es una mesa SIN 
        /// Cliente.
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Mesa> ObtenerMesasPorEstado(string estado)
        {
            List<Mesa> listaMesas = new List<Mesa>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = $"SELECT * FROM Mesas WHERE Estado = '{estado}'";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer la mesa a la lista
                {
                    listaMesas.Add(new Mesa((int)base._lector["IDMesa"],
                        (string)base._lector["Estado"],
                        (string)base._lector["CodigoMesa"]));
                }
            }
            catch (Exception)
            {
                return listaMesas;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaMesas;
        }

        public Mesa ObtenerEspecifico(int id)
        {
            Mesa mesa = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = $"SELECT * FROM Mesas WHERE IDMesa = {id}";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                // Verificar si hay filas disponibles para leer
                if (base._lector.Read())
                {
                    // Se encontró una fila, podemos leer los datos
                    mesa = new Mesa((int)base._lector["IDMesa"],
                            (string)base._lector["CodigoMesa"],
                            (string)base._lector["Estado"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la mesa específica", ex);
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }

            return mesa;
        }

    }
}
