using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HW.Model.Tests
{
    [TestClass()]
    public class ConnectorTests
    {
        [TestMethod()]
        public async Task MyModelTest()  // conection to DB
        {
            // Arrange 
            MyModel model = new MyModel(new MyStoreContext());

            //Act
            // Assert
            var parts = await model.Context.Parts.FindAsync(1);

            try
            {
                Assert.IsNotNull(parts);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task MyModelClientTest()  // conection to DB
        {
            // Arrange
            IModel model = new MyModel(new MyStoreContext());

            // Act
            var client = await model.Context.Clients.FindAsync(6);

            // Assert
            Assert.AreEqual("Овк комплект", client.Name);
        }

        [TestMethod()]
        public async Task MyModelAdminTest()  // conection to DB
        {
            // Arrange
            MyModel model = new MyModel(new MyStoreContext());

            // Act
            var admin = await model.Context.Admins.FindAsync(1);

            // Assert
            Assert.AreEqual("admin", admin.Login);
        }

        [TestMethod()]
        public async Task MyModelManufacturerTest()  // conection to DB
        {
            // Arrange
            MyModel model = new MyModel(new MyStoreContext());

            // Act
            var man = await model.Context.Manufacturers.FindAsync(4);

            // Assert
            Assert.AreEqual("Spirotech", man.Name);
        }

        [TestMethod()]
        public async Task MyModelPartTest()  // conection to DB
        {
            // Arrange
            MyModel model = new MyModel(new MyStoreContext());

            // Act
            var part = await model.Context.Parts.FindAsync(25);

            // Assert
            Assert.AreEqual("Гидравлическая стрелка SpiroCross DN65 (фланец - сталь)", part.Name);
        }

        [TestMethod()]
        public async Task MyModelOrderTest()  // conection to DB
        {
            // Arrange
            MyModel model = new MyModel(new MyStoreContext());

            // Act
            var count = await model.Context.Orders.FindAsync(8);

            // Assert
            Assert.AreEqual(1, count.ClientFk);
        }
    }
}