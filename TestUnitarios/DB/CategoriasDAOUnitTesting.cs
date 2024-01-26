using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.DB;

namespace TestUnitarios.DB
{
    [TestClass]
    public class CategoriasDAOUnitTesting
    {
        [TestMethod]
        public void Insert_Categoria_OK()
        {
            // Arrange
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            string categoria = "Vegetariano";

            // Act
            bool resultado = categoriasDAO.AgregarCategoria(categoria);

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Obtener_Categorias_OK()
        {
            // Arrange
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            //List<string> categorias = categoriasDAO.ObtenerTodos();

            // Act
            //bool resultado = categorias.Count > 0;

            //// Assert
            //Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Update_Categorias_OK()
        {
            // Arrange
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            //List<string> categorias = categoriasDAO.ObtenerTodos();
            string categoriaUpdateada = "Vegetarianos";
            int id = 1;
            bool resultado = false;

            // Act
            //foreach(string categoria in categorias)
            //{
            //    if(categoria == "Vegetariano")
            //    {
            //        resultado = categoriasDAO.UpdateDato(id,categoriaUpdateada);
            //        break;
            //    }
            //    id++; 
            //}

            // Assert
            Assert.IsTrue(resultado);
        }
    }
}
