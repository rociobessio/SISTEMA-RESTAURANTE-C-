using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class FacturacionesDAO : AccesoDB
    {

        /// <summary>
        /// Me permitira insertar una instancia de Facturaciones en
        /// la tabla Facturas.
        /// </summary>
        /// <param name="factura"></param>
        /// <returns></returns>
        public bool AgregarDato(Facturaciones factura)
        {

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO Facturaciones (MetodoPago,Total,Recibido,Cambio,FechaFacturacion,pagada,CodPedido) " +
                        "VALUES (@MetodoPago,@Total,@Recibido,@Cambio,@FechaFacturacion,@pagada,@CodPedido)";

                    base._comando = new SqlCommand(qryInsertProd, this._conexion);
                    base._comando.Parameters.AddWithValue("@MetodoPago", factura.MetodoPago);
                    base._comando.Parameters.AddWithValue("@Total", factura.Total);
                    base._comando.Parameters.AddWithValue("@Recibido", factura.Recibido);
                    base._comando.Parameters.AddWithValue("@Cambio", factura.Cambio);
                    base._comando.Parameters.AddWithValue("@FechaFacturacion", factura.FechaFacturacion);
                    base._comando.Parameters.AddWithValue("@pagada", factura.Pagado);
                    base._comando.Parameters.AddWithValue("@CodPedido", factura.CodigoPedido);

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

        public bool AgregarFacturacionRetornarID(Facturaciones factura,out int id)
        {

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO Facturaciones (MetodoPago,Total,Recibido,Cambio,FechaFacturacion,pagada,CodPedido) " +
                        "OUTPUT INSERTED.IDFacturacion " +
                        "VALUES (@MetodoPago,@Total,@Recibido,@Cambio,@FechaFacturacion,@pagada,@CodPedido)";

                    base._comando = new SqlCommand(qryInsertProd, this._conexion);
                    base._comando.Parameters.AddWithValue("@MetodoPago", factura.MetodoPago);
                    base._comando.Parameters.AddWithValue("@Total", factura.Total);
                    base._comando.Parameters.AddWithValue("@Recibido", factura.Recibido);
                    base._comando.Parameters.AddWithValue("@Cambio", factura.Cambio);
                    base._comando.Parameters.AddWithValue("@FechaFacturacion", factura.FechaFacturacion);
                    base._comando.Parameters.AddWithValue("@pagada", factura.Pagado);
                    base._comando.Parameters.AddWithValue("@CodPedido", factura.CodigoPedido);

                    id = Convert.ToInt32(base._comando.ExecuteScalar());//-->Obtengo el ID
                }
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
            return true;
        }

        public List<Facturaciones> ObtenerTodos()
        {
            List<Facturaciones> listaFacturaciones = new List<Facturaciones>();

            try
            {
                base._comando = new SqlCommand();
                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT * FROM Facturaciones";

                base._comando.Connection = base._conexion;
                base._conexion.Open();
                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Cargo la lista con los productos.
                {
                    listaFacturaciones.Add(new Facturaciones(
                        (int)base._lector["IDFacturacion"],
                        (string)base._lector["MetodoPago"],
                        (double)base._lector["Total"],
                        (DateTime)base._lector["FechaFacturacion"],
                        (bool)base._lector["pagada"],
                        (string)base._lector["CodPedido"],
                        (double)base._lector["Recibido"],
                        (double)base._lector["Cambio"]));
                }
            }
            catch (Exception)
            {
                return listaFacturaciones;
            }
            finally
            {
                if (base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }
            return listaFacturaciones;
        }
    }
}
