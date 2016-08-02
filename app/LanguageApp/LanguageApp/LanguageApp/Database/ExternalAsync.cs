
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class ExternalAsync
    {
        //Request data from the backend via httprequest / api call.

        public ExternalAsync()
        {

        }

        public HttpWebResponse CallApi(String apiString, String accountKey)
        {                                  
            HttpWebResponse webResponse = null;  
            try
            {
                Uri uri = new Uri(apiString);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);

                //Credentials currently not used.
                //accountKey will be the incomming password / user name. If required by the api desgin.
                NetworkCredential credentials = new NetworkCredential();
                webRequest.Credentials = credentials;       

                return webResponse; 
            }
            catch (WebException e)
            {
                Debug.WriteLine("Web Exception:" + e.ToString());
                throw;   
            }
        }

    }
}
