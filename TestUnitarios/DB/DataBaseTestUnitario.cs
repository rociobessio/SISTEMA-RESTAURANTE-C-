using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TestUnitarios.DB
{
    /// <summary>
    /// Como mi clase AccesoADataBase es abstracta,
    /// no me dejaba instanciarla para la prueba, ya que rompia,
    /// cree esta clase que solo sera utilizada para unit testing
    /// y tiene un constructor que recibe una string. 
    /// La clase hereda de AccesoADataBase.
    /// </summary>
    public class AccesoADataBaseUnitTest : AccesoDB
    {
        public AccesoADataBaseUnitTest(string pruebaTest) : base(pruebaTest)
        {
        }
    }

    [TestClass]
    public class TestingAccesoABaseDeDatos
    {
        /// <summary>
        /// Me permite ver si funciona correctamente
        /// el metodo ProbarConexion, retornando true
        /// si funciona correctamente.
        /// </summary>
        [TestMethod]
        public void ProbarConexion_ConexionExitosa()
        {
            // Arrange
            AccesoADataBaseUnitTest accesoADataBase = new AccesoADataBaseUnitTest(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Restaurante;Data Source=DESKTOP-S8KBDM2;Trusted_Connection=True;");

            // Act
            bool resultado = accesoADataBase.ProbarConexion();

            // Assert
            Assert.IsTrue(resultado);
        }
    }
}
