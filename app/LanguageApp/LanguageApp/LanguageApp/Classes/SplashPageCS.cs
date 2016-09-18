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
        // Not used in beta product
        //private AppManager appManager;

        public SplashScreenCS()
        {
            BackgroundImage = "ira_on_black.jpg";

            //appManager = new AppManager();

            Task.Run(() => AsyncCall()).Wait();

        }

        public async Task AsyncCall()
        {
            // 
            DatabaseManager dbm = new DatabaseManager();
            // Phone DB
            MobileDB mobliedb = new MobileDB();
            // Used to create display objects
            DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();
            // Tries to hit the backend to find new words
            try
            {
                await dbm.CallApi();
            }
            catch (Exception)
            {
                //throw;
            }

            // Get all word pairs & records to pass into displayObjectMaker
            List<WordPair> wordPairs = await mobliedb.GetAllWordPairs();
            List<WordRecord> wordRecords = await mobliedb.GetAllWordRecords();

            List<DisplayObject> displayObjects = displayObjectMaker.CreateDisplayObjects(wordPairs, wordRecords);
            // Goes to next page
            await Navigation.PushModalAsync(new CardCarouselScreenCS(displayObjects));
        }




    }
}
