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
        ExternalApi externalAsync;
        JsonParser jsonParser;

        public string jsonString;
        public string accountKey; //Will be needed eventually to access the api.    
        public string apiAddress;               
        public WebResponse webResponse; //Response returned from te External Async class.


        public DatabaseManager()
        {
            apiQueryBuilder = new ApiQueryBuilder();
            externalAsync = new ExternalApi();
            jsonParser = new JsonParser();
        }


        public async Task<string> CallApi()
        {
            apiAddress = apiQueryBuilder.GetUpdateAllString();

            Task<string> jsonTask = externalAsync.GetJsonData(apiAddress);
            return jsonString = await jsonTask;
        }

        public string GetJsonString()
        {
            return jsonString;
        }



    }
}
