
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
        public async Task<WebResponse> CallApi(String apiString)
        {
           
            try
            {
                WebResponse response;
                Uri uri = new Uri(apiString);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                using (WebResponse webResponse = await request.GetResponseAsync()) 
                {
                    response = webResponse;
                    return response;
                } 
                
            }
            catch (WebException e)
            {
                Debug.WriteLine("Web Exception:" + e.ToString());
                throw;   
            }
        }

    }
}
