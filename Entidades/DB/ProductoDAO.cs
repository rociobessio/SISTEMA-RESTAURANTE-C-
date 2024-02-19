using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Net.Http.Headers;

namespace Entidades.DB
{
    public class ProductoDAO : AccesoDB,ICrud<Producto>
    {
        /// <summary>
        /// Me permitira guardar una instancia 
        /// de un producto en la DB
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public bool AgregarDato(Producto prod)
        {

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))//-->Le paso la cadena de la DB
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryInsertProd = "INSERT INTO Productos (Nombre, Sector, Precio, Tipo, TiempoEstimado, IDCategoria, Imagen) " +
                       "VALUES (@Nombre, @Sector, @Precio, @Tipo, @TiempoEstimado, @IDCategoria, @Imagen)";
                  
                    base._comando = new SqlCommand(qryInsertProd, this._conexion);
                    base._comando.Parameters.AddWithValue("@Nombre", prod.Nombre);
                    base._comando.Parameters.AddWithValue("@Sector", prod.Sector);
                    base._comando.Parameters.AddWithValue("@Precio", prod.Precio);
                    base._comando.Parameters.AddWithValue("@Tipo", prod.Tipo);
                    base._comando.Parameters.AddWithValue("@TiempoEstimado", prod.TiempoEstimadoPreparacion);
                    base._comando.Parameters.AddWithValue("@IDCategoria", prod.Categoria);
                    base._comando.Parameters.AddWithValue("@Imagen", prod.Imagen);

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

        /// <summary>
        /// Me permitira actualizar los datos
        /// de un producto en la base de datos,
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public bool UpdateDato(Producto prod)
        {
            bool pudoActualizar = false;

            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion

                    string qryUpdateProducto = "UPDATE Productos " +
                        $"SET Nombre = @Nombre, " +
                        $"Sector = @Sector, " +
                        $"Precio = @Precio, " +
                        $"Tipo = @Tipo, " +
                        $"TiempoEstimado = @TiempoEstimado, " +
                        $"IDCategoria = @IDCategoria, " +
                        $"Imagen = @Imagen " +
                        $"WHERE IDProducto = {prod.IDProducto}";


                    base._comando = new SqlCommand(qryUpdateProducto, this._conexion);
                    base._comando.Parameters.AddWithValue("@Nombre", prod.Nombre);
                    base._comando.Parameters.AddWithValue("@Sector", prod.Sector);
                    base._comando.Parameters.AddWithValue("@Precio", prod.Precio);
                    base._comando.Parameters.AddWithValue("@Tipo", prod.Tipo);
                    base._comando.Parameters.AddWithValue("@TiempoEstimado", prod.TiempoEstimadoPreparacion);
                    base._comando.Parameters.AddWithValue("@IDCategoria", prod.Categoria);
                    base._comando.Parameters.AddWithValue("@Imagen", prod.Imagen);

                    base._comando.ExecuteNonQuery();
                }
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                if(base._conexion.State == ConnectionState.Open)
                {
                    base._comando.Connection.Close();
                }
            }

            return pudoActualizar;
        }

        /// <summary>
        /// Se dara una baja logica de un
        /// producto mediante la coincidencia
        /// de IDs en la DB.
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
                            string queryDelete = "UPDATE Productos " +
                                                 $"SET FechaBaja = '{DateTime.Now.ToString("yyyy-MM-dd")}' " +
                                                 $"WHERE IDProducto = {id}";

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

        /// <summary>
        /// Me permitira devolver la instancia
        /// de un Producto mediante la busqueda
        /// de este en la DB por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Producto ObtenerEspecifico(int id)
        {
            Producto prodBuscado = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = "SELECT p.IDProducto, p.Nombre, p.Precio, p.Sector, p.Tipo, p.TiempoEstimado, p.FechaBaja, p.Imagen, p.IDCategoria " +
                                            "FROM Productos p " +
                                            "INNER JOIN Categorias c ON p.IDCategoria = c.ID " +
                                            $"WHERE p.IDProducto = {id}"; //-->La query
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                prodBuscado = new Producto((int)base._lector["IDProducto"],
                    (string)base._lector["Nombre"],
                    (Sectores)Enum.Parse(typeof(Sectores), (string)base._lector["Sector"]),
                    (Tipo)Enum.Parse(typeof(Tipo), (string)base._lector["Tipo"]),
                    (TimeSpan)base._lector["TiempoEstimado"],
                    (double)base._lector["Precio"],
                    (int)base._lector["IDCategoria"],
                    (Byte[])base._lector["Imagen"]
                    );

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

            return prodBuscado;
        }

        public Producto ObtenerPorNombre(string nombre)
        {
            Producto prodBuscado = null;
            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandText = "SELECT p.IDProducto, p.Nombre, p.Precio, p.Sector, p.Tipo, p.TiempoEstimado, p.FechaBaja, p.Imagen, p.IDCategoria " +
                                            "FROM Productos p " +
                                            "INNER JOIN Categorias c ON p.IDCategoria = c.ID " +
                                            $"WHERE p.Nombre = '{nombre}'"; //-->La query
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                base._lector.Read();

                prodBuscado = new Producto((int)base._lector["IDProducto"],
                    (string)base._lector["Nombre"],
                    (Sectores)Enum.Parse(typeof(Sectores), (string)base._lector["Sector"]),
                    (Tipo)Enum.Parse(typeof(Tipo), (string)base._lector["Tipo"]),
                    (TimeSpan)base._lector["TiempoEstimado"],
                    (double)base._lector["Precio"],
                    (int)base._lector["IDCategoria"],
                    (Byte[])base._lector["Imagen"]
                    );

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

            return prodBuscado;
        }

        /// <summary>
        /// Cargara la lista de productos 
        /// disponibles en la DB.
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerTodos()
        {
            List<Producto> listaProductos = new List<Producto>();

            try
            {
                base._comando = new SqlCommand();
                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT p.IDProducto, p.Nombre, p.Sector, p.Tipo, p.TiempoEstimado, p.Precio, p.IDCategoria, p.Imagen " +
                    "FROM Productos p " +
                    "INNER JOIN Categorias C " +
                    "ON C.ID = p.IDCategoria";

                base._comando.Connection = base._conexion;
                base._conexion.Open();
                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Cargo la lista con los productos.
                {
                    listaProductos.Add(new Producto(
                        (int)base._lector["IDProducto"],
                        (string)base._lector["Nombre"],
                        (Sectores)Enum.Parse(typeof(Sectores), (string)base._lector["Sector"]),
                        (Tipo)Enum.Parse(typeof(Tipo), (string)base._lector["Tipo"]),
                        (TimeSpan)base._lector["TiempoEstimado"],
                        (double)base._lector["Precio"],
                        (int)base._lector["IDCategoria"],
                        (Byte[])base._lector["Imagen"]));
                }
            }
            catch(Exception)
            {
                return listaProductos;
            }
            finally
            {
                if(base._conexion.State == ConnectionState.Open)
                {
                    base._conexion.Close();
                }
            }
            return listaProductos;
        }
    }
}
