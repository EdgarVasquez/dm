
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using prueba.Models;
using prueba.Services;
using prueba.Controllers;
using prueba.DTO;
using Moq;
using Microsoft.EntityFrameworkCore;
namespace YourUnitTestNamespace
{
    [TestFixture]
    public class HabitosControllerTest
    {
        
        [Test] // Add the attributes to the test method
        public void Test_HabitosController_Set() // Use the attribute values as method parameters
        {
          // Arrange
            var builder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("AppConnection");

            var options = new DbContextOptionsBuilder<pruebaContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var dbContext = new pruebaContext(options))
            {
            IHabitosServices _service = new HabitosServices(dbContext);
     
            var controller = new HabitosController(_service);
            Habitos param = new Habitos() { Id = 1, Estatus = false, Id_Usuario_crea = 1, Fecha_Crea = DateTime.Now, Fecha_Modifica = DateTime.Now, Id_Usuario_Modifica = 1, Descripcion = "", Precio = 0 };

            // Act
            var result = controller.Set(param).Result;

            // Assert
            Assert.IsNotNull(result);
             }
            // Add more assertions as needed
        }


        [Test] // Add the attributes to the test method
        public void Test_HabitosController_Get() // Use the attribute values as method parameters
        {
          // Arrange
            var builder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("AppConnection");

            var options = new DbContextOptionsBuilder<pruebaContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var dbContext = new pruebaContext(options))
            {
            IHabitosServices _service = new HabitosServices(dbContext);
     
            var controller = new HabitosController(_service);
            Habitos param = new Habitos() { Id = 1, Estatus = false, Id_Usuario_crea = 1, Fecha_Crea = DateTime.Now, Fecha_Modifica = DateTime.Now, Id_Usuario_Modifica = 1, Descripcion = "", Precio = 0 };

            // Act
            var result = controller.Get(1).Result;

            // Assert
            Assert.IsNotNull(result);
             }
            // Add more assertions as needed
        }
    }
}