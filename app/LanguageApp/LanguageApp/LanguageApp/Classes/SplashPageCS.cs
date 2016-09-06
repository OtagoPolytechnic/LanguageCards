using LanguageApp.Database;
using LanguageApp.Database.Models;
using LanguageApp.Database.Repositorys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class SplashScreenCS : ContentPage
    {
        private AppManager appManager;

        public SplashScreenCS()
        {
            BackgroundImage = "ira_on_black.jpg";

            appManager = new AppManager();

            Task.Run(() => AsyncCall()).Wait();                        
        }

        public async Task AsyncCall()
        {
            DatabaseManager dbm = new DatabaseManager();
            MobileDB mobliedb = new MobileDB();
            DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();

            await dbm.CallApi();
            List<WordPair> wordPairs = await mobliedb.GetAllWordPairs();
            List<WordRecord> wordRecords = await mobliedb.GetAllWordRecords();
            
            List<WordPageCS> wordPageList = new List<WordPageCS>();

            LinkedList<DisplayObject> displayObjects = displayObjectMaker.CreateDisplayObjects(wordPairs, wordRecords);
            
            await Navigation.PushModalAsync(new MainPageCS(appManager, displayObjects));
        }


    }
}
