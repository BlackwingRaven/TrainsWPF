using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainsWPFTestLibrary;

namespace TrainsTests
{
    [TestClass]
    class Class1
    {
        TestMethodClass t = new TestMethodClass();
        [TestMethod]
        public void TestReadUserEmail()
        {
            string expected = "test@t.ru";
            string actual = t.ReadBuyerEmail();
            Assert.AreEqual(expected, actual);
            //Assert.IsTrue(true);
        }
    }
}
