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
        public void JsonParserStringToDateTimeConverter()
        {
            JsonParser jsonParser = new JsonParser();
            
            String jsonDate = "2013-01-16T08:16:59.844Z";

            DateTime expected = new DateTime(2013, 1, 16, 8, 16, 59);

            DateTime actual = jsonParser.JsonDateCoverter(jsonDate);

            Assert.AreEqual(expected, actual);
        }

    }
}
