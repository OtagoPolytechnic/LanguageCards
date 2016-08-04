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

        ApiQueryBuilder apiQueryBuilder;
        ExternalAsync externalAsync;
        JsonParser jsonParser;

        public string jsonString;
        public string accountKey; //Will be needed eventually to access the api.    
        public string apiAddress;               
        public HttpWebResponse webResponse; //Response returned from te External Async class.


        public DatabaseManager()
        {
            apiQueryBuilder = new ApiQueryBuilder();
            externalAsync = new ExternalAsync();
            jsonParser = new JsonParser();
        }


        public void CallApi()
        {
            apiAddress = apiQueryBuilder.GetUpdateAllString();
            webResponse = externalAsync.CallApi(apiAddress);
            jsonString = jsonParser.GetJsonString(webResponse);
        }

        public string GetJsonString()
        {
            return jsonString;
        }



    }
}
