using HW.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Model
{
    [TestFixture]
    public class MyModelNewTest
    {
        // // Arrange 
        IModel myModelNew = new MyModelNew(new MyStoreContext());

        [TestCase(6, "Овк комплект")]
        [TestCase(3, "УкрЭнерго")]
        [TestCase(1, "Ник лтд")]
        public async Task DBTest(int clientId, string clientNameResult)
        {
            // Act
            var client = await myModelNew.Context.Clients.FindAsync(clientId);

            // Assert
            Assert.AreEqual(clientNameResult, client.Name); ;
        }

       [TestCase()]   // почему
        public async Task DBPart2Test()
        {
            // Act
            var order = await myModelNew.Context.Orders.FindAsync(1);

            // Assert
            Assert.IsNotNull(order.OrderData); ;
        }
    }
}
