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
            dbConnection = GetConnection();
            CreateTablesAsync(dbConnection);
        }

        /// <summary>
        ///     Gets the async connection for the database
        /// </summary>
        /// <returns>SQLiteAsyncConnection</returns>
        public SQLiteAsyncConnection GetConnection()
        {
            return DependencyService.Get<ISQLiteConnection>().CreateConnection();
        }

        /// <summary>
        ///     Creates all the tables
        /// </summary>
        /// <param name="con">SQLiteAsyncConnection</param>
        public void CreateTablesAsync(SQLiteAsyncConnection con)
        {
            con.CreateTablesAsync<WordRecord, WordPair>();
        }

        /// <summary>
        ///     Returns a string of the last time the database was updated
        /// </summary>
        /// <returns></returns>
        public string LastUpdatedDate()
        {
            DatabaseQueries dbq = new DatabaseQueries(dbConnection);
            string date = dbq.LatestUpdate();                
            return date;
        }

        /// <summary>
        ///     Receives everything to insert, update, & delete then writes to the database
        /// </summary>
        public void WriteToDatabase(List<Model> insertList, List<Model> updateList, List<Model> deleteList)
        {
            DatabaseQueries dbq = new DatabaseQueries(dbConnection);
            foreach (var model in insertList)
            {
                //dbq.InsertRecord(model);
            }
            foreach (var model in updateList)
            {
                //dbq.UpdateRecord(model);
            }
            foreach (var model in deleteList)
            {
                //dbq.DeleteRecord(model);
            }
        }

        


    }
}
