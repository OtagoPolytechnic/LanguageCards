using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class DatabaseManager
    {
        //Handle connections and commuication between each class.   

        public Uri uri { get; set; }
        public HttpWebRequest webRequest;
        public NetworkCredential credentials;
        public HttpWebResponse webResponse;


        public DatabaseManager()
        {

        }     


       

    }
}
