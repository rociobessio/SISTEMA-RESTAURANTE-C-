using Entidades;
using Entidades.DB;

namespace UnitTestings.DAO
{
    [TestClass]
    public class EmpleadosDAO
    {
        [TestMethod]
        public void TraerTodosLosEmpleados_OK()
        {
            //-->Arrange, preparo el entorno
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            List<Empleado> listaEmpleados = empleadoDAO.ObtenerTodos();
            
            //-->Act, verifico que la lista este cargada
            bool resultado = listaEmpleados.Count > 0;
            
            //-->Assert, valido el resultado
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ObtenerEmpleadoEspecificoPorID_OK()
        {
            //-->Arrange, preparar entorno
            EmpleadoDAO empleadoDAO = new EmpleadoDAO(); 

            //-->Act:
            Empleado empleadoExistente = empleadoDAO.ObtenerEspecifico(1); 

            //-->Assert, valido el resultado
            Assert.IsTrue(empleadoExistente != null);
        }
    }
}