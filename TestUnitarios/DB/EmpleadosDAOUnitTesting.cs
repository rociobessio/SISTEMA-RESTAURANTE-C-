using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DB;
using Entidades;

namespace TestUnitarios.DB
{
    [TestClass]
    public class EmpleadosDAOUnitTesting
    {
        [TestMethod]
        public void Obtener_Empleados_OK()
        {
            //-->Arrange
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            List<Empleado> listaEmpleados = empleadoDAO.ObtenerTodos();

            //-->Act
            bool resultado = listaEmpleados.Count > 0;

            //-->Arrange
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Insertar_Empleado_OK()
        {
            //-->Arrange
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            Empleado nuevoEmpleado = new Empleado(Rol.Cocinero,DateTime.Now,"TEST","UNIT","Calle Falsa",
                "11111","90123",DateTime.Now,Genero.Otro,new Usuario("0000@","aaaaa"));

            //-->Act
            bool pudoInsertar = empleadoDAO.AgregarDato(nuevoEmpleado);

            //-->Assert
            Assert.IsTrue(pudoInsertar);
        }

        [TestMethod]
        public void Obtener_Empleado_Especifico_OK()
        {
            //-->Arrange
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            int idBuscada = 5;

            //-->Act
            Empleado empleado = empleadoDAO.ObtenerEspecifico(idBuscada);

            //-->Assert
            Assert.IsNotNull(empleado);
        }


        [TestMethod]
        public void Update_Empleado_OK()
        {
            //-->Arrange
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            int idAModificar = 5;
            Empleado empleado = empleadoDAO.ObtenerEspecifico(idAModificar);

            //-->Act
            empleado.Nombre = "Modifico nombre";
            bool pudoModificar = empleadoDAO.UpdateDato(empleado);

            //-->Assert
            Assert.IsTrue(pudoModificar);
        }

        [TestMethod]
        public void Eliminar_Empleado_OK()
        {
            //-->Arrange
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            int idDarDeBaja = 5;

            //-->Act
            bool pudoEliminar = empleadoDAO.DeleteDato(idDarDeBaja);

            //-->Assert
            Assert.IsTrue(pudoEliminar);

        }
    }
}
