using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database.Models
{
    [Table("Modification")]
    public class Modification
    {
        [PrimaryKey]
        public string tableName { get; set; }
        public string lastUpdated { get; set; }
    }
}
