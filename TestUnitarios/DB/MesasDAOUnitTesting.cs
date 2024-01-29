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
    public class MesasDAOUnitTesting
    {
        /// <summary>
        /// Corrobora si el metodo ObtenerTodos()
        /// de la clase MesaDAO funciona correctamente
        /// y efectivamente carga la lista de objetos
        /// Mesa.
        /// </summary>
        [TestMethod]
        public void Obtener_Mesas_OK()
        {
            //-->Arrange
            MesaDAO mesaDAO = new MesaDAO();
            List<Mesa> listaMesas = mesaDAO.ObtenerTodos();

            //-->Act
            bool resultado = listaMesas.Count > 0;

            //-->Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        /// <summary>
        /// Me servira para corroborar si
        /// puede guardar correctamente una
        /// instancia del objeto Mesa en la
        /// tabla correspondiente.
        /// </summary>
        public void Insertar_Mesa_OK()
        {
            //-->Arrange
            MesaDAO mesaDAO = new MesaDAO();
            Mesa nuevaMesa = new Mesa();

            //-->Act
            bool resultado = mesaDAO.AgregarDato(nuevaMesa);

            //-->Assert
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Servira para comprobar si efectivamente
        /// se realiza la modificacion en la db
        /// pero se debe de mejorar.
        /// (Instanciar una nueva mesa, modificarla
        /// y luego eliminarla)
        /// </summary>
        [TestMethod]
        public void Update_Mesa_OK()
        {
            //-->Arrange
            MesaDAO mesaDAO = new MesaDAO();

            //-->Act
            bool resultado = mesaDAO.UpdateDato(10,"Pagando", "Puuu4");

            //-->Assert
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Me permitira eliminar un
        /// registro de una Mesa
        /// en la tabla de la db.
        /// </summary>
        [TestMethod]
        public void Delete_Mesa_OK()
        {
            //-->Arrange
            MesaDAO mesaDAO = new MesaDAO();

            //-->Act
            bool pudoEliminar = mesaDAO.EliminarDato(10);

            //-->Assert 
            Assert.IsTrue(pudoEliminar);
        }
    }
}
