using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DB
{
    public class ClienteDAO
    {
    //    public bool Guardar(Cliente cliente)
    //    {
    //        bool pudoGuardar = false;

    //        try
    //        {
    //            string querySQL = "INSERT INTO Empleados (rol,nombre,fechaAlta,clave,usuario)";
    //            querySQL += $"VALUES ('{empleado.Rol}', '{empleado.Nombre}', '{empleado.FechaAlta.ToShortDateString()}'," +
    //                $"'{empleado.Usuario.IDUsuario}')";

    //            base._comando = new SqlCommand();
    //            base._comando.CommandType = CommandType.Text;
    //            base._comando.CommandText = querySQL;//-->Le paso la query
    //            base._comando.Connection = base._conexion;

    //            base._conexion.Open();//-->Abro la conexion a la DB

    //            int filasAfectadas = base._comando.ExecuteNonQuery(); ;
    //            if (filasAfectadas > 0) { pudoGuardar = true; }

    //        }
    //        catch (Exception)
    //        {
    //            pudoGuardar = false;
    //        }
    //        finally
    //        {
    //            if (base._conexion.State == ConnectionState.Open)//-->Chequeo si la conexion esta abierta
    //            {
    //                base._conexion.Close();//-->La cierro
    //            }
    //        }
    //        return pudoGuardar;
    //    }
    }
}
