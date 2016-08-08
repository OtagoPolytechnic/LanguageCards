using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageApp.Database;
using LanguageApp.Database.Models;

namespace UnitTestDatabaseClasses
{
    [TestClass]
    public class DatabaseTesting
    {
        [TestMethod]
        public void JSONStringReturnsFromApi()
        {
            DatabaseManager dbm = new DatabaseManager();
            dbm.CallApi();

            string actual = dbm.GetJsonString();
            string expected = "";

            Assert.AreEqual(expected, actual);
        }

    }
}
