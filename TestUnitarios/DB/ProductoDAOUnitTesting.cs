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
    public class ProductoDAOUnitTesting
    {
        [TestMethod]
        public void Insertar_Producto_OK()
        {
            //-->Arrange
            ProductoDAO productoDAO = new ProductoDAO();

            //-->Act
            //bool pudoInsertar = productoDAO.AgregarDato(new Producto(""));
        }

    }
}
