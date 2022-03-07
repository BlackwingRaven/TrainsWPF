using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainsWPFTestLibrary;

namespace TrainsWPFTests
{
    class UnitTest
    {
        TestMethodClass t = new TestMethodClass();

        [TestMethod]
        public void TestCreateUser()
        {
            bool actual = t.CreateBuyer("000", "Test1", "Test1", "test@t.ru", "swordfish");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestCreateAdmin()
        {
            bool actual = t.CreateAdmin("adm1", "swordfish");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestReadUserEmail()
        {
            string expected = "test@t.ru";
            string actual = t.ReadBuyerEmail();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateUserEmail()
        {
            string expected = "testnew@t.ru";
            string actual = t.UpdateBuyerEmail("testnew@t.ru");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            bool actual = t.DeleteBuyer("000");
            Assert.IsTrue(actual);
        }
    }
}
