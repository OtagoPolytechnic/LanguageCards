
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


        /// <summary>
        /// Need to research Async HTTPWEBRESONSE STUFF // KEEPS THROWING ERRORS;
        /// </summary>
        /// <param name="apiString"></param>
        /// <returns></returns>
        public HttpWebResponse CallApi(String apiString)
        {
           
            try
            {
                Uri uri = new Uri(apiString);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);  

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                return response;
            }
            catch (WebException e)
            {
                Debug.WriteLine("Web Exception:" + e.ToString());
                throw;   
            }
        }

    }
}
