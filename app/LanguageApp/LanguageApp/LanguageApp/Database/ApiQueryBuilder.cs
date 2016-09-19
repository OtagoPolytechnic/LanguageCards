using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{

    public class ApiQueryBuilder
    {

        //Create the api queries for the async call.
        //darvja1
        //jacksct1
        private string apiAddress = "http://gardits1.pythonanywhere.com/";
        private string apiwordRecords = "wordRecords/";

        public ApiQueryBuilder()
        {

        }
           
        public string GetUpdateAllString()
        {
            return apiAddress + apiwordRecords;
        }            
            
        
    }


    
}
