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
        public void SQLiteStringToDateTimeConverter()
        {
            ApiQueryBuilder apiQueryBuilder = new ApiQueryBuilder();
            
            String date = "2013-01-16T08:16:59.84";

            DateTime expected = new DateTime(2013, 1, 16, 8, 16, 59);

            DateTime actual = apiQueryBuilder.StringDateCoverter(date);

            Assert.AreEqual(expected, actual);
        }

    }
}
