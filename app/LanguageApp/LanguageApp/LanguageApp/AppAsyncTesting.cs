using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageApp.Database;
using Xamarin.Forms;

namespace LanguageApp
{
    public class AppAsyncTestingPage : ContentPage
    {
        public AppAsyncTestingPage()
        {


            Button TestButton = new Button
            {
                Text = String.Format("Button")
            };


            TestButton.Clicked += async (sender, e) =>
            {
                string jsonString;

                DatabaseManager dbm = new DatabaseManager();
                jsonString = await dbm.CallApi();

                TestButton.Text = String.Format(jsonString);

            };

            this.Content = TestButton;

        }
    }
}
