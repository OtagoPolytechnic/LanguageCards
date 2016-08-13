using LanguageApp.Database;
using LanguageApp.Database.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp
{
    public class AppDatabaseTesting : ContentPage
    {

        public AppDatabaseTesting()
        {
            SQLiteAsyncConnection con = DependencyService.Get<ISQLiteConnection>().CreateConnection();
            //con.CreateTablesAsync<WordRecord, WordPair, Modification>();
            

            string jsonString = "Ahhhh this didn't change";

            List<WordRecord> wordList = MockWords();

            Button button = new Button
            {
                Text = String.Format("Get Json")
            };


            Label label = new Label
            {
                Text = jsonString,

                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            button.Clicked += async (sender, e) =>
            {
                await con.CreateTablesAsync<WordRecord, WordPair, Modification>();

                Label lb = new Label { Text = jsonString };

                Repository<WordRecord> wrep = new Repository<WordRecord>(con);

                label.Text = "Button Pressed...Waiting";

                await wrep.SaveList(wordList);
                //List<WordRecord> temp = await wrep.Find(predicate: x => x.id < 100);
                List<WordRecord> temp = await wrep.GetAll();
                jsonString = temp[0].word;

                foreach (WordRecord w in temp)
                {
                    Debug.WriteLine(w.id + " = " + w.word);
                }

                label.Text = jsonString;
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    button,
                    label
                }
            };





        }

        public List<WordRecord> MockWords()
        {
            List<WordRecord> list = new List<WordRecord>();
            WordRecord a = new WordRecord();
            a.id = 34;
            a.word = "Word Test";
            WordRecord b = new WordRecord();
            b.id = 108;
            b.word = "CavsNation";
            list.Add(a);
            list.Add(b);
            return list;
        }







    }
}
