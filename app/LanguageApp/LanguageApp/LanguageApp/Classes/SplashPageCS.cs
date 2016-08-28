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
        public SplashScreenCS()
        {
            DatabaseManager dbm = new DatabaseManager();
            MobileDB mobliedb = new MobileDB();
            DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();           

            Button button = new Button
            {
                Text = String.Format("Do top secret async stuff")
            };

            button.Clicked += async (sender, e) =>
            {
                await dbm.CallApi();

                List<WordPair> wordPairs = await mobliedb.GetAllWordPairs();
                List<WordRecord> wordRecords = await mobliedb.GetAllWordRecords();

                

                List<WordPageCS> wordPageList = new List<WordPageCS>(); // MAKE PAGES WITH DISPLAY OBJECTS THEN 

                foreach (WordRecord w in wordRecords)
                {
                    Debug.WriteLine(w.id + " " + w.word);
                }

                List<DisplayObject> displayObjects = displayObjectMaker.CreateDisplayObjects(wordPairs, wordRecords);  // THIS IS NOT WORKING CORRECTLY 

                foreach (DisplayObject d in displayObjects)
                {
                    Debug.WriteLine(d.orginal + "   " + d.translation);
                }

                //await Navigation.PushAsync(new MainPageCS(displayObjects));
                await Navigation.PushModalAsync(new MainPageCS(displayObjects));
                //label.Text = jsonString;
            };

            var stackLayout = new StackLayout
            {
                Children = { button }

            };
            this.Content = stackLayout;

        }
        


    }
}
