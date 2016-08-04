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
        /// 
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime GetLatestUpdatedDate()
        {
            
            throw new NotImplementedException();
        }
        

    }
}
