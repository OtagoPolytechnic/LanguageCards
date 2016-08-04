using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LanguageApp.Database.Models;

namespace LanguageApp.Database
{
    public class MobileDB
    {
        private SQLiteAsyncConnection dbConnection;
        
        /// <summary>
        ///     
        /// </summary>
        public MobileDB()
        {
            dbConnection = DependencyService.Get<ISQLiteConnection>().CreateConnection();
            CreateTablesAsync(dbConnection);
        }

        /// <summary>
        ///     Creates all the tables
        /// </summary>
        /// <param name="con">SQLiteAsyncConnection</param>
        public void CreateTablesAsync(SQLiteAsyncConnection con)
        {
            con.CreateTablesAsync<Models.WordRecord, Models.WordPair>();
        }

        public Tuple<DateTime, DateTime> GetDates()
        {

        }

        


    }
}
