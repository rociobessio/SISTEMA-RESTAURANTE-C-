using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class MesaDAO : AccesoDB
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

        public bool EliminarDato(int id)
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
        public bool UpdateDato(int id,string estado,string codigo)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string queryUpdateMesa = $"UPDATE Mesas SET Estado = '{estado}', CodigoMesa = '{codigo}' " +
                        $"WHERE IDMesa = {id}";

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
    }
}
