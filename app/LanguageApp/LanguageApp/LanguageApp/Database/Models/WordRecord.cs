using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;

namespace LanguageApp.Database.Models
{
    [Table("WordRecord")]
    public class WordRecord
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string word { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public DateTime dateUpdate { get; set; }
        public DateTime dateCreated { get; set; }
        public bool publish { get; set; }      

    }
}
