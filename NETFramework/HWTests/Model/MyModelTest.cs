using HW.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTests.Model
{
    public class MyModelTest : IModel
    {

        private MyStoreContext _context;
        public MyStoreContext Context { get => _context; set => _context = value; }
        public decimal Totalcost { get; set; }

        public MyModelTest(MyStoreContext context)
        {
            Context = context;
        }
    }

    [TestClass()]
    public class MpTest
    {

        MyModelTest myModelTest = new MyModelTest(new MyStoreContext());

        [TestMethod]
        public async Task SeeTest()
        {
            // Act
            var client = await myModelTest.Context.Clients.FindAsync(6);

            // Assert
            Assert.AreEqual("Овк комплект", client.Name);;
        }
    }
}
