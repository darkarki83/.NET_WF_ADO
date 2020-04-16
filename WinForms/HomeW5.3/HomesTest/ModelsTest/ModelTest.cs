using Home5._3.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesTest
{
    [TestFixture]
    public class ModelTest
    {
        [Test]
        public void Constructor_Bild_Bild()
        {
            IModel model = new Model();
            Assert.That(model.RichText, Is.Not.Null);
        }

        [Test]
        public void Color_Change_Changed()
        {

        }

        [Test]
        public void Font_Change_Changed()
        {

        }
    }
}
