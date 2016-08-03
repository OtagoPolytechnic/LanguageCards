using System;
using System.Collections.Generic;
using System.Text;

using LanguageApp.iOS.Database;
using LanguageApp.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteService))]
namespace LanguageApp.iOS.Database
{
    public class SQLiteService : ISQLiteConnection
    {
    }
}
