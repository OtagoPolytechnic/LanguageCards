using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using SQLiteNetExtensions.Attributes;

namespace LanguageApp.Database.Models
{
    [Table("WordPair")]
    public class WordPair
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [ForeignKey(typeof(WordRecord))]
        public int original { get; set; }

        [ForeignKey(typeof(WordRecord))]
        public int translation { get; set; }
    }
}
