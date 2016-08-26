using LanguageApp.Database;
using LanguageApp.Database.Models;
using LanguageApp.Database.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class SplashScreenCS : ContentPage
    {
        public SplashScreenCS()
        {
            MobileDB mdb = new MobileDB();
            DBGeneric dbg = new DBGeneric();
            DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();           

            Button button = new Button
            {
                Text = String.Format("Do top secret async stuff")
            };

            button.Clicked += async (sender, e) =>
            {
                List<WordPair> wordPairs = await dbg.GetAll<WordPair>();
                List<WordRecord> wordRecords = await dbg.GetAll<WordRecord>();
                List<WordPageCS> wordPageList = new List<WordPageCS>();

                List<DisplayObject> displayObjects = displayObjectMaker.CreateDisplayObjects(wordPairs, wordRecords);

                

                //label.Text = jsonString;
            };

        }
    }
}
