using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class DeliveryDAO : AccesoDB
    {

        public bool AgregarDato(Delivery delivery)
        {

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO Deliverys (Direccion,IDPedido,IDFacturacion,IDConductor) " +
                        "VALUES (@Direccion,@IDPedido,@IDFacturacion,@IDConductor)";

                    base._comando = new SqlCommand(qryInsertProd, this._conexion);
                    base._comando.Parameters.AddWithValue("@Direccion", delivery.Direccion);
                    base._comando.Parameters.AddWithValue("@IDPedido", delivery.IDPedido);
                    base._comando.Parameters.AddWithValue("@IDFacturacion", delivery.IDFacturacion);
                    base._comando.Parameters.AddWithValue("@IDConductor", delivery.IDConductor);

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

        public List<Delivery> ObtenerTodos()
        {
            List<Delivery> listaDeliverys = new List<Delivery>();

            try
            {
                base._comando = new SqlCommand();
                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT * FROM Deliverys";

                base._comando.Connection = base._conexion;
                base._conexion.Open();
                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())
                {
                    listaDeliverys.Add(new Delivery(
                        (int)base._lector["IDDelivery"],
                        (string)base._lector["Direccion"],
                        (int)base._lector["IDPedido"],
                        (int)base._lector["IDFacturacion"],
                        (int)base._lector["IDConductor"]));
                }
            }
            catch (Exception)
            {
                return listaDeliverys;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }
            return listaDeliverys;
        }
    }
}
