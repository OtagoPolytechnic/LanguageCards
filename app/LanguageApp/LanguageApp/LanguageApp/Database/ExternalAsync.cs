
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public async Task<string> CallApi(String apiString)
        {

            string jsonString;

            try
            {    
                Uri uri = new Uri(apiString);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                Task<WebResponse> responseTask = request.GetResponseAsync();
                using (WebResponse response = await responseTask)
                {
                    jsonString = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
                    return jsonString; 
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Web Exception:" + e.ToString());
                string ahh = "This shit is fucked";
                return ahh;
                throw;   
            }
        }


        //public async Task<string> ReadWebResponse(WebResponse response)
        //{
            

            

        //    return jsonString;
        //}

    }
}
