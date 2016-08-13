using LanguageApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Async;

namespace LanguageApp.Database.Repositorys
{
    public class WordRecordRepository : Repository<WordRecord>
    {
        protected readonly SQLiteAsyncConnection con;

        public WordRecordRepository(SQLiteAsyncConnection con) : base(con)
        {
            this.con = con;
        }



    }


}
