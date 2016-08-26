﻿using LanguageApp.Database.Models;
using Newtonsoft.Json;
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
        //Convert JSON data retrived from Async / API call into the sqlite database
        public string jsonString;


        public JsonParser()
        {

        }
     
        public void JsonDeserializer(string jsonData)
        {
            var json = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<RootObject>(jsonData));
        }
        
    }
}
