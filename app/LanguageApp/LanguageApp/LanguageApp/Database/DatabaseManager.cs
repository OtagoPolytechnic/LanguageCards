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
        public WebResponse webResponse; //Response returned from te External Async class.


        public DatabaseManager()
        {
            apiQueryBuilder = new ApiQueryBuilder();
            externalAsync = new ExternalAsync();
            jsonParser = new JsonParser();
        }


        public async void CallApi()
        {
            apiAddress = apiQueryBuilder.GetUpdateAllString();
          
            webResponse = await externalAsync.CallApi(apiAddress);  //I think becuase this is async it skips straight to the json string before it's ready.
            //Look into async waiting for webTask then calling json task
            //await webResponseTask.ContinueWith()
            //Task<string> jsonStringTask = jsonParser.GetJsonString(webResponse);
        }

        public string GetJsonString()
        {
            return jsonString;
        }



    }
}
