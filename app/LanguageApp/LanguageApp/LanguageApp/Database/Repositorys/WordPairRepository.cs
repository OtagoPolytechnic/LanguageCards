using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Async;
using LanguageApp.Database.Models;

namespace LanguageApp.Database.Repositorys
{
    public class WordPairRepository : Repository<WordPair>
    {
        protected readonly SQLiteAsyncConnection con;

        public WordPairRepository(SQLiteAsyncConnection con) : base(con)
        {
            this.con = con;
        }



    }
}
