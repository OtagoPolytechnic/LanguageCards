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
            MobileDB mobliedb = new MobileDB();
            DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();           

            Button button = new Button
            {
                Text = String.Format("Do top secret async stuff")
            };

            button.Clicked += async (sender, e) =>
            {                
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

        public async Task AddNewWordPairs(MobileDB m)
        {
            WordPair w1 = new WordPair();
            w1.id = 94;
            w1.original = 108;
            w1.translation = 5;
            WordPair w2 = new WordPair();
            w2.id = 95;
            w2.original = 88;
            w2.translation = 10;
            WordPair w3 = new WordPair();
            w3.id = 96;
            w3.original = 14;
            w3.translation = 12;
            WordPair w4 = new WordPair();
            w4.id = 97;
            w4.original = 15;
            w4.translation = 11;

            await m.SaveModel(w1);
            await m.SaveModel(w2);
            await m.SaveModel(w3);
            await m.SaveModel(w4);
        }


    }
}
