using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class WordPageCS : ContentPage
    {
        public WordPageCS(DisplayObject displayObject)
        {
            var padding = new Thickness(0, Device.OnPlatform(250, 250, 0), 0, 0);



            Label wordLabel = new Label
            {
                Text = displayObject.orginal,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };



            Label wordLabel2 = new Label
            {
                Text = displayObject.translation,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var stackLayout = new StackLayout
            {
                Children = { wordLabel, wordLabel2 }

            };
            Padding = padding;
            this.Content = stackLayout;
        }
    }
}
