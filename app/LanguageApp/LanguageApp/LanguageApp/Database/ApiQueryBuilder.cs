﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{

    public class ApiQueryBuilder
    {

        //Create the api queries for the async call.

        public ApiQueryBuilder()
        {

        }
                       
            
        //  YYYY-MM-DDTHH:MM:SS ///SQLite date format

        /// <JsonDateCoverter>
        /// Covert SQlite string into DateTime so it can then be coverted into json string date format later.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public DateTime StringDateCoverter(String date)
        {
            throw new NotImplementedException();
        }
    }


    
}
