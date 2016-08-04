using LanguageApp.Database.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class DatabaseQueries
    {
        private SQLiteAsyncConnection connection;

        //All Database queries.

        public DatabaseQueries(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        ///     Queries the database for the last time the database was updated
        /// </summary>
        /// <returns>string</returns>
        public string LatestUpdate()
        {
            //connection.ExecuteAsync
            throw new NotImplementedException();
        }
        
        public void InsertRecord(IModel obj)
        {
            var record = obj;
            connection.InsertAsync(record);
            UpdateLastModified(record.GetTableName());
        }

        public void UpdateRecord(IModel obj)
        {
            var record = obj;
            connection.UpdateAsync(record);
            UpdateLastModified(record.GetTableName());
        }

        public void DeleteRecord(IModel obj)
        {
            var record = obj;
            connection.DeleteAsync(record);
            UpdateLastModified(record.GetTableName());
        }

        public void UpdateLastModified(string tableName)
        {
            string date = DateTime.Now.ToString("YYYY-MM-DDTHH:MM: SS");
            Modification modified = new Modification();
            modified.tableName = tableName;
            modified.lastUpdated = date;
            connection.InsertOrReplaceAsync(modified);
        }

    }
}
