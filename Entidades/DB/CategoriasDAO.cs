using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;


namespace Entidades.DB
{
    public class CategoriasDAO : AccesoDB
    {
        public bool AgregarCategoria(string categoria)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string queryAgregarCategoria = "INSERT INTO Categorias (Categoria) " +
                        $"VALUES ('{categoria}')";

                    using (SqlCommand comandoInsertCategoria = new SqlCommand(queryAgregarCategoria, base._conexion))
                    {
                        comandoInsertCategoria.ExecuteNonQuery();//-->Ejecuto
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

        public List<Tuple<int, string>> ObtenerTodos()
        {
            List<Tuple<int, string>> listaCategorias = new List<Tuple<int, string>>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = "SELECT ID, Categoria FROM Categorias";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer agrego el empleado a la lista
                {
                    int id = (int)base._lector["ID"];
                    string categoria = (string)base._lector["Categoria"];
                    listaCategorias.Add(new Tuple<int, string>(id, categoria));
                }
            }
            catch (Exception)
            {
                return listaCategorias;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaCategorias;
        }

        public List<string> FiltrarDato(string categoria)
        {
            List<string> listaCategoriasFiltradas = new List<string>();

            try
            {
                base._comando = new SqlCommand();

                base._comando.CommandType = System.Data.CommandType.Text;
                base._comando.CommandText = $"SELECT * FROM Categorias where Categoria like %'{categoria}'%";
                base._comando.Connection = base._conexion;

                base._conexion.Open();//-->Abro la conexion

                base._lector = base._comando.ExecuteReader();

                while (base._lector.Read())//-->Mientras pueda leer agrego el empleado a la lista
                {
                    listaCategoriasFiltradas.Add((string)base._lector["Categoria"]);
                }
            }
            catch (Exception)
            {
                return listaCategoriasFiltradas;
            }
            finally
            {
                if (base._conexion.State == System.Data.ConnectionState.Open)
                {
                    base._conexion.Close();//-->Cierro la conexión
                }
            }
            return listaCategoriasFiltradas;
        }


        public bool EliminarDato(int id)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string queryDeleteCategoria = $"DELETE FROM Categorias " +
                        $"WHERE ID = {id}";

                    using (SqlCommand cmdDeleteCategoria = new SqlCommand(queryDeleteCategoria, base._conexion))
                    {
                        cmdDeleteCategoria.ExecuteNonQuery();//-->Ejecuto
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

        public bool UpdateDato(int id,string categoria)
        {
            try
            {
                using (base._conexion = new SqlConnection(AccesoDB.CadenaDeConexion))
                {
                    base._conexion.Open();//-->Abro la conexion.

                    string queryUpdateCategoria = $"UPDATE Categorias SET Categoria = '{categoria}' " +
                        $"WHERE ID = {id}";

                    using (SqlCommand comandoUpdateCategoria = new SqlCommand(queryUpdateCategoria, base._conexion))
                    {
                        comandoUpdateCategoria.ExecuteNonQuery();//-->Ejecuto
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
