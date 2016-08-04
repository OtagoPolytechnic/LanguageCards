using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class JsonParser
    {
        //Convert JSON data retrived from Async // API call into the sqlite database
        public string jsonString;


        public JsonParser()
        {

        }

        //Tempory test method
        public string GetJsonString(HttpWebResponse webResponse)
        {
            return jsonString = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
        }
        
        
    }
}
